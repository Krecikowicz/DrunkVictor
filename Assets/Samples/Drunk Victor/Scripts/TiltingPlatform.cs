using UnityEngine;

public class TiltingPlatform : MonoBehaviour
{
    public Transform player;
    public float tiltSpeed = 2f;
    public float maxTiltAngle = 15f;

    private Rigidbody rb;
    private Vector3 initialPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        Vector3 localPlayerPos = transform.InverseTransformPoint(player.position);
        float tiltAmount = Mathf.Clamp(localPlayerPos.x * tiltSpeed, -maxTiltAngle, maxTiltAngle);

        Quaternion targetRotation = Quaternion.Euler(new Vector3(tiltAmount, 0, 0));
        rb.MoveRotation(Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * tiltSpeed));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb.AddForceAtPosition(Vector3.down * 10f, collision.contacts[0].point, ForceMode.Impulse);
        }
    }
}

