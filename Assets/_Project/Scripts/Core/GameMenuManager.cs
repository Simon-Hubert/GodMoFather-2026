using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    
    public void Replay()
    {
        SceneManager.LoadSceneAsync("TestsSimon");
    }

    public void QuitGame()
    {
        Application.Quit(); // Ne fonctionne qu'en build
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
    }

}
