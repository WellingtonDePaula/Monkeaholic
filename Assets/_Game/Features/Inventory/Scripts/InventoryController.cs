using Features.Items;
using Managers;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Features.Inventory {
    public class InventoryController {

        public List<InventorySlot> slots { get; private set; }

        public event Action OnInventoryChanged;

        public InventoryController() {
            Initialize();
        }

        public void Initialize() {
            slots = new List<InventorySlot>();

            if (ItemsAssetManager.Instance == null)
                return;

            List<ItemData> itemsData = ItemsAssetManager.Instance.ItemsList.items;
            for (int i = 0; i < itemsData.Count; i++) {

                slots.Add(new InventorySlot(i, itemsData[i], 0));
            }
        }

        public void AddItemQuantity(string itemId, int amount) {
            var slot = slots.Find(slot => slot.Item.id == itemId);
            if (slot != null) {
                slot.AddQuantity(amount);

                OnInventoryChanged?.Invoke();
            }
        }
    }
}