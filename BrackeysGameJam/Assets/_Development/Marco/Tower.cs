using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float initAttackSpeed = 2f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private LayerMask targetLayer; 
    [SerializeField] private float shootingHeight; 
    [SerializeField] private GameObject minionPrefab;
    [SerializeField] private int minionsPerTower = 4;
    [SerializeField] private float minionPower = .5f;
    
    private GameObject[] towerMinions;
    private GameObject target;
    private bool shooting = false;
    private float attackSpeed = 2f;
    
    public int cost { get; set; }
    public bool canShoot = true;

    private void Start()
    {
        towerMinions = new GameObject[minionsPerTower];
        for (int i = 0; i < minionsPerTower; i++)
        {
            towerMinions[i] = Instantiate(minionPrefab, transform.position, Quaternion.identity, this.transform);
            towerMinions[i].GetComponent<MinionVars>().SetHome(transform.position + Vector3.one*Random.Range(-1,1));
        }
    }

    // Update is called once per frame
    void Update()
    {
        float reduceTime = minionPower * minionsPerTower;
        int minionsInRange = 0;
        for (int i = 0; i < minionsPerTower; i++)
        {
            if (!towerMinions[i].GetComponent<MinionVars>().IsChaos)
            {
                minionsInRange++;
            } 
        }

        if (minionsInRange == 0)
        {
            canShoot = false;
        }
        else
        {
            attackSpeed = initAttackSpeed + reduceTime - minionsInRange * minionPower;
        }
        
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
        target = targets[0].gameObject;
        for (int i = 0; i < towerMinions.Length; i++)
        {
            towerMinions[i].GetComponent<MinionChaos>().AddChaos(targets.Length);
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

    public void Destroy()
    {
        for (int i = 0; i < minionsPerTower; i++)
        {
            Destroy(towerMinions[i]);
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
