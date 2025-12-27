using Core.ScriptableObjects;
using Features.Inventory;
using Features.Items.Data;
using Features.Items.Usables;
using Managers;
using Unity.Netcode;
using UnityEngine;

namespace Features.Player {
    public class PlayerStateMachine : NetworkStateManager<PlayerStateMachine.PlayerState> {
        public PlayerMovement Movement { get; private set; }
        public PlayerController Controller { get; private set; }
        public InventoryController Inventory { get; private set; }
        public Rigidbody2D Body { get; private set; }
        public MonkeyClassData Data;

        public IUsableItem CurrentEquipedItem;
        [HideInInspector] public NetworkVariable<Vector2> InputDirection;
        [HideInInspector] public NetworkVariable<Vector2> AimDirection;

        public enum PlayerState {
            #region Basic States

            Idle,
            Moving,
            Jumping,
            Falling,
            OnInventory,
            Aiming,

            #endregion
        }

        public override void OnNetworkSpawn() {
            Movement = new PlayerMovement(this);
            Controller = new PlayerController();
            Inventory = new InventoryController();

            Inventory.OnItemSelected += EquipItem;

            Body = gameObject.GetComponent<Rigidbody2D>();
            States.Add(PlayerState.Idle, new PlayerStateIdle(this));
            States.Add(PlayerState.Moving, new PlayerStateMoving(this));
            States.Add(PlayerState.OnInventory, new PlayerStateOnInventory(this));
            States.Add(PlayerState.Aiming, new PlayerStateAiming(this));

            CurrentState = States[PlayerState.Idle];

            if (IsOwner) {
                if (InventoryUI.Instance != null) {
                    InventoryUI.Instance.InitializeInventoryUI(Inventory);
                }

            }
        }

        private void Awake() {
            InputDirection = new NetworkVariable<Vector2>(Vector2.zero, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
            AimDirection = new NetworkVariable<Vector2>(Vector2.zero, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
        }

        protected override void Update() {
            base.Update();
        }

        protected override void FixedUpdate() {
            base.FixedUpdate();
        }

        private void EquipItem(InventorySlot slot) {
            CurrentEquipedItem?.OnUnequip();
            CurrentEquipedItem = null;

            if (slot == null) { return; }

            if (slot.Item is WeaponData weaponData) {
                CurrentEquipedItem = new ProjectileWeapon(weaponData);
            }

            CurrentEquipedItem?.OnEquip(this);
        }

        [ServerRpc]
        public void RequestFireServerRpc(float force, Vector3 direction, string itemId) {
            // 1. Validar se o player tem o item (anti-cheat)
            // 2. Spawnar o projétil real

            var itemData = ItemsAssetManager.Instance.GetItemById(itemId);
            if(itemData is WeaponData weaponData) {
                Vector2 pos = ( (Vector2) transform.position ) + (AimDirection.Value.normalized * 1.0f);


                GameObject proj = Instantiate(weaponData.prefab, pos, Quaternion.identity);
                proj.GetComponent<NetworkObject>().Spawn();
                proj.GetComponent<ProjectileController>().Launch(force, direction, weaponData.Damage);
                return;
            }
            Debug.Log("That is not a Weapon");
        }
    }
}