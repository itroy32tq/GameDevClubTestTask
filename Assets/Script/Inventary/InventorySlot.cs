using Script.Interfaces;
using Script.ItemSpace;
using System;

namespace Script.Inventoty
{
    public class InventorySlot : IInventorySlot
    {
        public bool IsFull => !IsEmpty && Amount >= Capacity;
        public bool IsEmpty => Item == null;
        public Item Item { get; private set; }
        public Type ItemType => Item.Type;
        public int Amount => IsEmpty ? 0 : Item.State.Amount;
        public int Capacity { get; set; }
        public string ItemId => Item.Info.Id;
        public void Clear()
        {
            if (IsEmpty)
                return;
            Item.State.Amount = 0;
            Item = null;
        }
        public void SetItem(Item item)
        {
            if (!IsEmpty)
                return;
            Item = item;

            Capacity = Item.Info.MaxItemsInInventarySlot;
        }
    }
}
