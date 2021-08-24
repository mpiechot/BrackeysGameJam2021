using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> onMove;
    [SerializeField] private float moveSpeed;

    private Vector3 movement;
    private bool moveToggle;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 45, 0);
    }

    void Update()
    {
        GetMovement();
        ApplyMovement();

        if(!moveToggle && movement.magnitude > 0.1f)
        {
            onMove?.Invoke(true);
            moveToggle = true;
        }
        else if(moveToggle && movement.magnitude < 0.1f)
        {
            onMove?.Invoke(false);
            moveToggle = false;
        }
    }

    private void ApplyMovement()
    {
        transform.Translate(movement * Time.deltaTime, Space.World);
    }


    private void GetMovement()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        movement = Quaternion.Euler(0, -135, 0) * new Vector3(xMove, 0, zMove * 1.25f) * moveSpeed;
    }
}
