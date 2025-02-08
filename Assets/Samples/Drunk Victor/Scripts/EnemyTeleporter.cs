using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeleporter : MonoBehaviour
{
    public Transform[] teleportPoints; // Array of teleport points
    public GameObject brickPrefab; // Prefab for the brick to drop
    public float teleportInterval = 5f; // Time between teleports
    public float brickSpawnDistance = 1f; // Distance in front of the enemy to spawn the brick
    public Vector3 offset = new Vector3(5, 0, 0);

    private Vector3 lastPosition; // To track the last position before teleport

    private void Start()
    {
        lastPosition = transform.position; // Initialize last position
        StartCoroutine(TeleportRoutine());
    }

    private IEnumerator TeleportRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(teleportInterval);

            // Drop a brick in front of the enemy at its LAST position before teleport
            DropBrickInFront();

            // Teleport to a random point AFTER dropping the brick
            Transform randomPoint = teleportPoints[Random.Range(0, teleportPoints.Length)];
            lastPosition = transform.position; // Update the last position before teleport
            transform.position = randomPoint.position;
        }
    }

    private void DropBrickInFront()
    {
        if (brickPrefab != null)
        {
            // Calculate the position in front of the enemy based on the LAST position before teleport
            Vector3 spawnPosition = lastPosition + transform.forward * brickSpawnDistance;

            // Spawn the brick at the calculated position
            GameObject brick = Instantiate(brickPrefab, spawnPosition, Quaternion.identity);

            // Ensure the brick has a Rigidbody for gravity
            Rigidbody brickRigidbody = brick.GetComponent<Rigidbody>();
            if (brickRigidbody == null)
            {
                brickRigidbody = brick.AddComponent<Rigidbody>();
            }

            // Optional: Add a small force to make the brick fall more naturally
            brickRigidbody.AddForce(Vector3.down * 2f, ForceMode.Impulse);
        }
    }
}
