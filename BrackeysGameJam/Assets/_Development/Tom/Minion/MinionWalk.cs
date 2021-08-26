using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MinionWalk : MonoBehaviour
{
    [SerializeField] private MinionAnim anim;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    internal void SetWalkDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
        agent.isStopped = false;
        anim.RequestState(AnimState.Walk);
    }

}
