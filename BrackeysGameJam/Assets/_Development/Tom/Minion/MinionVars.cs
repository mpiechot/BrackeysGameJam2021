using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal enum MinionState
{
    chill,
    chaos
}
public class MinionVars : MonoBehaviour
{

    private Vector3 home;
    private float chaosVal;
    private MinionState currentState;

    internal float Chaos { get => chaosVal; }
    internal Vector3 Home { get => home; }
    internal MinionState CurrentState { get => currentState; }
    public bool IsChaos { get => currentState == MinionState.chaos; }


    /// <summary>
    /// Sets the location of the point where the minion returns to when chaos is not active
    /// </summary>
    /// <param name="home"></param>
    public void SetHome(Transform home)
    {
        this.home = home.position;
    }

    /// <summary>
    /// Sets the location of the point where the minion returns to when chaos is not active
    /// </summary>
    /// <param name="home"></param>
    public void SetHome(Vector3 home)
    {
        this.home = home;
    }


    internal bool SwitchStates(MinionState nextState)
    {
        if (currentState != nextState)
        {
            currentState = nextState;
            return true;
        }
        return false;
    }

    internal void SetChaos(float val)
    {
        chaosVal = Mathf.Clamp01(val);
    }
    internal void AddChaos(float val)
    {
        chaosVal += val;
        chaosVal = Mathf.Clamp01(chaosVal);
    }


}
