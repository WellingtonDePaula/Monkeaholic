using Features.Items.Data;
using Features.Player;
using UnityEngine;

namespace Features.Items.Behaviours {
    public class ThrowBehaviour : ItemBehaviour {
        private WeaponData weaponData;
        private float currentForce = 0f;


        private bool isCharging = false;

        public override void Setup(PlayerStateMachine player, ItemData data) {
            base.Setup(player, data);
            weaponData = (WeaponData) itemData;
        }
        public override void OnUseDown() {
            isCharging = true;
        }

        private void FixedUpdate() {
            Charge();
        }

        public override void OnUseUp() {
            Throw();
        }

        private void Charge() {
            if (!isCharging) return;
            Debug.Log($"Charging... : {currentForce}");
            currentForce += Time.fixedDeltaTime * weaponData.MaxForce;
            currentForce = Mathf.Min(currentForce, weaponData.MaxForce);
        }

        private void Throw() {
            isCharging = false;
            GameObject projectile = Instantiate(weaponData.projectilePrefab, owner.transform.position, Quaternion.identity);
            projectile.GetComponent<ProjectileController>().Launch(currentForce, owner.AimDirection.Value, weaponData.Damage);
            currentForce = 0f;
        }
    }
}
