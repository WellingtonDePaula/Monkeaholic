using UnityEngine;
using System.Collections.Generic;
using Features.Player;
using Unity.Netcode;
using Managers;
using UnityEngine.UI;

namespace Features.Inventory {
    public class InventoryUI : MonoBehaviour {

        public static InventoryUI Instance;

        [Header("UI References")]
        [SerializeField] private InventorySlotUI slotPrefab;
        [SerializeField] private Transform containerGrid;

        [SerializeField] private GameObject contentPanel;

        private InventoryController cachedInventory;
        private List<InventorySlotUI> spawnedSlots = new List<InventorySlotUI>();

        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(gameObject);
            } else {
                Instance = this;
            }
            if(contentPanel != null) {
                contentPanel.SetActive(false);
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
            ClearSlotsUI();

            foreach (InventorySlot dataSlot in cachedInventory.slots) {
                InventorySlotUI newUI = Instantiate(slotPrefab, containerGrid);
                newUI.UpdateView(dataSlot);

                // Adiconando listener de seleção de item
                newUI.SetupClickAction(() => cachedInventory.SelectItem(dataSlot.SlotIndex));

                spawnedSlots[dataSlot.SlotIndex] = newUI;
            }

            cachedInventory.OnItemSelected += HighlightSelectedSlot;
        }

        private void ClearSlotsUI() {
            foreach (Transform child in containerGrid) {
                Destroy(child.gameObject);
            }
            spawnedSlots.Clear();
            for (int i = 0; i < ItemsAssetManager.Instance.ItemsList.items.Count; i++) {
                spawnedSlots.Add(null);
            }
        }

        private void HighlightSelectedSlot(InventorySlot selected) {
            for (int i = 0; i < cachedInventory.slots.Count; i++) {
                // Se o index do dado for igual ao selecionado, ativa o visual
                spawnedSlots[i].SetSelected(cachedInventory.slots[i] == selected);
            }
        }

        public void ToggleVisibility() {
            if (contentPanel != null) {
                bool isActive = contentPanel.activeSelf;
                contentPanel.SetActive(!isActive);
            }
        }

        private void OnDestroy() {
            if (cachedInventory != null) {
                cachedInventory.OnInventoryChanged -= RedrawUI;
            }
        }
    }
}