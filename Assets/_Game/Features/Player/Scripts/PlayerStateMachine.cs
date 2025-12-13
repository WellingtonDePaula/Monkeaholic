using UnityEngine;
using Core.StateMachine;
using Unity.Netcode;
using System;
using UnityEngine.Events;
using Core.ScriptableObjects;

namespace Features.Player {
    public class PlayerStateMachine : NetworkStateManager<PlayerStateMachine.PlayerState> {
        public PlayerMovement Movement { get; private set; }
        public PlayerController Controller { get; private set; }
        public Rigidbody2D Body { get; private set; }
        public MonkeyClassData Stats;

        public NetworkVariable<Vector2> InputDirection;
        //public UnityEvent OnStartMoving;

        public enum PlayerState {
            Idle,
            Moving,
            //Jumping,
            //Falling,
        }

        public override void OnNetworkSpawn() {
            Movement = new PlayerMovement(this);
            Controller = new PlayerController();
            Body = gameObject.GetComponent<Rigidbody2D>();
            States.Add(PlayerState.Idle, new PlayerStateIdle(this));
            States.Add(PlayerState.Moving, new PlayerStateMoving(this));

            CurrentState = States[PlayerState.Idle];
        }

        private void Awake() {
            InputDirection = new NetworkVariable<Vector2>(Vector2.zero, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);
        }

        protected override void Update() {
            base.Update();

            if (IsHost) {
                Movement.Move(InputDirection.Value.x);
            }
        }
    }
}