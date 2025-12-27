using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Features.Items.Data {
    public abstract class ItemData : ScriptableObject {
        [Header("Item General")]
        public string Id;
        public string DisplayName;
        public Sprite Icon;
        [TextArea] public string description;
        public bool InfinityUse = false;
    }
}
