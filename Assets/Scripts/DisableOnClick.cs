using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DisableOnClick : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        if (image == null)
        {
            Debug.LogError("Image component missing from the object.");
        }
    }

    // Korutyna, która utrzymuje przezroczystość na poziomie 0.6 przez 75% czasu, a następnie zmniejsza ją do 0.001
    private IEnumerator FadeOutAndDisable(float duration)
    {
        float maintainDuration = duration * 0.75f;
        float fadeDuration = duration * 0.25f;
        float startAlpha = 0.6f;
        float endAlpha = 0.001f;

        // Utrzymanie przezroczystości na poziomie 0.6 przez 75% czasu
        image.color = new Color(image.color.r, image.color.g, image.color.b, startAlpha);
        yield return new WaitForSeconds(maintainDuration);

        // Zmniejszanie przezroczystości od 0.6 do 0.001 w ciągu ostatnich 25% czasu
        float rate = 1.0f / fadeDuration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Lerp(startAlpha, endAlpha, progress));
            progress += rate * Time.deltaTime;
            yield return null;
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, endAlpha);
        TurnOff();
    }

    // Funkcja do wyłączenia obiektu
    public void TurnOff()
    {
        gameObject.SetActive(false);
    }

    // Funkcja wywoływana za każdym razem, gdy obiekt jest aktywowany
    private void OnEnable()
    {
        if (image != null)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.6f); // Ustawienie wstępnej przezroczystości przy aktywacji
            StartCoroutine(FadeOutAndDisable(5.0f)); // Uruchamiamy korutynę z czasem trwania 5 sekund
        }
    }
}
