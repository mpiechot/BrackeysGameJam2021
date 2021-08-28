using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectRandomSprite : MonoBehaviour
{
    [SerializeField] private Sprite[] selectables;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = selectables[Random.Range(0, selectables.Length)];
    }
}
