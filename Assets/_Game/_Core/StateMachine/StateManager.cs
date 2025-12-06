using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace Core.StateMachine {
    public abstract class StateManager<Estate> : MonoBehaviour where Estate : Enum {
        protected Dictionary<Estate, BaseState<Estate>> States = new Dictionary<Estate, BaseState<Estate>>();
        protected BaseState<Estate> CurrentState;

        protected bool IsTransitioningState = false;
        private void Awake() { }
        private void Start() {
            CurrentState.EnterState();
        }
        private void Update() {
            Estate nextStateKey = CurrentState.GetNextState();

            if (!IsTransitioningState && nextStateKey.Equals(CurrentState.StateKey)) {
                CurrentState.UpdateState();
            } else {
                TransitionToState(nextStateKey);
            }
        }

        private void TransitionToState(Estate stateKey) {
            IsTransitioningState = true;
            CurrentState.ExitState();

            CurrentState = States[stateKey];

            CurrentState.EnterState();
            IsTransitioningState = false;
        }
        //private void OnTriggerEnter2D(Collider2D collision) { }
        //private void OnTriggerStay2D(Collider2D collision) { }
        //private void OnTriggerExit2D(Collider2D collision) { }
        //private void OnCollisionEnter2D(Collision2D collision) { }
        //private void OnCollisionStay2D(Collision2D collision) { }
        //private void OnCollisionExit2D(Collision2D collision) { }
    }
}