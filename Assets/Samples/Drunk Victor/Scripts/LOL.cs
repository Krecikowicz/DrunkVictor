using UnityEngine;

public class LOL : MonoBehaviour
{
    public Rigidbody rigidbodyL;
    public float balanceForce = 10f;

    void OnTriggerStay(Collider other)
    {
        Rigidbody playerBody = other.GetComponent<Rigidbody>();

        if(playerBody != null)
        {
            Vector3 forceDirection = (other.transform.position - transform.position).normalized;
            float distanceFromCentre = Vector3.Dot(forceDirection, transform.right);
            rigidbodyL.AddTorque(transform.forward * balanceForce * distanceFromCentre); 
        }
    }
}
