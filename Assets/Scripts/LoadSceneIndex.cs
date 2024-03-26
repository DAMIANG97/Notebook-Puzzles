using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneIndex : MonoBehaviour
{

    private TextMeshProUGUI SceneNumber;
    void Start()
    {

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneNumber = GameObject.Find("SceneNumber").GetComponent<TextMeshProUGUI>();
        SceneNumber.text = currentSceneIndex.ToString();
    }
}
