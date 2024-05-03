using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeWritterEffect : MonoBehaviour
{
    // Referencja do obiektu TextMeshProUGUI, w którym zostanie wyświetlony tekst
    public TextMeshProUGUI textMeshPro;

    // Tekst, który ma być wyświetlony literka po literce
    public string textToType;

    // Przycisk, który dodaje jedną literkę do wyświetlanego tekstu
    public Button nextLetterButton;

    // Indeks bieżącej litery w tekście, który ma być wyświetlony
    private int currentIndex = 0;

    private void Start()
    {
        // Przypisanie funkcji `ShowNextLetter` do zdarzenia kliknięcia przycisku
        nextLetterButton.onClick.AddListener(ShowNextLetter);
    }

    // Funkcja, która wyświetla kolejną literkę w tekście
    private void ShowNextLetter()
    {
        // Sprawdź, czy nadal są litery do wyświetlenia
        if (currentIndex < textToType.Length)
        {
            // Dodaj kolejną literkę do wyświetlanego tekstu
            textMeshPro.text += textToType[currentIndex];

            // Zwiększ indeks bieżącej litery
            currentIndex++;
        }
    }
}
