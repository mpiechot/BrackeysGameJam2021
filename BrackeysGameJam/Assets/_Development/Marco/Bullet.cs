using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private float bulletSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.transform);
            transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        }
    }
}
