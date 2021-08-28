using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class KlotzSetup : MonoBehaviour
{

    void Start()
    {
        transform.GetChild(0).GetComponentsInChildren<SpriteRenderer>()[0].sortingOrder = -(int)(transform.position.y * 100) - 1;
        //transform.GetChild(0).GetComponentsInChildren<SpriteRenderer>()[1].sortingOrder = -(int)(transform.position.y * 100);
    }

}
