using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Features.Items.Data {
    [CreateAssetMenu(menuName = "Monkeaholic/Items/Consumable")]
    public class ConsumableData : ItemData {
        [Header("Consumable General")]
        public float healthRestoreAmount = 25f;
        public bool removeDebuffs = true;
    }
}