using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionController : MonoBehaviour
{
    private int playerLives = 5;
    private int playerCoins = 0;
    [SerializeField] private float timeToReload = 0f;
    // Serialized field for text from TMPro
    [SerializeField] private TMPro.TextMeshProUGUI playerLivesText;
    [SerializeField] private TMPro.TextMeshProUGUI playerCoinsText;   

    // Assign the player lives and coins to the text
    private void Start()
    {
        playerLivesText.text = playerLives.ToString();
        playerCoinsText.text = playerCoins.ToString();
    }

    void Awake()
    {
        int numGameSessions = FindObjectsOfType<SessionController>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    // Get the player lives
    public int GetPlayerLives()
    {
         return playerLives;
    }

    //Decrease the player lives
    public void DecreasePlayerLives()
    {
        //Print the player lives
        Debug.Log("Player lives: " + playerLives);
        playerLives--;
        //If the player lives are less than 0, reload the scene
        if (playerLives > 0)
        {
            StartCoroutine("ReloadCurrentScene");
        } else {
            //If the player lives are less than 0, load the game over scene
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
        //Assign the player lives to the text
        playerLivesText.text = playerLives.ToString();
    }

    // Reload current scene
    IEnumerator ReloadCurrentScene()
    {
        yield return new WaitForSeconds(timeToReload);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    // Reset player lives
    public void ResetPlayerLives()
    {
        playerLives = 5;
        //Assign the player lives to the text
        playerLivesText.text = playerLives.ToString();
    }

    // Reset player coins
    public void ResetPlayerCoins()
    {
        playerCoins = 0;
        //Assign the player coins to the text
        playerCoinsText.text = playerCoins.ToString();
    }

    // Increase player coins
    public void IncreasePlayerCoins()
    {
        //Print instance id
        Debug.Log("Instance ID: " + GetInstanceID());
        Debug.Log("Player coins: " + playerCoins);
        playerCoins++;
        //Assign the player coins to the text
        playerCoinsText.text = playerCoins.ToString();
    }
    
}
