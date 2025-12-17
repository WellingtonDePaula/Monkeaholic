using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;
namespace Features.Inventory {
    public class InventorySlotUI : MonoBehaviour {
        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI quantityText;
        [SerializeField] private EventTrigger eventTrigger;

        public void UpdateView(InventorySlot slot) {
            if (slot == null || slot.Item == null) {
                iconImage.sprite = null;
                iconImage.enabled = false;
                quantityText.text = "";
                return;
            }

            iconImage.enabled = true;
            iconImage.sprite = slot.Item.icon;

            quantityText.text = slot.Quantity.ToString();
        }

        public void SetSelected(bool isSelected) {

        }

        public void SetupClickAction(Action onClickAction) {
            eventTrigger.triggers.Clear();

            // 1. Cria uma nova entrada de evento
            EventTrigger.Entry entry = new EventTrigger.Entry();

            // 2. Define que o tipo de evento é o Clique (PointerClick)
            entry.eventID = EventTriggerType.PointerClick;

            // 3. Adiciona a sua lambda ao callback
            entry.callback.AddListener((eventData) => {
                onClickAction();
            });

            // 4. Adiciona a entrada ao componente
            eventTrigger.triggers.Add(entry);
        }
    }
}