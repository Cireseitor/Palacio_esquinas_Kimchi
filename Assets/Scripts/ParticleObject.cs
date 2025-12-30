using System;
using UnityEngine;

public class ParticleObject : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    private float fallSpeed;
    private Vector3 rotationSpeed;
    private float lifeTime;
    private float destroyHeight;
    private bool useNoiseMovement;
    private float noiseAmplitude;
    private float noiseFrequency;
    private float noiseSeed;

    [Header("Estado")]
    private float currentLifeTime;
    private bool isAlive = true;

    public event Action<ParticleObject, bool> OnDestroyed;
    private bool isNavidad;

    void Update()
    {
        if (!isAlive) return;

        // Mover hacia abajo
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);

        // Aplicar ruido lateral opcional
        if (useNoiseMovement)
        {
            float noiseValue = Mathf.Sin((Time.time + noiseSeed) * noiseFrequency);
            float lateralOffset = noiseValue * noiseAmplitude * Time.deltaTime;
            transform.Translate(Vector3.right * lateralOffset, Space.World);
        }

        // Rotar
        transform.Rotate(rotationSpeed * Time.deltaTime);

        // Verificar tiempo de vida
        currentLifeTime -= Time.deltaTime;
        if (currentLifeTime <= 0)
        {
            DestroyObject();
            return;
        }

        // Verificar altura de destrucción
        if (transform.position.y <= destroyHeight)
        {
            DestroyObject();
            return;
        }
    }

    public void Initialize(
        float fallSpeed,
        Vector3 rotationSpeed,
        float lifeTime,
        float destroyHeight,
        bool useNoiseMovement,
        float noiseAmplitude,
        float noiseFrequency
    )
    {
        this.fallSpeed = fallSpeed;
        this.rotationSpeed = rotationSpeed;
        this.lifeTime = lifeTime;
        this.destroyHeight = destroyHeight;
        this.useNoiseMovement = useNoiseMovement;
        this.noiseAmplitude = noiseAmplitude;
        this.noiseFrequency = noiseFrequency;
        this.noiseSeed = UnityEngine.Random.Range(0f, 1000f);
        this.currentLifeTime = lifeTime;
        this.isAlive = true;
    }

    public void DestroyObject(bool destroyedByCollision = false)
    {
        if (!isAlive) return;

        isAlive = false;
        OnDestroyed?.Invoke(this, destroyedByCollision);
        Destroy(gameObject);
    }

    public float GetRemainingLife()
    {
        return currentLifeTime;
    }

    public float GetLifePercentage()
    {
        return currentLifeTime / lifeTime;
    }

    public bool IsAlive()
    {
        return isAlive;
    }

    // Método para cambiar la velocidad de caída dinámicamente
    public void SetFallSpeed(float newFallSpeed)
    {
        fallSpeed = newFallSpeed;
    }

    // Método para cambiar la velocidad de rotación dinámicamente
    public void SetRotationSpeed(Vector3 newRotationSpeed)
    {
        rotationSpeed = newRotationSpeed;
    }

    // Método para agregar tiempo de vida
    public void AddLifeTime(float additionalTime)
    {
        currentLifeTime += additionalTime;
    }

    // Detectar colisiones
    void OnTriggerEnter(Collider other)
    {
        if (!isAlive) return;

        HandleNavidadCollision(other != null ? other.transform : null);

        // Destruir el objeto cuando colisione con cualquier cosa
        DestroyObject(true);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isAlive) return;

        HandleNavidadCollision(collision != null ? collision.collider.transform : null);

        // Destruir el objeto cuando colisione con cualquier cosa
        DestroyObject(true);
    }

    public void SetNavidad(bool value)
    {
        isNavidad = value;
    }

    public bool IsNavidad()
    {
        return isNavidad;
    }

    private void HandleNavidadCollision(Transform collidedTransform)
    {
        if (!isNavidad || collidedTransform == null)
        {
            return;
        }

        collidedTransform.name = "ColliderNavidad";

        Transform parent = collidedTransform.parent;
        if (parent == null)
        {
            return;
        }

        ParticleSystem ps = BuscarParticleSystem(parent);
        if (ps != null)
        {
            ps.Play();
        }
    }

    private ParticleSystem BuscarParticleSystem(Transform parent)
    {
        // 1) ¿El padre inmediato tiene ParticleSystem?
        ParticleSystem ps = parent.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            return ps;
        }

        // 2) Buscar entre los hermanos (niños del mismo padre)
        foreach (Transform sibling in parent)
        {
            ps = sibling.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                return ps;
            }
        }

        // 3) Buscar un nivel más arriba (por ejemplo, default -> LargeBasket)
        if (parent.parent != null)
        {
            foreach (Transform child in parent.parent)
            {
                ps = child.GetComponentInChildren<ParticleSystem>();
                if (ps != null)
                {
                    return ps;
                }
            }
        }

        return null;
    }
}
