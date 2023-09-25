using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// State machine class providing useful functionality
/// such as how long we were last in a state
/// also enables you to debug who changed the state
/// </summary>

public class BWStateMachine<TState> where TState : Enum
{
    private TState currentState;
    private TState lastState;
    private TState nextState;
    private float elapsedSinceStateChange;

    public BWStateMachine(TState state)
    {
        currentState = state;
        lastState = state;
        nextState = state;
    }

    public bool IsCurrentState(params TState[] states)
    {
        foreach (TState state in states)
        {
            if (currentState.Equals(state))
            {
                return true;
            }
        }
        return false;
    }

    public TState CurrentState
    {
        get { return currentState; }
    }

    public TState NextState
    {
        get { return nextState; }
        set { nextState = value; }
    }

    public float TimeInState
    {
        get { return elapsedSinceStateChange; }
    }

    public TState LastState
    {
        get { return lastState; }
    }

    public void IncrementState()
    {
        TState[] enumValues = (TState[])Enum.GetValues(typeof(TState));
        int currentIndex = Array.IndexOf(enumValues, currentState);

        // Increment the index to get the next state
        int nextIndex = (currentIndex + 1) % enumValues.Length;
        nextState = enumValues[nextIndex];
    }

    public void Update()
    {
        elapsedSinceStateChange += Time.deltaTime;

        // Checkif the state has changed
        if (nextState.Equals(currentState) == false)
        {
            lastState = currentState;
            elapsedSinceStateChange = 0;
            currentState = nextState;
        }
    }
}