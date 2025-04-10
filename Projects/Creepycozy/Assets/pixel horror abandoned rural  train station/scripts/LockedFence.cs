using UnityEngine;

public class LockedFence : MonoBehaviour, IItemUsable
{
    public InventoryItem requiredItem;

    public bool CanUseItem(InventoryItem item)
    {
        return item == requiredItem;
    }

    public void UseItem(InventoryItem item)
    {
        if (item == requiredItem)
        {
            Debug.Log("Fence unlocked!");
            // Add animation or disable collider etc.
            Destroy(gameObject);
            InventorySystem.Instance.ClearItem(); // Remove item after use
        }
    }

    public string GetUsePrompt()
    {
        return "Press E to unlock";
    }
}
