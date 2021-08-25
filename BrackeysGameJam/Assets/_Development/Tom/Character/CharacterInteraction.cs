using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] private float selectableDistance = 10f;
    [SerializeField] private LayerMask selectableMask;

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
            selectedField.GetComponent<TowerBuildPosition>().Select();
        }
    }

    private void CheerUpUnits()
    {
        // For all units in Range, reduce chaos
    }

    private void Build()
    {
        if (EnoughCoins()) //Todo if enough coins
        {

            selectedField?.GetComponent<TowerBuildPosition>().BuildTower(null); //Todo get selected UI Tower
            
            //Todo reduce coins
        }
    }

    private bool EnoughCoins()
    {
        return true; 
    }
}
