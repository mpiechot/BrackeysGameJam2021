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
    [SerializeField] private float shootingHeight; 
    
    private GameObject target;
    private bool shooting = false;
    
    public int cost { get; set; }
    public bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            SearchForTargets();
            ShootAtTarget();    
        }
    }

    private void SearchForTargets()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, attackRange, targetLayer);
        target = null;
        for (int i = 0; i < targets.Length; i++)
        {
            //TODO There might be something wrong here: the tower shoots quite late!
            if (Vector3.Distance(transform.position, targets[i].transform.position) > attackRange)
            {
                continue;
            }

            target = targets[i].gameObject;
            return;
        }
    }

    private void ShootAtTarget()
    {
        if (target == null)
        {
            return;
        }

        if (!shooting)
        {
            StartCoroutine("Shoot");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,attackRange);
    }

    IEnumerator Shoot()
    {
        Debug.Log("Wait for shooting!");
        shooting = true;
        yield return new WaitForSeconds(attackSpeed);

        if (target != null)
        {
            GameObject bulletObj = Instantiate(this.bullet, transform.position+ Vector3.up*shootingHeight, Quaternion.identity, transform);
            Bullet bullet = bulletObj.GetComponent<Bullet>();
            bullet.target = target;
            print("bullet: " + bullet);
            print("target: " + target);
            bullet.HitTargetEvent.AddListener(target.GetComponent<Enemy>().OnEnemyHit);
        }
        shooting = false;
    }
}
