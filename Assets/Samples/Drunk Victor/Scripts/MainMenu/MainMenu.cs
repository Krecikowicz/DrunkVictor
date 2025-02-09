using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Difficulty()
    {
        //difficulty
    }

    public void StartOver()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
