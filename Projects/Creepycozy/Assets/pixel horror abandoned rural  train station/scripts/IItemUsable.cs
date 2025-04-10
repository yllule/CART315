public interface IItemUsable
{
    bool CanUseItem(InventoryItem item);
    void UseItem(InventoryItem item);
    string GetUsePrompt();
}
