using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionChaos : MonoBehaviour
{
    private MinionVars vars;

    [SerializeField] private SpriteRenderer minionSpriteRenderer;

    private void Start()
    {
        vars = GetComponent<MinionVars>();
    }

    private void Update()
    {
        minionSpriteRenderer.color = Color.Lerp(Color.white, Color.red, vars.Chaos / 1.2f);
    }

    public void AddChaos(int numEnemies)
    {
        vars.AddChaos((Time.deltaTime / 3) * numEnemies);
    }

    internal void ResetChaos()
    {
        vars.SetChaos(0);
    }

    internal void ReduceChaos(float reduceSpeed)
    {
        vars.AddChaos(-Time.deltaTime * reduceSpeed);
    }
}
