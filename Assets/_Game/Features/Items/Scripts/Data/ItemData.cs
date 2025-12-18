using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Features.Items.Data {
    public abstract class ItemData : ScriptableObject {
        [Header("Item General")]
        public string id;
        public string displayName;
        public Sprite icon;
        public GameObject ItemPrefab;
        [TextArea] public string description;
    }
}
