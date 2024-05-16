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
            SceneNumber.text = "LEVEL 1";
        }
        else{
        SceneNumber.text = "LEVEL " + currentSceneIndex.ToString();
        }
    }
}
