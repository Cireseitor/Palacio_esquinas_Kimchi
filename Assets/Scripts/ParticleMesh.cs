using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMesh : MonoBehaviour
{
    [Header("Configuración de Prefabs")]
    [Tooltip("Array de prefabs que se instanciarán")]
    public GameObject[] prefabs;

    [Header("Configuración de Spawn")]
    [Tooltip("Frecuencia de spawn en segundos")]
    public float spawnRate = 1f;

    [Tooltip("Rango de posición X para spawn")]
    public Vector2 spawnRangeX = new Vector2(-5f, 5f);

    [Tooltip("Rango de posición Z para spawn")]
    public Vector2 spawnRangeZ = new Vector2(-5f, 5f);

    [Tooltip("Altura inicial de spawn")]
    public float spawnHeight = 10f;

    [Header("Configuración de Física")]
    [Tooltip("Velocidad inicial hacia abajo")]
    public float fallSpeed = 5f;

    [Tooltip("Variación en la velocidad de caída")]
    public float fallSpeedVariation = 2f;

    [Header("Configuración de Rotación")]
    [Tooltip("Velocidad de rotación en grados por segundo")]
    public Vector3 rotationSpeed = new Vector3(90f, 180f, 45f);

    [Tooltip("Variación en la velocidad de rotación")]
    public float rotationVariation = 0.5f;

    [Header("Configuración de Vida")]
    [Tooltip("Tiempo de vida en segundos")]
    public float lifeTime = 10f;

    [Tooltip("Variación en el tiempo de vida")]
    public float lifeTimeVariation = 2f;

    [Header("Configuración de Destrucción")]
    [Tooltip("Altura a la que se destruyen los objetos")]
    public float destroyHeight = -10f;

    [Header("Movimiento lateral (ruido)")]
    [Tooltip("Activa un desplazamiento suave izquierda-derecha con ruido senoidal")]
    public bool useNoiseMovement = false;

    [Tooltip("Amplitud del movimiento lateral cuando useNoiseMovement está activo")]
    public float noiseAmplitude = 0.5f;

    [Tooltip("Velocidad del movimiento lateral cuando useNoiseMovement está activo")]
    public float noiseFrequency = 1.5f;

    [Header("Modo Navidad")]
    [Tooltip("Si está activo, los objetos contarán para el marcador de Navidad al ser recogidos")]
    public bool navidad = false;

    [Tooltip("Contador de objetos de Navidad recogidos")]
    public int navidadContador = 0;

    private List<GameObject> activeObjects = new List<GameObject>();
    private bool isSpawning = false;

    void Start()
    {
        if (prefabs == null || prefabs.Length == 0)
        {
            Debug.LogError("ParticleMesh: No hay prefabs asignados en el array!");
            return;
        }

        StartSpawning();
    }

    public void StartSpawning()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            StartCoroutine(SpawnObjects());
        }
    }

    public void StopSpawning()
    {
        isSpawning = false;
        StopAllCoroutines();
    }

    private IEnumerator SpawnObjects()
    {
        while (isSpawning)
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void SpawnObject()
    {
        if (prefabs.Length == 0) return;

        // Seleccionar un prefab aleatorio
        GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];

        // Calcular posición de spawn
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnRangeX.x, spawnRangeX.y),
            spawnHeight,
            Random.Range(spawnRangeZ.x, spawnRangeZ.y)
        );

        // Generar rotación aleatoria inicial
        Quaternion randomRotation = Quaternion.Euler(
            Random.Range(0f, 360f),
            Random.Range(0f, 360f),
            Random.Range(0f, 360f)
        );

        // Instanciar el objeto
        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, randomRotation);

        // Hacer el objeto hijo de este ParticleMesh
        spawnedObject.transform.SetParent(this.transform);

        // Agregar el componente de comportamiento
        ParticleObject particleObject = spawnedObject.GetComponent<ParticleObject>();
        if (particleObject == null)
        {
            particleObject = spawnedObject.AddComponent<ParticleObject>();
        }

        // Configurar el objeto
        float currentFallSpeed = fallSpeed + Random.Range(-fallSpeedVariation, fallSpeedVariation);
        Vector3 currentRotationSpeed = new Vector3(
            rotationSpeed.x * Random.Range(1f - rotationVariation, 1f + rotationVariation),
            rotationSpeed.y * Random.Range(1f - rotationVariation, 1f + rotationVariation),
            rotationSpeed.z * Random.Range(1f - rotationVariation, 1f + rotationVariation)
        );
        float currentLifeTime = lifeTime + Random.Range(-lifeTimeVariation, lifeTimeVariation);

        particleObject.Initialize(
            currentFallSpeed,
            currentRotationSpeed,
            currentLifeTime,
            destroyHeight,
            useNoiseMovement,
            noiseAmplitude,
            noiseFrequency
        );
        particleObject.SetNavidad(navidad);

        // Agregar a la lista de objetos activos
        activeObjects.Add(spawnedObject);

        // Configurar callback para cuando se destruya
        particleObject.OnDestroyed += (obj, destroyedByCollision) =>
        {
            activeObjects.Remove(spawnedObject);
            if (destroyedByCollision && obj.IsNavidad())
            {
                navidadContador++;
            }
        };
    }

    public void ClearAllObjects()
    {
        for (int i = activeObjects.Count - 1; i >= 0; i--)
        {
            if (activeObjects[i] != null)
            {
                Destroy(activeObjects[i]);
            }
        }
        activeObjects.Clear();
    }

    public int GetActiveObjectCount()
    {
        return activeObjects.Count;
    }

    public void ResetNavidadCounter()
    {
        navidadContador = 0;
    }

    void OnDisable()
    {
        isSpawning = false;
    }

    void OnEnable()
    {
        StartSpawning();
    }

    void OnDrawGizmosSelected()
    {
        // Dibujar el área de spawn
        Gizmos.color = Color.green;
        Vector3 center = new Vector3(
            (spawnRangeX.x + spawnRangeX.y) / 2f,
            spawnHeight,
            (spawnRangeZ.x + spawnRangeZ.y) / 2f
        );
        Vector3 size = new Vector3(
            spawnRangeX.y - spawnRangeX.x,
            0.1f,
            spawnRangeZ.y - spawnRangeZ.x
        );
        Gizmos.DrawWireCube(center, size);

        // Dibujar la altura de destrucción
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(0, destroyHeight, 0), new Vector3(20f, 0.1f, 20f));
    }
}
