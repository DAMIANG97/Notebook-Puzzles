using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneIndex : MonoBehaviour
{

    private TextMeshProUGUI SceneNumber;
    void Update()
    {

        int currentSceneIndex = GameManager.currentSceneIndex;
        SceneNumber = GameObject.Find("SceneNumber").GetComponent<TextMeshProUGUI>();
        if(currentSceneIndex==0){
            SceneNumber.text = "1";
        }
        else{
        SceneNumber.text = currentSceneIndex.ToString();
        }
    }
}
