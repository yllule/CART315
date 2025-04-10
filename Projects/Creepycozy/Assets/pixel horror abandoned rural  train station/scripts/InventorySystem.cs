using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;

    public Image heldItemIcon;
    private InventoryItem currentItem;

    public InventoryItem GetCurrentItem() => currentItem;
    public bool HasItem() => currentItem != null;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void PickUpItem(InventoryItem item)
    {
        currentItem = item;
        heldItemIcon.sprite = item.icon;

        Color color = heldItemIcon.color;
        color.a = 1f;
        heldItemIcon.color = color;

        heldItemIcon.enabled = true;
    }

    public void ClearItem()
    {
        currentItem = null;
        heldItemIcon.sprite = null;
        heldItemIcon.enabled = false;
    }
}
