using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionController : Singleton<SessionController>
{
    private static int playerLives = 5;
    private static int playerCoins = 0;
    [SerializeField] private float timeToReload = 0f;

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
    }

    // Reset player coins
    public void ResetPlayerCoins()
    {
        playerCoins = 0;
    }

    // Increase player coins
    public void IncreasePlayerCoins()
    {
        playerCoins++;
        Debug.Log("Player coins: " + playerCoins);
    }
    
}
