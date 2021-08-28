using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoSortingLayer : MonoBehaviour
{

    [SerializeField] private float offset;

    void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y * 10 - offset);
    }
}
