using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ISOEnemy : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private int coinsWorth = 10;
    [SerializeField] private int health = 5;
    [SerializeField] private PathFinder pathFinder;
    public UnityEvent<int> EnemyDiedEvent = new UnityEvent<int>();
    private List<KlotzPathData> selectedPath;


    private void Update()
    {
        if (selectedPath != null && selectedPath.Count > 0)
        {
            transform.Translate((selectedPath[0].transform.position - transform.position).normalized * Time.deltaTime);

            if(Vector2.Distance(transform.position, selectedPath[0].transform.position) < 0.2f)
            {
                selectedPath.RemoveAt(0);
            }
        }
        else
        {
            print("New Path");
            selectedPath = pathFinder.StartPathfinding(transform, target.transform);
        }
    }

    public void OnEnemyHit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            EnemyDiedEvent?.Invoke(coinsWorth);
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}
