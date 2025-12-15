using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Features.Items {
    [CreateAssetMenu(menuName = "Monkeaholic/Items/Consumable")]
    public class ConsumableData : ItemData {
        [Header("Efeito")]
        public float healthRestoreAmount = 25f;
        public bool removeDebuffs = true;
    }
}