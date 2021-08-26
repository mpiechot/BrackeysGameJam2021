using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MinionBrain : MonoBehaviour
{

    [SerializeField] private MinionAnim anim;

    private MinionVars vars;
    private MinionWalk walk;

    private float randomNextGoalTime;

    private void Awake()
    {
        vars = GetComponent<MinionVars>();
        walk = GetComponent<MinionWalk>();
    }



    private void Update()
    {
        if(vars.CurrentState == MinionState.start)
        {
            SwitchStates(MinionState.chill);
        }

        if(vars.CurrentState == MinionState.chill)
        {
            ChillUpdate();
        }
        else if(vars.CurrentState == MinionState.chaos)
        {
            ChaosUpdate();
        }

        if(vars.Chaos >= 1.0f)
        {
            SwitchStates(MinionState.chaos);
        }
        else if(vars.Chaos <= 0.0f)
        {
            SwitchStates(MinionState.chill);
        }
    }

    private void SwitchStates(MinionState nextState)
    {
        if (vars.SwitchStates(nextState))
        {
            randomNextGoalTime = Time.time;
            if(nextState == MinionState.chill) walk.SetWalkDestination(vars.Home);

            if (nextState == MinionState.chaos) anim.RequestState(AnimState.Chaos);
            else if (nextState == MinionState.chill) anim.RequestState(AnimState.Idle);
        }
    }

    private void ChillUpdate()
    {
        if(Vector3.Distance(transform.position, vars.Home) > 0.1f)
        {
            walk.SetWalkDestination(vars.Home);
        }
        else
        {
            anim.RequestState(AnimState.Idle);
        }
    }

    private void ChaosUpdate()
    {
        if(Time.time > randomNextGoalTime)
        {
            walk.SetWalkDestination(new Vector3(UnityEngine.Random.Range(6.0f, 15.0f), 0, UnityEngine.Random.Range(0.0f, 9.0f)));
            randomNextGoalTime = Time.time + UnityEngine.Random.Range(0.5f, 2.0f);
        }
    }
}
