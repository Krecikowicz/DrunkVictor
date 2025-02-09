using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void NextLevelll()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void NextLevelPoz()
    {
        SceneManager.LoadSceneAsync(4);
    }

    public void NextLevel5()
    {
        SceneManager.LoadSceneAsync(5);
    }

    public void NextLevel6()
    {
        SceneManager.LoadSceneAsync(6);
    }


}
