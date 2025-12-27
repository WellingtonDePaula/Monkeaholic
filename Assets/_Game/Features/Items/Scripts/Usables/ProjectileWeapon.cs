using Features.Items.Data;
using Features.Player;
using System;
using UnityEngine;

namespace Features.Items.Usables {
    public class ProjectileWeapon : IUsableItem {
        private WeaponData data;
        private PlayerStateMachine ctx;
        private float currentCharge = 0f;
        
        public ProjectileWeapon(WeaponData data) {
            this.data = data;
        }
        public void OnEndUse() {
            ctx.RequestFireServerRpc(currentCharge, ctx.AimDirection.Value, data.id);
            currentCharge = 0f;
            ctx.Inventory.UseSelectedItem();
        }

        public void OnEquip(PlayerStateMachine player) {
            ctx = player;
            Debug.Log($"Equipped weapon: {data.displayName}");
            // Fazer o visual do item equipado aparecer na mão do player
        }

        public void OnStartUse() {
            
        }

        public void OnUnequip() {
            // Remover o visual do item equipado da mão do player
        }

        public void OnUpdateUse() {
            // Implementar carregamento do disparo e atualizar UI de carregamento
            currentCharge = Math.Clamp(currentCharge + Time.deltaTime, 0, data.MaxForce);

        }
    }
}
