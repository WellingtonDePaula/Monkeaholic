using UnityEngine;
using Core.StateMachine;

namespace Features.Player {
    public class PlayerStateAiming : BaseState<PlayerStateMachine.PlayerState> {
        private PlayerStateMachine ctx;

        public PlayerStateAiming(PlayerStateMachine context) : base(PlayerStateMachine.PlayerState.Aiming) {
            ctx = context;
        }

        public override void EnterState() {
            if (!ctx.IsOwner) { return; }
            ctx.CurrentEquipedItem?.OnStartUse();
            Debug.Log("Aiming");
        }

        public override void ExitState() {
            if (!ctx.IsOwner) { return; }
            ctx.CurrentEquipedItem?.OnEndUse();
        }

        public override void FixedUpdateState() {
        }

        public override PlayerStateMachine.PlayerState GetNextState() {
            if (ctx.IsOwner) {
                if (ctx.Controller.GetUseItemReleased()) {
                    return PlayerStateMachine.PlayerState.Idle;
                }
            }
            return PlayerStateMachine.PlayerState.Aiming;
        }

        public override void UpdateState() {
            if (!ctx.IsOwner) { return; }
            ctx.AimDirection.Value = ctx.Controller.GetAimDirection(ctx.transform.position);
            ctx.CurrentEquipedItem?.OnUpdateUse();
        }
    }
}