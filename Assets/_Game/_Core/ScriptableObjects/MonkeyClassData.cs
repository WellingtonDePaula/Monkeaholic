using System.ComponentModel;
using UnityEngine;

namespace Core.ScriptableObjects {
    [CreateAssetMenu(fileName = "newMonkeyClass", menuName = "Monkeaholic/MonkeyClassData", order = 1)]
    public class MonkeyClassData : ScriptableObject {
        [Header("Identificação")]
        public MonkeyClass Class;

        [Header("Atributos Físicos")]
        public float MaxHealth = 50f;
        public float MoveSpeed = 5f;
        public float JumpForce = 10f;

        [Header("Resistências")]
        [Range(0f, 1f)]
        public float knockbackResistance = 0.5f; // 0 = voa longe, 1 = imóvel

        [Header("Equipamento Inicial")]
        public GameObject startingWeaponPrefab;

        public enum MonkeyClass {
            Normal,
            Soldier,
            Rogue,
        }
    }
}