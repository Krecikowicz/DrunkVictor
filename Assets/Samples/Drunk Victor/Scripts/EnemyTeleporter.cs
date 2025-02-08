using System.Collections;
using System.Collections.Generic;
using Unity.Hierarchy;
using UnityEngine;

public class EnemyTeleporter : MonoBehaviour
{
    public Transform[] teleportPoints; // Array of teleport points
    public GameObject brickPrefab; // Prefab for the brick to drop
    public float teleportInterval = 5f; // Time between teleports
    public Vector3 offset = new Vector3(5, 0, 0);

    private Vector3 lastPosition; // Store the enemy's position before teleporting

    private void Start()
    {
        lastPosition = transform.position + offset; // Initialize the last position
        StartCoroutine(TeleportRoutine());
    }

    private IEnumerator TeleportRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(teleportInterval);

            // Drop a brick at the last position
            DropBrick(lastPosition);

            // Update the last position to the current position before teleporting
            lastPosition = transform.position + offset;

            // Teleport to a random point
            Transform randomPoint = teleportPoints[Random.Range(0, teleportPoints.Length)];
            transform.position = randomPoint.position;
        }
    }

    private void DropBrick(Vector3 position)
    {
        if (brickPrefab != null)
        {
            Instantiate(brickPrefab, position, Quaternion.identity);
        }
    }
}