using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DroneMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public float startY;
    public float stopDistance = 2f;

    private void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Brak przypisanego gracza! Ustaw obiekt XR Rig lub kamerę w Inspectorze.");
            return;
        }

        Vector3 targetPosition = new Vector3(player.position.x, startY, player.position.z);
        Vector3 direction = (targetPosition - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;

        float distance = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                                          new Vector3(player.position.x, 0, player.position.z));

        if (distance <= stopDistance)
        {
            EndGame();
            return;
        }
    }

    public void EndGame()
    {
        SceneManager.LoadSceneAsync(3);
    }
}

