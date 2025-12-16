using System.Collections.Generic;
using UnityEngine;

namespace Features.Inventory {
    public class InventoryController : MonoBehaviour {
        public int Width { get; private set; }
        public int Height { get; private set; }
        private InventorySlot[,] items;
        public void Initialize() {
            items = new InventorySlot[Width, Height];
        }
    }
}