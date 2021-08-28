using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class IsoPlayerInteraction : MonoBehaviour
{

    [SerializeField] private float selectableDistance = 10f;
    [SerializeField] private float cheerUpDistance = 5f;
    [SerializeField] private GameObject towerPrototype;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private LayerMask selectableMask;
    [SerializeField] private LayerMask minionMask;
    [SerializeField] private float sellButtonDelayTime = 0.3f;
    [SerializeField] private float playerPower = 1000;
    [SerializeField] private float cheerSpeed = 1.0f;

    [SerializeField] private UnityEvent<int> OnPowerChange;

    private GameObject selectedField;
    private float sellButtonDelay;

    private bool sellToggle;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Build();
        }

        if (Input.GetButton("Fire1"))
        {
            sellButtonDelay += Time.deltaTime;
        }
        else
        {
            sellButtonDelay = 0.0f;
            sellToggle = false;
        }

        if (sellButtonDelay >= sellButtonDelayTime)
        {
            if (!sellToggle)
            {
                Sell();
                sellToggle = true;
            }
        }

        if (Input.GetButton("Fire2"))
        {
            if (playerPower > 0)
            {
                CheerUpUnits();
                playerPower -= Time.deltaTime * 250;
                OnPowerChange?.Invoke(Mathf.Max((int)playerPower, 0));
            }
        }
        else
        {
            if (playerPower < 1000)
            {
                playerPower += Time.deltaTime * 450;
                OnPowerChange?.Invoke(Mathf.Min((int)playerPower, 1000));
            }
            else
            {
                playerPower = 1000;
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            PauseMenuControl.SetTimeScale(0);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (selectedField != null)
        {
            selectedField.GetComponent<TowerBuildPosition>()?.UnSelect();
        }
        selectedField = collision.gameObject;
        selectedField.GetComponent<TowerBuildPosition>()?.Select();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (selectedField != null && collision.GetComponent<TowerBuildPosition>() != selectedField)
        {
            selectedField.GetComponent<TowerBuildPosition>()?.UnSelect();
        }
        selectedField = null;
    }

    private void CheerUpUnits()
    {
        // For all units in Range, reduce chaos
        Collider2D[] chaosM = Physics2D.OverlapCircleAll(transform.position, cheerUpDistance, minionMask);
        if (chaosM != null && chaosM.Length > 0)
        {
            System.Array.ForEach(chaosM, chaosMinion =>
            {
                chaosMinion.GetComponent<MinionChaos>()?.ReduceChaos(cheerSpeed);
                //print("Reset Chaos");
            });
        }
    }

    private void Build()
    {
        //print("Build!");
        selectedField?.GetComponent<TowerBuildPosition>()?.BuildTower(towerPrototype);
    }

    private void Sell()
    {
        //print("Sell!");
        selectedField?.GetComponent<TowerBuildPosition>()?.SellTower();
    }

}
