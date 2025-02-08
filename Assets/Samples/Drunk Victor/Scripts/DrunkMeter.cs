using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using Unity.VisualScripting;


public class DrunkMeter : MonoBehaviour
{
    public GameObject whiteLady;
    public Slider drunkMeter;
    public float decayRate = 0.1f;


    void Update()
    {
        //if (slider.value > 0)
        //{
            //slider.value -= decayRate * Time.deltaTime;
        //}

        WhiteLadyAppearance();

    }

    public void WhiteLadyAppearance()
    {
        //if (slider.value > 30)
        //{
            //whiteLady.SetActive(true);
        //}
    }


}
