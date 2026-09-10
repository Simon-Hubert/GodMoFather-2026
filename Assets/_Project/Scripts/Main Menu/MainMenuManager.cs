using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    


    public void StartGame()
    {
        SceneManager.LoadScene("TestsSimon");
    }

    public void QuitGame()
    {
        Application.Quit(); // Ne fonctionne qu'en build
        EditorApplication.ExitPlaymode();
    }

}
