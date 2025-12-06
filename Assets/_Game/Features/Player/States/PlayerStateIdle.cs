using UnityEngine;
using Core.StateMachine;

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

        public override PlayerStateMachine.PlayerState GetNextState() {
            ctx.InputDirection.Value = ctx.Controller.MoveAction.ReadValue<Vector2>();
            // Se houver input, mudar para o estado de movimento
            if (ctx.InputDirection.Value != Vector2.zero) {
                return PlayerStateMachine.PlayerState.Moving;
            }

            // Caso final, continuar no estado atual
            return PlayerStateMachine.PlayerState.Idle;
        }

        public override void UpdateState() {

        }
    }
}