
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public static bool isPaused=false;
    public GameObject pauseMenuUi;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else { PauseGame(); }
        }
    }

    public void Menu()
    {
        Resume();
        SceneManager.LoadScene("Menu");
        
    }

    public void Quit()
    {
        Debug.Log("Exiting Application");
        Application.Quit();
    }

    public void Resume()
    {
        isPaused = false;
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    { 
        isPaused = true;
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
    }
}


