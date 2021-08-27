using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IsoPlayerMovement : MonoBehaviour
{
    [SerializeField] private UnityEvent<bool> onMove;
    [SerializeField] private float moveSpeed;

    private Vector3 movement;
    private bool moveToggle;


    void Update()
    {
        GetMovement();
        ApplyMovement();

        if (!moveToggle && movement.magnitude > 0.1f)
        {
            onMove?.Invoke(true);
            moveToggle = true;
        }
        else if (moveToggle && movement.magnitude < 0.1f)
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
        float yMove = Input.GetAxis("Vertical");

        movement = new Vector3(xMove, yMove) * moveSpeed;
    }
}
