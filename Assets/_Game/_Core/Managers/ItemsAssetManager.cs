using Features.Items;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Managers {
    public class ItemsAssetManager : MonoBehaviour {
        public static ItemsAssetManager Instance { get; private set; }
        public ItemsList ItemsList;

        private void Awake() {
            if (Instance != null && Instance != this) {
                Destroy(gameObject);
            } else {
                Instance = this;
            }
        }
    }
}
