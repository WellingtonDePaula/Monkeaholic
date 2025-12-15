using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Features.Items {
    public abstract class ItemData : ScriptableObject {
        [Header("Geral")]
        public string id;
        public string displayName;
        public Sprite icon;
        [TextArea] public string description;
    }
}
