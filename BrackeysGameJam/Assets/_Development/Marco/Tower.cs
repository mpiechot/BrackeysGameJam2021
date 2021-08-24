using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float attackSpeed = 2f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private LayerMask targetLayer; 
    
    private Transform target;
    
    
    // Update is called once per frame
    void Update()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, attackRange, targetLayer);
        if (targets.Length > 0)
        {
            target = targets[0].transform;
            Debug.Log("EnemyLayer: " +this.gameObject.layer);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,attackRange);
    }
}
