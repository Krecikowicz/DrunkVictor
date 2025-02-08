using UnityEngine;

public class MCTeleporter : MonoBehaviour
{
    public float teleportInterval = 5f; // Time between teleports
    public GameObject[] teleportLocations; // Array of empty GameObjects for teleport locations

    private float timer;

    private void Start()
    {
        timer = teleportInterval;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Teleport();
            timer = teleportInterval;
        }
    }

    private void Teleport()
    {
        if (teleportLocations.Length > 0)
        {
            int randomIndex = Random.Range(0, teleportLocations.Length);
            if (teleportLocations[randomIndex] != null)
            {
                transform.position = teleportLocations[randomIndex].transform.position;
                Debug.Log("Enemy teleported to: " + teleportLocations[randomIndex].name);
            }
        }
    }
}