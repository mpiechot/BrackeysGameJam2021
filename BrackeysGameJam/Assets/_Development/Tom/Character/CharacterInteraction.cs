using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] private float selectableDistance = 10f;
    [SerializeField] private float cheerUpDistance = 5f;
    [SerializeField] private GameObject towerPrototype;
    [SerializeField] private LayerMask selectableMask;
    [SerializeField] private LayerMask minionMask;

    private GameObject selectedField;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Build();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            CheerUpUnits();
        }
    }

    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, selectableDistance, selectableMask))
        {
            selectedField = hit.transform.gameObject;
            selectedField?.GetComponent<TowerBuildPosition>()?.Select();
        }
    }

    private void CheerUpUnits()
    {
        // For all units in Range, reduce chaos
        Collider[] chaosM = Physics.OverlapSphere(transform.position, cheerUpDistance, minionMask);
        if(chaosM != null && chaosM.Length > 0)
        {
            Array.ForEach(chaosM, chaosMinion => 
            {
                chaosMinion.GetComponent<MinionChaos>()?.ResetChaos();
                print("Reset Chaos");
            });
        }
    }

    private void Build()
    {
        if (EnoughCoins()) //Todo if enough coins
        {

            print("Build!");
            selectedField?.GetComponent<TowerBuildPosition>()?.BuildTower(towerPrototype); //Todo get selected UI Tower
            
            //Todo reduce coins
        }
    }

    private bool EnoughCoins()
    {
        return true; 
    }
}
