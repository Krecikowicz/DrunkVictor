using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button DifficultyButton;
    public Button exitButton;

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

}
