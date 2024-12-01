using UnityEngine.UI;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    private int playerMaxhealth;
    public Text Health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Object.FindFirstObjectByType<GameManager>().isGameActive==false){
            return;
        }
        playerMaxhealth = Object.FindFirstObjectByType<Player>().maxHealth;
        Health.text = playerMaxhealth.ToString();
    }
}
