using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionWalk : MonoBehaviour
{
    [SerializeField] private MinionAnim anim;
    [SerializeField] private PathFinder minionFinder;
    [SerializeField] private float[] moveMatrix;
    List<KlotzPathData> selectedPath;

    private float walkSpeed;

    private void Update()
    {
        if (selectedPath != null && selectedPath.Count > 0)
        {
            transform.Translate((selectedPath[0].transform.position - transform.position).normalized * Time.deltaTime * walkSpeed);

            if (Vector2.Distance(transform.position, selectedPath[0].transform.position) < 0.2f)
            {
                selectedPath.RemoveAt(0);
            }
        }
    }

    internal void SetWalkSpeed(float speed)
    {
        walkSpeed = speed;
    }

    internal void SetWalkDestination(Vector3 destination)
    {
        if (selectedPath == null || selectedPath.Count > 0)
        {
            selectedPath = minionFinder.StartPathfinding(transform, destination, moveMatrix);
        }
        anim.RequestState(AnimState.Walk);
    }

    internal void SetWalkDestination(Vector3 destination, bool overrideCurrentPath)
    {
        if (overrideCurrentPath || selectedPath == null || selectedPath.Count > 0)
        {
            selectedPath = minionFinder.StartPathfinding(transform, destination, moveMatrix);
        }
        anim.RequestState(AnimState.Walk);
    }

}
