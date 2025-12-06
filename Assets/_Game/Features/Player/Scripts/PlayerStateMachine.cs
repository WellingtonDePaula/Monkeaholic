using UnityEngine;
using Core.StateMachine;
using Unity.Netcode;
using System;
using UnityEngine.Events;

namespace Features.Player {
    public class PlayerStateMachine : NetworkStateManager<PlayerStateMachine.PlayerState> {
        public PlayerMovement Movement { get; private set; }
        public PlayerController Controller { get; private set; }
        public Rigidbody2D Body { get; private set; }
        public NetworkVariable<Vector2> InputDirection;
        public UnityEvent OnStartMoving;

        // Temporário speed, será substituído pelo sistema de stats
        [SerializeField] public float MoveSpeed = 5f;
        [SerializeField] public float JumpSpeed = 5f;

        public enum PlayerState {
            Idle,
            Moving,
            //Jumping,
            //Falling,
        }

        private void Awake() {
            Movement = new PlayerMovement(this);
            Controller = new PlayerController();
            Body = gameObject.GetComponent<Rigidbody2D>();
            InputDirection = new NetworkVariable<Vector2>(Vector2.zero, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

            States.Add(PlayerState.Idle, new PlayerStateIdle(this));
            States.Add(PlayerState.Moving, new PlayerStateMoving(this));

            CurrentState = States[PlayerState.Idle];
        }

        protected override void Update() {
            base.Update();

            if (IsHost) {
                Movement.Move(InputDirection.Value.x);
            }
        }
    }
}