using System;
using UnityEngine;
using UnityEngine.Events;
using Vector3 = UnityEngine.Vector3;

public class Bullet : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private float bulletSpeed = 2f;
    [SerializeField] private float hitRange = 1f;
    [SerializeField] private int bulletDamage = 1;

    public UnityEvent<int> HitTargetEvent;

    private void Start()
    {
        if (HitTargetEvent == null)
        {
            HitTargetEvent = new UnityEvent<int>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.transform);
            transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.transform.position) < hitRange)
            {
                HitTargetEvent.Invoke(bulletDamage);
                Destroy(this.gameObject);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
