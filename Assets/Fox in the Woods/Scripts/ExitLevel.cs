using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    [SerializeField] float timeToReload = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("LoadNextSceneWithDelay");
        }
    }

    // Method to load the next scene with a timeout
    IEnumerator LoadNextSceneWithDelay()
    {
        yield return new WaitForSeconds(timeToReload);
        // Get current scene index
        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        // If current scene is the last one, load the first one
        // 2 is the number of scenes in the build settings that are not levels (GameOver, Snow Board Game)
        if (currentSceneIndex == UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings - 2)
        {
            Debug.Log("Reset Game Session");
            FindObjectOfType<SessionController>().ResetGameSession();
        } else {
            UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneIndex + 1);
        }        
    }
}
