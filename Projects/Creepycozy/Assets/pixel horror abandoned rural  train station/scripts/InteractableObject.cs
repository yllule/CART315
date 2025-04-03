using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        // Debug.Log("Item picked up!");
        Destroy(gameObject);  //destroys the object on interaction
    }

    public string GetDescription()
    {
        return "Press E to pick up";
    }
}
