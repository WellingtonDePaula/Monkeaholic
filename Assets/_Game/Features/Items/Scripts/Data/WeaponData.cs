using System;
using System.Collections.Generic;
using System.Text;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

namespace Features.Items.Data {
    [CreateAssetMenu(menuName = "Monkeaholic/Items/Weapon")]
    public class WeaponData : ItemData {
        [Header("Weapon General")]
        [Min(0f)] public float Damage = 10f;
        [Min(0f)] public float MaxForce = 5f;
        public bool IsMelee = false;
        public GameObject prefab;
        [Header("Explosion Config")]
        [Tooltip("If true, will start the delay when fired. If on, will start the delay whenever the projectile hits something")]
        public bool DelayOnThrow = false;
        [Tooltip("The explosion radius")]
        [Min(0f)] public float ExplosionRadius = 0f;
        [Min(0f)] public float ExplosionDamage = 0f;
        [Tooltip("The time in seconds, before the weapon explodes")]
        [Min(0f)] public float ExplosionDelay = 0f;
    }
}
