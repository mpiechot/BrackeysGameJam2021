using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAnimation : MonoBehaviour
{

    [SerializeField] private Transform diamond;

    private Vector2 startPosition;
    private float timer;

    private void Start()
    {
        startPosition = diamond.localPosition;
    }

    void Update()
    {
        diamond.localPosition = startPosition + Vector2.up * Mathf.Sin(timer) * 0.2f;
        timer += Time.deltaTime;
    }
}
