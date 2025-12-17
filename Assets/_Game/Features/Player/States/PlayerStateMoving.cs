using UnityEngine;
using Core.StateMachine;

namespace Features.Player {
    public class PlayerStateMoving : BaseState<PlayerStateMachine.PlayerState> {
        private PlayerStateMachine ctx;

        public PlayerStateMoving(PlayerStateMachine context) : base(PlayerStateMachine.PlayerState.Moving) {
            ctx = context;
        }

        public override void EnterState() {
            //ctx.OnStartMoving?.Invoke();
            //if (ctx.IsOwner) {
            //    Vector2 input = ctx.Controller.MoveAction.ReadValue<Vector2>();
            //    ctx.InputDirection.Value = input;
            //}
        }

        public override void ExitState() {

        }

        public override PlayerStateMachine.PlayerState GetNextState() {
            if (ctx.InputDirection.Value == Vector2.zero) {
                return PlayerStateMachine.PlayerState.Idle;
            }
            if (ctx.IsOwner) {
                if (ctx.Controller.InventoryAction.triggered) {
                    return PlayerStateMachine.PlayerState.OnInventory;
                }
            }

            return PlayerStateMachine.PlayerState.Moving;
        }

        public override void UpdateState() {
            if (ctx.IsOwner) {
                Vector2 input = ctx.Controller.MoveAction.ReadValue<Vector2>();
                ctx.InputDirection.Value = input;
            }
            
            if(ctx.IsHost) {
                ctx.Movement.Move(ctx.InputDirection.Value.x);
            }
        }
    }
}