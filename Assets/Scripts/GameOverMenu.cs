using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public void RetryButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

