using Script.Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.UI
{
    public class UIInventorySlot : UISlot
    {
        [SerializeField] private UIInventoryItem _uiInventoryItem;
        public IInventorySlot Slot { get; private set; }

        private UIInventory _uiInventory;

        private void Awake()
        {
            _uiInventory = GetComponentInParent<UIInventory>();
        }
        public void SetSlot(IInventorySlot newSlot)
        {
            Slot = newSlot;
        }

        public override void OnDrop(PointerEventData eventData)
        {
            var otherSlotUI = eventData.pointerDrag.GetComponentInParent<UIInventorySlot>();
            var otherSlot = otherSlotUI.Slot;
            var inventory = _uiInventory.InventoryModel;

            inventory.TransitFromSlotToSlot(this, otherSlot, Slot);
            Refresh();
            otherSlotUI.Refresh();
        }

        public void Refresh()
        {
            if (Slot != null)
                _uiInventoryItem.Refrash(Slot);
        }
    }
}
