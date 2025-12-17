using Core.ScriptableObjects;
using Core.StateMachine;
using Features.Inventory;
using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Features.Player {
    public class PlayerStateMachine : NetworkStateManager<PlayerStateMachine.PlayerState> {
        public PlayerMovement Movement { get; private set; }
        public PlayerController Controller { get; private set; }
        public InventoryController Inventory { get; private set; }
        public Rigidbody2D Body { get; private set; }
        public MonkeyClassData Data;
        [HideInInspector] public NetworkVariable<Vector2> InputDirection;

        public enum PlayerState {
            Idle,
            Moving,
            OnInventory,
            //Jumping,
            //Falling,
        }

        public override void OnNetworkSpawn() {
            Movement = new PlayerMovement(this);
            Controller = new PlayerController();
            Inventory = new InventoryController();

            Body = gameObject.GetComponent<Rigidbody2D>();
            States.Add(PlayerState.Idle, new PlayerStateIdle(this));
            States.Add(PlayerState.Moving, new PlayerStateMoving(this));
            States.Add(PlayerState.OnInventory, new PlayerStateOnInventory(this));

            CurrentState = States[PlayerState.Idle];

            if (IsOwner) {
                if (InventoryUI.Instance != null) {
                    InventoryUI.Instance.InitializeInventoryUI(Inventory);
                }

            }
        }

        private void Awake() {
            InputDirection = new NetworkVariable<Vector2>(Vector2.zero, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
        }

        protected override void Update() {
            base.Update();
        }
    }
}