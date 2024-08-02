
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void ContinueGame() // ne marche pas pour l'instant, doit explorer comment passer mes chunks/sets mais surtout leur position
    {
        SceneManager.LoadScene("Game");
    }
    public void NewGame()
    {
        GameController.instance.Reset();
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()

    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
