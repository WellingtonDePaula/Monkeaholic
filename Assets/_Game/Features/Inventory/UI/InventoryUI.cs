using UnityEngine;
using System.Collections.Generic;
using Features.Player;
using Unity.Netcode;

namespace Features.Inventory {
    public class InventoryUI : MonoBehaviour {

        public static InventoryUI Instance;

        [Header("UI References")]
        [SerializeField] private InventorySlotUI slotPrefab;
        [SerializeField] private Transform containerGrid;

        private InventoryController cachedInventory;
        private List<InventorySlotUI> spawnedSlots = new List<InventorySlotUI>();

        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(gameObject);
            } else {
                Instance = this;
            }
        }

        public void InitializeInventoryUI(InventoryController inventory) {
            if (cachedInventory != null) {
                return;
            }

            cachedInventory = inventory;

            cachedInventory.OnInventoryChanged += RedrawUI;

            RedrawUI();
        }

        private void RedrawUI() {
            foreach (Transform child in containerGrid) {
                Destroy(child.gameObject);
            }
            spawnedSlots.Clear();

            foreach (var dataSlot in cachedInventory.items) {
                InventorySlotUI newUI = Instantiate(slotPrefab, containerGrid);
                newUI.UpdateView(dataSlot);
                spawnedSlots.Add(newUI);
            }
        }

        private void OnDestroy() {
            if (cachedInventory != null) {
                cachedInventory.OnInventoryChanged -= RedrawUI;
            }
        }
    }
}