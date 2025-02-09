using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTeleportAndDropBrick : MonoBehaviour
{
    public GameObject enemy; // Reference to the enemy GameObject
    public GameObject brickPrefab; // Reference to the brick prefab
    public GameObject[] emptyObjects; // Array to store references to empty GameObjects (target teleport positions)
    public float dropDistance = 2f; // Distance in front of the enemy to drop the brick
    public float teleportCooldown = 3f; // Cooldown before the next teleport

    private void Start()
    {
        StartCoroutine(TeleportAndDropRoutine());
    }

    private IEnumerator TeleportAndDropRoutine()
    {
        while (true)
        {
            TeleportEnemy();
            DropBrick();

            // Wait for the cooldown before teleporting again
            yield return new WaitForSeconds(teleportCooldown);
        }
    }

    private void TeleportEnemy()
    {
        // Check if we have any empty objects in the array
        if (emptyObjects.Length == 0)
        {
            Debug.LogWarning("No empty objects assigned for teleportation.");
            return;
        }

        // Select a random empty object from the array
        int randomIndex = Random.Range(0, emptyObjects.Length);
        Vector3 teleportPosition = emptyObjects[randomIndex].transform.position;

        // Teleport the enemy to the selected empty object
        enemy.transform.position = new Vector3(teleportPosition.x, enemy.transform.position.y, teleportPosition.z);
    }

    private void DropBrick()
    {
        // Calculate the position in front of the enemy
        Vector3 dropPosition = enemy.transform.position + enemy.transform.forward * dropDistance;

        // Instantiate the brick prefab at the drop position
        Instantiate(brickPrefab, dropPosition, Quaternion.identity);
    }
}
