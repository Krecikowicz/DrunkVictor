using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class Beer : MonoBehaviour
{

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

        if (slider.value < slider.maxValue)
        {
            slider.value += 10f;
            Debug.Log("BEER");

        }
    }

}
