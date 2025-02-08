using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using Unity.VisualScripting;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using System.Collections;


public class DrunkMeter : MonoBehaviour
{
    public GameObject whiteLady;
    public Slider slider;
    public float decayRate = 0.8f;

    public DynamicMoveProvider moveProvider;
    private int lastSpeedChange = 50;


    [Range (0, 50)] public float sliderValue;



    void Update()
    { 
        sliderValue -= Time.deltaTime * decayRate;

        //Debug.Log("Slider value before decay: " + slider.value);
        slider.value = sliderValue;

        AdjustSpeedBasedOnSlider();

        //Debug.Log("Slider value after decay: " + slider.value);


        WhiteLadyAppearance();
        WhiteLadyDisappearance();

    }

    public void AdjustSpeedBasedOnSlider()
    {
        int currentThreshold = Mathf.FloorToInt(sliderValue / 10) * 10; // Znajdowanie najbliższego progu 10, 20, 30...

        if (currentThreshold < lastSpeedChange) // Jeśli osiągnęliśmy nowy niższy próg
        {
            moveProvider.moveSpeed = Mathf.Clamp(moveProvider.moveSpeed - 1, 2.5f, 10); // Zmniejszamy speed, ale nie schodzimy poniżej 1
            lastSpeedChange = currentThreshold; // Aktualizujemy ostatni zmieniony próg
            Debug.Log("Nowa prędkość: " + moveProvider.moveSpeed);
        }
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
