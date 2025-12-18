using UnityEngine;
using Core.StateMachine;
using JetBrains.Annotations;

namespace Features.Player {
    public class PlayerStateIdleHoldingItem : BaseState<PlayerStateMachine.PlayerState> {
        private PlayerStateMachine ctx;

        public PlayerStateIdleHoldingItem(PlayerStateMachine context) : base(PlayerStateMachine.PlayerState.IdleHoldingItem) {
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
                return PlayerStateMachine.PlayerState.MovingHoldingItem;
            }

            if (ctx.IsOwner) {
                if (ctx.Controller.InventoryAction.triggered) {
                    return PlayerStateMachine.PlayerState.OnInventory;
                }
                if(ctx.Controller.UseItemAction.triggered) {
                    return PlayerStateMachine.PlayerState.UseItem;
                }
            }
            return PlayerStateMachine.PlayerState.IdleHoldingItem;
        }

        public override void UpdateState() {
            if (ctx.IsOwner) {
                ctx.InputDirection.Value = ctx.Controller.MoveAction.ReadValue<Vector2>();
            }
        }
    }
}