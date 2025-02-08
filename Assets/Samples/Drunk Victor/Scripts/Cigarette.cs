using UnityEngine;
using UnityEngine.XR;
using Unity.VisualScripting;
using System.Collections;

public class Cigarette : MonoBehaviour
{
    public XRNode controllerNode;
    public InputDevice device;
    public GameObject smoke;
    

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
        Smoking();
        Destroy(gameObject);
    }

    void Smoking()
    {
        smoke.SetActive(true);
        StartCoroutine(SmokeTime(5f));
    } 

    IEnumerator SmokeTime(float duration)
    {
        yield return new WaitForSeconds(duration);
    }

    
}
