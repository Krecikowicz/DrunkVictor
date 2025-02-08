using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class Beer : MonoBehaviour
{
    public DrunkMeter drunkMeter;
    public DynamicMoveProvider moveProvider;

    public XRNode controllerNode; 
    public Slider slider;
    public InputDevice device;


    void Start()
    {
        device = InputDevices.GetDeviceAtXRNode(controllerNode);
    }

    void Update()
    {
        if (!device.isValid)
        {
            device = InputDevices.GetDeviceAtXRNode(controllerNode); 
        }

    }

    public void Destroyy()
    {
        Destroy(gameObject);
        IncreaseSliderValue();
    }

    void IncreaseSliderValue()
    {
        Debug.Log("beer");

        if (drunkMeter.sliderValue < 50)
        {
            drunkMeter.sliderValue += 10f;
            Debug.Log("BEER");
            moveProvider.moveSpeed += 1f;

        }
    }

}
