using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach = 10f;
    Interactable currentInteractable;

    void Update()
    {
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.F) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    void CheckInteraction()
    {
        if (Camera.main == null) return;
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        
        if (Physics.Raycast(ray, out hit, playerReach))
        {
            if (hit.collider.tag == "Interactable")
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                if (newInteractable != null)
                {
                    if (currentInteractable != null && newInteractable != currentInteractable)
                    {
                        currentInteractable.DisableOutline();
                    }

                    if (newInteractable.enabled)
                    {
                        SetNewCurrentInteractable(newInteractable);
                    }
                    else
                    {
                        DisableCurrentInteractable();
                    }
                }
            }
        }
        else
        {
            DisableCurrentInteractable();
        }
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
    }

    void DisableCurrentInteractable()
    {
        if (currentInteractable != null)
        {
            currentInteractable.DisableOutline();
            currentInteractable = null;
        }
    }
}
