using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform target;


    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + new Vector3(1, 0.75f, -1) * 20, 0.1f);
        transform.LookAt(target);
    }
}
