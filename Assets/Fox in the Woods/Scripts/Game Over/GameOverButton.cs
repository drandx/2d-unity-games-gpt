using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverButton : MonoBehaviour
{
   public void OnButtonClick() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        SessionController sessionController = FindObjectOfType<SessionController>();
        sessionController.ResetGameSession();
   }
}
