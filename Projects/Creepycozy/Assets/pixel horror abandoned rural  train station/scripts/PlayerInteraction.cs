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

    void InteractionRay()
    {
        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            IItemUsable usable = hit.collider.GetComponent<IItemUsable>();

            if (interactable != null)
            {
                interactionUI.SetActive(true);
                interactionText.text = interactable.GetDescription();

                if (Input.GetKeyDown(KeyCode.E))
                    interactable.Interact();

                return;
            }

            //only show prompt if player is holding an item and its usable
            if (usable != null && InventorySystem.Instance.HasItem())
            {
                var heldItem = InventorySystem.Instance.GetCurrentItem();

                if (usable.CanUseItem(heldItem))
                {
                    interactionUI.SetActive(true);
                    interactionText.text = usable.GetUsePrompt();

                    if (Input.GetKeyDown(KeyCode.E))
                        usable.UseItem(heldItem);

                    return;
                }
            }
        }

        interactionUI.SetActive(false);
    }
}