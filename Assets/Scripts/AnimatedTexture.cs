using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedTexture : MonoBehaviour
{
    public float secondsPerNumber = 1.0f;  // Tiempo entre cada número
    public delegate void MyDelegate();
    public MyDelegate onAnimationEnd;
    public Text number;  // Texto UI para mostrar el número de la cuenta regresiva

    private float startTime;
    private int currentNumber;
    private bool countingDown = false;
    public GameObject fotoFinal;

    private void OnEnable()
    {
        startTime = Time.time;
        currentNumber = 5;  // Empezar desde 5
        countingDown = true;
        UpdateText();
    }

    void Update()
    {
        if (countingDown && Time.time - startTime >= secondsPerNumber)
        {
            startTime = Time.time;  // Reiniciar el tiempo
            currentNumber--;  // Decrementar el número

            if (currentNumber >= 1)
            {
                UpdateText();
            }
            else
            {
                onAnimationEnd();
                // transform.GetChild(2).gameObject.SetActive(true);
                countingDown = false;
                //StartCoroutine(launch());

            }
        }
    }

    IEnumerator launch()
    {
        yield return new WaitForSeconds(1);
        transform.GetChild(2).gameObject.SetActive(false);

    }

    private void UpdateText()
    {
        if (number != null)
        {
            number.text = currentNumber.ToString();
        }
    }
}
