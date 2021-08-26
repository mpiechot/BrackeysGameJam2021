using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimState
{
    Idle,
    Walk,
    Chaos
}

public class MinionAnim : MonoBehaviour
{

    private AnimState currentState;

    
    public void RequestState(AnimState nextState)
    {
        if(nextState != currentState)
        {
            SwitchState(nextState);
        }
    }

    private void SwitchState(AnimState nextState)
    {
        if (currentState == AnimState.Chaos && nextState == AnimState.Walk) return;
        currentState = nextState;
    }


    private void Update()
    {
        print(currentState);

        if (currentState == AnimState.Idle)
        {
            IdleUpdate();
        }
        else if (currentState == AnimState.Walk)
        {
            WalkUpdate();
        }
        else if (currentState == AnimState.Chaos)
        {
            ChaosUpdate();
        }
    }

    private void IdleUpdate()
    {
        transform.localPosition = Vector3.up * (Mathf.Sin(Time.time * 0.1f) + 1) * 0.05f;
    }

    private void WalkUpdate()
    {
        transform.localPosition = Vector3.up * (Mathf.Sin(Time.time * 10) + 1) * 0.05f;
    }

    private void ChaosUpdate()
    {
        transform.localPosition = Vector3.up * (Mathf.Sin(Time.time * 20) + 1) * 0.2f;
    }
}
