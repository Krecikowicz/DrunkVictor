using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using Unity.VisualScripting;


public class DrunkMeter : MonoBehaviour
{
    public GameObject whiteLady;
    public Slider slider;
    public float decayRate = 0.8f;

    [Range (0, 50)] public float sliderValue;



    void Update()
    { 
        sliderValue -= Time.deltaTime * decayRate;

        //Debug.Log("Slider value before decay: " + slider.value);
        slider.value = sliderValue;
        //Debug.Log("Slider value after decay: " + slider.value);


        WhiteLadyAppearance();
        WhiteLadyDisappearance();

    }

    public void WhiteLadyAppearance()
    {
        if (sliderValue > 30)
        {
            whiteLady.SetActive(true);
        }
    }

    public void WhiteLadyDisappearance()
    {
        if (sliderValue < 30)
        {
            whiteLady.SetActive(false);
        }
    }


}
