using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Poziom")) // Sprawdzamy, czy uderzył gracza
        {
            SceneManager.LoadSceneAsync(5);
        }
    }

}
