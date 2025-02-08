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
        // Store the initial Y position of the drone
        startY = transform.position.y;
    }

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Brak przypisanego gracza! Ustaw obiekt XR Rig lub kamerę w Inspectorze.");
            return;
        }

        // Set the target position to the player's X and Z position, but keep the Y position constant
        Vector3 targetPosition = new Vector3(player.position.x, startY, player.position.z);

        // Calculate the direction to move towards the target position
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Move the drone towards the target position
        transform.position += direction * speed * Time.deltaTime;

        // Calculate the horizontal distance between the drone and the player (ignoring Y)
        float distance = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                                          new Vector3(player.position.x, 0, player.position.z));

        // If the drone is close enough to the player, stop moving and trigger the end game logic
        if (distance <= stopDistance)
        {
            EndGame();
            return;
        }
    }

    public void EndGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
}

