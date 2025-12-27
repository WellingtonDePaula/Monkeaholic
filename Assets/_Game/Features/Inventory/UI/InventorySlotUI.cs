using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;
using System.Xml.Serialization;
namespace Features.Inventory {
    public class InventorySlotUI : MonoBehaviour {
        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI quantityText;
        [SerializeField] private EventTrigger eventTrigger;

        [Header("Hover")]
        [SerializeField] private float defaultScale = 1f;
        [SerializeField] private float hoverScale = 1.1f;
        [SerializeField] private float scaleLerpSpeed = 10f;
        private float currentScale;

        private void Awake() {
            currentScale = defaultScale;
            transform.localScale = Vector3.one * defaultScale;

            AddTrigger(EventTriggerType.PointerEnter, (data) => {
                currentScale = hoverScale;
            });
            AddTrigger(EventTriggerType.PointerExit, (data) => {
                currentScale = defaultScale;
            });
        }

        public void UpdateView(InventorySlot slot) {
            if (slot == null || slot.Item == null) {
                iconImage.sprite = null;
                iconImage.enabled = false;
                quantityText.text = "";
                return;
            }

            iconImage.enabled = true;
            iconImage.sprite = slot.Item.Icon;

            quantityText.text = slot.Quantity.ToString();
        }

        public void SetSelected(bool isSelected) {
            if (isSelected) {
                iconImage.color = Color.yellow; // Exemplo: muda a cor para amarelo quando selecionado
            } else {
                iconImage.color = Color.white; // Cor padrão
            }
        }

        private void FixedUpdate() {
            if(currentScale != transform.localScale.x) {
                float scale = Mathf.Lerp(transform.localScale.x, currentScale, Time.fixedDeltaTime * scaleLerpSpeed);
                transform.localScale = Vector3.one * scale;
            }
        }

        public void AddClickAction(Action onClickAction) {
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

        private void AddTrigger(EventTriggerType type, UnityEngine.Events.UnityAction<BaseEventData> action) {
            EventTrigger.Entry entry = new EventTrigger.Entry { eventID = type };
            entry.callback.AddListener(action);
            eventTrigger.triggers.Add(entry);
        }
    }
}