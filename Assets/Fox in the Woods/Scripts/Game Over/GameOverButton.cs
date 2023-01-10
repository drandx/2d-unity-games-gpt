using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverButton : MonoBehaviour
{
   public void OnButtonClick() {
        Debug.Log("*** Loading Scene 1 ***");
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
   }
}
