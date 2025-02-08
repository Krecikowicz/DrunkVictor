using UnityEngine;

public class BalancingPlatform : MonoBehaviour
{
    public Transform player; // Gracz w VR
    public Transform secondCharacter; // Druga postaæ wp³ywaj¹ca na fizykê
    public float tiltSpeed = 5f; // Szybkoœæ przechylania
    public float maxTiltAngle = 15f; // Maksymalne przechylenie

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Freeze position and unnecessary rotations
        rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
    }

    void FixedUpdate()
    {
        if (player == null || secondCharacter == null) return;

        // Get the local positions of the player and second character relative to the platform
        Vector3 localPlayerPos = transform.InverseTransformPoint(player.position);
        Vector3 localSecondCharacterPos = transform.InverseTransformPoint(secondCharacter.position);

        // Calculate the tilt based on the X position of the player and second character
        float playerTilt = localPlayerPos.x * tiltSpeed;
        float secondCharacterTilt = localSecondCharacterPos.x * tiltSpeed;

        // Combine the tilts and clamp the result
        float totalTilt = Mathf.Clamp(playerTilt + secondCharacterTilt, -maxTiltAngle, maxTiltAngle);

        // Create a target rotation around the Z-axis
        Quaternion targetRotation = Quaternion.Euler(0, 0, -totalTilt);

        // Smoothly interpolate to the target rotation
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, Time.fixedDeltaTime * tiltSpeed));
    }
}