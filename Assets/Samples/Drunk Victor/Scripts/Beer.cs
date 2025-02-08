using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class Beer : MonoBehaviour
{

    public XRNode controllerNode; 
    public Slider slider;

    private InputDevice device;
    private bool isPressingButton = false;

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

        bool buttonPressed = false;
        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out buttonPressed) && buttonPressed)
        {
            if (!isPressingButton) 
            {
                isPressingButton = true;
                IncreaseSliderValue();
            }
        }
        else
        {
            isPressingButton = false;
        }
    }

    public void Destroyy()
    {
        Destroy(gameObject);
    }

    void IncreaseSliderValue()
    {
        if (slider.value < slider.maxValue)
        {
            slider.value += 10f; 
        }
    }

}
