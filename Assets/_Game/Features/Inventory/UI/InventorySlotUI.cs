using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Features.Inventory {
    public class InventorySlotUI : MonoBehaviour {
        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI quantityText;

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
    }
}