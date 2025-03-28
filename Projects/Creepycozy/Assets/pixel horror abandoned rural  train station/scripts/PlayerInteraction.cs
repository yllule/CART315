using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public Camera mainCam;
    public float interactionDistance = 10f;
    public LayerMask interactableLayer;

    public GameObject interactionUI;
    public TextMeshProUGUI interactionText;

    private void Start() {
        interactionUI.SetActive(false);
    }

    private void Update() {
        InteractionRay();
    }

    void InteractionRay() {
        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer)) {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null) {
                interactionUI.SetActive(true);
                interactionText.text = interactable.GetDescription();

                if (Input.GetKeyDown(KeyCode.E)) {
                    interactable.Interact();
                }
                return;
            }
        }
        interactionUI.SetActive(false);
    }
}