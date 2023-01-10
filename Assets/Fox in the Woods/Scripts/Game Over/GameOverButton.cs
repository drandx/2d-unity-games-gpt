using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverButton : MonoBehaviour
{
    SessionController sessionController;

    // Get Session Controller component
    void Start() {
        sessionController = FindObjectOfType<SessionController>();
    }

   public void OnButtonClick() {
        Debug.Log("*** Loading Scene 1 ***");
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        sessionController.ResetPlayerLives();
   }
}
