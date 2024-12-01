using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    public void PlayButton(){
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitButton(){
        Application.Quit();
    }
}
