using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ImageSequenceLoop : MonoBehaviour
{
    public string folderName = "ImageSequence"; // Nombre de la carpeta en StreamingAssets
    public float framesPerSecond = 30.0f; // Velocidad en FPS
    public Image targetImage; // Objeto UI donde se mostrarán las imágenes
    private List<Sprite> sprites = new List<Sprite>(); // Lista de sprites
    private int currentIndex = 0; // Índice de la imagen actual
    private float frameDuration;
    private float timer;

    private void Start()
    {
        frameDuration = 1.0f / framesPerSecond; // Duración de cada frame en segundos
        LoadImages(); // Cargar todas las imágenes al iniciar
    }

    void LoadImages()
    {
        string path = Path.Combine(Application.streamingAssetsPath, folderName);
        if (Directory.Exists(path))
        {
            string[] files = Directory.GetFiles(path, "*.png"); // Cargar archivos .png

            foreach (string file in files)
            {
                Texture2D texture = LoadTexture(file); // Cargar textura desde archivo
                if (texture != null)
                {
                    Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
                    sprites.Add(sprite); // Añadir sprite a la lista
                }
            }
            if (sprites.Count == 0)
                Debug.LogError("No se encontraron imágenes en la carpeta especificada.");
        }
        else
        {
            Debug.LogError("La carpeta especificada no existe: " + path);
        }
    }

    Texture2D LoadTexture(string filePath)
    {
        byte[] fileData = File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(2, 2);
        if (texture.LoadImage(fileData))
            return texture;
        return null;
    }

    private void Update()
    {
        if (sprites.Count == 0) return; // Si no hay imágenes, salir

        timer += Time.deltaTime;
        if (timer >= frameDuration)
        {
            timer = 0f; // Reiniciar el temporizador
            targetImage.sprite = sprites[currentIndex]; // Mostrar sprite actual
            currentIndex = (currentIndex + 1) % sprites.Count; // Avanzar y hacer loop
        }
    }
}
