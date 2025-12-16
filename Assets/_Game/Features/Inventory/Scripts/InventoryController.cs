using Features.Items;
using Managers;
using System.Collections.Generic;
using UnityEngine;

namespace Features.Inventory {
    public class InventoryController {
        private List<InventorySlot> items;
        public InventoryController() {
            Initialize();
        }
        public void Initialize() {
            items = new List<InventorySlot>();
            List<ItemData> itemsData = ItemsAssetManager.Instance.ItemsList.items;
            for (int i = 0; i < itemsData.Count; i++) {
                items.Add(new InventorySlot(i, itemsData[i], 0));
            }

        }
    }
}