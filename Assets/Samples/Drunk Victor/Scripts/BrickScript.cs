using UnityEngine;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine.UI;



public class BrickScript : MonoBehaviour
{

    public GameObject drunkMeter;
    public Slider slider;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Sprawdzamy, czy uderzył gracza
        {
            Debug.Log("Obiekt spadł na gracza!");
            
            if (slider.value > 0)
            {
                slider.value -= 10f;
            }

        }
    }
}
