using UnityEngine;
using Core.StateMachine;
using Features.Inventory;

namespace Features.Player {
    public class PlayerStateIdle : BaseState<PlayerStateMachine.PlayerState> {
        private PlayerStateMachine ctx;

        public PlayerStateIdle(PlayerStateMachine context) : base(PlayerStateMachine.PlayerState.Idle) {
            ctx = context;
        }

        public override void EnterState() {
        }

        public override void ExitState() {
        }

        public override void FixedUpdateState() {
        }

        public override PlayerStateMachine.PlayerState GetNextState() {
            if (ctx.InputDirection.Value != Vector2.zero) {
                return PlayerStateMachine.PlayerState.Moving;
            }

            if (ctx.IsOwner) {
                if (ctx.Controller.InventoryAction.triggered) {
                    return PlayerStateMachine.PlayerState.OnInventory;
                }

                if (ctx.Controller.GetUseItemPressed()) {
                    if (ctx.Inventory.GetCanUseItem()) {
                        return PlayerStateMachine.PlayerState.Aiming;
                    }
                }
            }
            return PlayerStateMachine.PlayerState.Idle;
        }

        public override void UpdateState() {
            if (ctx.IsOwner) {
                ctx.InputDirection.Value = ctx.Controller.MoveAction.ReadValue<Vector2>();
            }
        }
    }
}