using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ObjectSwapper : MonoBehaviour
{
    [Header("Object Settings")]
    public GameObject objectA; // The object you grab
    public GameObject objectB; // The object that will be replaced
    public GameObject objectC; // The object that will replace Object B

    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        // Ensure Object C is initially disabled
        if (objectC != null)
        {
            objectC.SetActive(false);
        }

        // Get the XRGrabInteractable component from Object A
        grabInteractable = objectA.GetComponent<XRGrabInteractable>();

        // Subscribe to the grab event
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
        }
        else
        {
            Debug.LogError("XRGrabInteractable component not found on Object A.");
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // Check if Object B and Object C are assigned
        if (objectB == null || objectC == null)
        {
            Debug.LogError("Object B or Object C is not assigned.");
            return;
        }

        // Disable Object B
        objectB.SetActive(false);

        // Enable and position Object C in place of Object B
        objectC.SetActive(true);
        objectC.transform.position = objectB.transform.position;
        objectC.transform.rotation = objectB.transform.rotation;

        // Optionally, make Object C grabbable
        XRGrabInteractable replacementGrab = objectC.GetComponent<XRGrabInteractable>();
        if (replacementGrab == null)
        {
            replacementGrab = objectC.AddComponent<XRGrabInteractable>();
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event to avoid memory leaks
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
        }
    }
}