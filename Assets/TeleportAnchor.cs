using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class TeleportAnchor : MonoBehaviour
{
    public Transform teleportDestination; // The destination where the player will teleport
    public XRRayInteractor rayInteractor; // The ray interactor used for pointing
    public ActionBasedController xrController; // The VR controller (ActionBasedController)

    private bool isPointingAtAnchor = false;

    void Update()
    {
        // Check if the ray is pointing at this object
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                isPointingAtAnchor = true;
            }
            else
            {
                isPointingAtAnchor = false;
            }
        }

        // Check for button press to teleport
        if (isPointingAtAnchor && xrController.activateAction.action.triggered)
        {
            TeleportPlayer();
        }
    }

    void TeleportPlayer()
    {
        // Teleport the player to the destination
        XROrigin xrOrigin = FindObjectOfType<XROrigin>();
        if (xrOrigin != null)
        {
            xrOrigin.MoveCameraToWorldLocation(teleportDestination.position);
            xrOrigin.MatchOriginUp(teleportDestination.up);
        }
    }
}