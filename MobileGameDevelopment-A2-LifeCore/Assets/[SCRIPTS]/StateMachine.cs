using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public List<string> StatesKeys;
    public List<StateBase> AvailableStates;
    private Dictionary<string, StateBase> states;
    [SerializeField] private string initialState;
    private List<StateBase> stateHistory;
    private StateBase currentState;
    private int currentStateIndex;

    private void Start()
    {
        states = new Dictionary<string, StateBase>();
        stateHistory = new List<StateBase>();
        currentState = null;
        currentStateIndex = -1;
        InitializeStateMachine();
    }

    private void Update()
    {
        currentState.OnHandleInputState();
        currentState.OnUpdateState();
    }

    private void FixedUpdate()
    {
        currentState.OnFixedUpdateState();
    }

    public void PushStateByKey(string key)
    {
        if (currentState != null)
        {
            currentState.OnExitState();
        }

        if (states[key] == null)
        {
            Debug.Log(this.gameObject.name + " is trying to push the state " + key  +" but this one doesn't exist");
            return;
        }
        stateHistory.Add(states[key]);
        currentStateIndex += 1;
        currentState = stateHistory[currentStateIndex];
        currentState.OnEnterState(this.gameObject);
    }

    public void PopCurrentState()
    {
        if (currentState != null)
        {
            currentState.OnExitState();
        }

        stateHistory.Remove(currentState);
        currentStateIndex -= 1;
        currentState = stateHistory[currentStateIndex];
        currentState.OnEnterState(this.gameObject);
    }

    private void InitializeStateMachine()
    {
        int index = 0;
        foreach (var state in AvailableStates)
        {
            states.Add(StatesKeys[index], Instantiate(state));
            index += 1;
        }
        if (initialState != "")
        {
            PushStateByKey(initialState);
        }
        else
        {
            Debug.Log("Please type the name of the initial State");
        }

    }

}
