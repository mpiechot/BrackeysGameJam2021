using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent agent;
    [SerializeField] private int health = 5;

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);
    }

    public void OnEnemyHit(int damage)
    {
        health -= damage;
        Debug.Log($"Take Damage: {health}({damage})");
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
