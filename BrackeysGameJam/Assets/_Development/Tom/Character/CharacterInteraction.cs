using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] private float selectableDistance = 10f;
    [SerializeField] private LayerMask selectableMask;

    private GameObject selectedField;
    
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, selectableDistance,selectableMask))
        {
            selectedField = hit.transform.gameObject;
            selectedField.GetComponent<TowerBuildPosition>().Select();
        }
        if(Input.GetButtonDown("Fire1"))
        {
            Build();
        }
    }

    private void Build()
    {
        if (true) //Todo if enough coins
        {
            selectedField.GetComponent<TowerBuildPosition>().BuildTower(null); //Todo get selected UI Tower
            
            //Todo reduce coins
        }
    }
    
}
