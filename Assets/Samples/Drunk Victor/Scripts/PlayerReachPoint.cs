using UnityEngine;
using TMPro; // Add this namespace for TextMeshPro

public class PlayerReachPoint : MonoBehaviour
{
    public GameObject enemy; // Reference to the enemy GameObject
    public GameObject secondCharacter; // Reference to the second character GameObject
    public GameObject enemyTeleportLocation; // Empty GameObject for enemy's teleport location
    public GameObject secondCharacterTeleportLocation; // Empty GameObject for second character's teleport location
    public TextMeshProUGUI popupText; // Reference to the TextMeshPro UI element

    private void Start()
    {
        // Hide the text initially
        if (popupText != null)
        {
            popupText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the trigger zone
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone.");

            // Teleport the enemy to the empty GameObject's position
            if (enemy != null && enemyTeleportLocation != null)
            {
                enemy.transform.position = enemyTeleportLocation.transform.position;

                // Disable the EnemyTeleporter script
                EnemyTeleporter teleporter = enemy.GetComponent<EnemyTeleporter>();
                if (teleporter != null)
                {
                    teleporter.enabled = false;
                    Debug.Log("Enemy teleported and EnemyTeleporter script disabled.");
                }
                else
                {
                    Debug.LogError("EnemyTeleporter script not found on the enemy GameObject.");
                }
            }

            // Teleport the second character to the empty GameObject's position
            if (secondCharacter != null && secondCharacterTeleportLocation != null)
            {
                secondCharacter.transform.position = secondCharacterTeleportLocation.transform.position;
                Debug.Log("Second character teleported.");
            }

            // Show the popup text
            if (popupText != null)
            {
                popupText.text = "Event Triggered!";
                popupText.gameObject.SetActive(true);
            }

            Debug.Log("Player reached the point. Enemy and second character teleported.");
        }
    }
}