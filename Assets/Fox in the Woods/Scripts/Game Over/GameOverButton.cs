using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverButton : MonoBehaviour
{
   public void OnButtonClick() {
      UnityEngine.SceneManagement.SceneManager.LoadScene(1);
      FindObjectOfType<SessionController>().ResetGameSession();
      FindObjectOfType<ScenePersist>().ResetScenePersist();
   }
}
