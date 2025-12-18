using Features.Items.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Features.Inventory {
    public class InventorySlot {
        public int SlotIndex { get; private set; }
        public ItemData Item { get; private set; }
        public int Quantity { get; private set; }
        public InventorySlot(int slotIndex, ItemData item, int quantity) {
            SlotIndex = slotIndex;
            Item = item;
            Quantity = quantity;
        }
        public void AddQuantity(int amount) {
            Quantity += amount;
            if (Quantity < 0)
                Quantity = 0;
        }

        public void RemoveQuantity(int amount) {
            Quantity -= amount;
            if (Quantity < 0)
                Quantity = 0;
        }
    }
}
