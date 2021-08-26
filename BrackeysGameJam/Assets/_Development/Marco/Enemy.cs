using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public GameObject target;
    public NavMeshAgent agent;
    [SerializeField] private int coinsWorth = 10;
    [SerializeField] private int health = 5;
    public UnityEvent<int> EnemyDiedEvent = new UnityEvent<int>();

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);
    }

    public void OnEnemyHit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            EnemyDiedEvent.Invoke(coinsWorth);
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
