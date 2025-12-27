using Core.StateMachine;
using Features.Inventory;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Features.Player {
    public class PlayerStateOnInventory : BaseState<PlayerStateMachine.PlayerState> {
        private PlayerStateMachine ctx;

        public PlayerStateOnInventory(PlayerStateMachine context) : base(PlayerStateMachine.PlayerState.OnInventory) {
            ctx = context;
        }

        public override void EnterState() {
            ToggleInventory();
        }

        public override void ExitState() {
            ToggleInventory();
        }

        public override PlayerStateMachine.PlayerState GetNextState() {
            if(ctx.Controller.InventoryAction.triggered) {
                return PlayerStateMachine.PlayerState.Idle;
            }
            return PlayerStateMachine.PlayerState.OnInventory;
        }

        private void ToggleInventory() {
            if (InventoryUI.Instance != null) {
                InventoryUI.Instance.ToggleVisibility();
            }
        }

        public override void UpdateState() {

        }

        public override void FixedUpdateState() {
        }
    }
}