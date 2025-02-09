using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.SceneManagement;

public class PlateInteraction : MonoBehaviour
{
    public TMP_Text textBox; // Reference to the TextMeshPro UI element
    public float pushForce = 5f; // Force to push the plate away

    private XRGrabInteractable grabInteractable;
    private Rigidbody plateRigidbody;

    void Start()
    {
        // Get the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Get the Rigidbody component
        plateRigidbody = GetComponent<Rigidbody>();

        // Subscribe to the grab event
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // Remove Freeze Position constraints
        plateRigidbody.constraints = RigidbodyConstraints.None;

        // Push the plate away
        Vector3 pushDirection = (transform.position - args.interactorObject.transform.position).normalized;
        plateRigidbody.AddForce(pushDirection * pushForce, ForceMode.Impulse);

        // Change the text in the TextMeshPro textbox
        if (textBox != null)
        {
            textBox.text = "Ju¿ PoZiomku...";
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from the event to avoid memory leaks
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
        }
    }

        public void EndGame()
        {
            // Call the LoadSceneAfterDelay method after 5 seconds
            Invoke("LoadSceneAfterDelay", 5f);
        }

        private void LoadSceneAfterDelay()
        {
            SceneManager.LoadSceneAsync(5); // Load scene with index 2
        }
    }