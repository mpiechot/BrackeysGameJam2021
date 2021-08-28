using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsoPlayerAnimation : MonoBehaviour
{
    private Vector2 offset;

    [SerializeField] private Transform animationContainer;

    private bool running;

    void Start()
    {
        offset = Vector2.zero;
    }

    void Update()
    {
        offset = Vector2.up * (Mathf.Sin(Time.time * (running ? 10f : 1f)) * 0.2f * (running ? 0.5f : 1f) + 1);
        animationContainer.localPosition = Vector3.Lerp(animationContainer.localPosition, offset, 0.1f);

    }

    public void OnRun(bool run)
    {
        running = run;
    }
}
