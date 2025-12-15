using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Features.Items {
    [CreateAssetMenu(menuName = "Monkeaholic/Items/Weapon")]
    public class WeaponData : ItemData {
        [Header("Combate")]
        public float damage = 10f;
        public float explosionRadius = 3f;
        public GameObject projectilePrefab;
        public bool isMelee = false;
    }
}
