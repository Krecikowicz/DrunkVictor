using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WhiteLadyMovement : MonoBehaviour
{
    public Transform player;
    public Transform camTransform;
    public float speed = 2f;
    public float stopDistance = 2f;


    void Start()
    {
        camTransform = Camera.main.transform;
    } 


    void Update()
    {

        if (player == null)
        {
            Debug.LogWarning("Brak przypisanego gracza! Ustaw obiekt XR Rig lub kamerę w Inspectorze.");
            return;
        }

        transform.LookAt(transform.position + camTransform.forward);

        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= stopDistance)
        {
            //EndGame2();
            return;
        }

    }

    public void EndGame2()
    {
        SceneManager.LoadSceneAsync(2);
    }

}
