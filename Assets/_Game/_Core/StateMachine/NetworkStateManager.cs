using Core.StateMachine;
using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public abstract class NetworkStateManager<Estate> : NetworkBehaviour where Estate : Enum {
    protected Dictionary<Estate, BaseState<Estate>> States = new Dictionary<Estate, BaseState<Estate>>();
    protected BaseState<Estate> CurrentState;

    protected bool IsTransitioningState = false;
    private void Awake() { }
    private void Start() {
        if (!IsOwner) { return; }
        CurrentState.EnterState();
    }
    protected virtual void Update() {
        if(!IsOwner) { return; }
        Estate nextStateKey = CurrentState.GetNextState();

        if (!IsTransitioningState && nextStateKey.Equals(CurrentState.StateKey)) {
            CurrentState.UpdateState();
        } else {
            TransitionToState(nextStateKey);
        }
    }

    protected void TransitionToState(Estate stateKey) {
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