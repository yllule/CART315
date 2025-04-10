using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    public InventoryItem itemData;

    public void Interact()
    {
        InventorySystem.Instance.PickUpItem(itemData);
        Destroy(gameObject);
    }

    public string GetDescription()
    {
        return "Press E to pick up";
    }
}
