using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

namespace Features.Items.Data {
    [CreateAssetMenu(menuName = "Monkeaholic/Items/Weapon")]
    public class WeaponData : ItemData {
        [Header("Weapon General")]
        public float Damage = 10f;
        public float ExplosionRadius = 3f;
        public float MaxForce = 5f;
        public bool IsMelee = false;
        public GameObject prefab;
    }
}
