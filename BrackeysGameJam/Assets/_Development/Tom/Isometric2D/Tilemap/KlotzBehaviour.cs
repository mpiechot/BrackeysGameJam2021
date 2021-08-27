using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KlotzBehaviour : MonoBehaviour
{


    private Vector3 startPosition;

    private bool isSelected;

    private void Start()
    {
        startPosition = transform.GetChild(0).localPosition;
    }

    public void SetSelected(bool selected)
    {
        isSelected = selected;
    }

    private void Update()
    {
        if(isSelected)
        {
            transform.GetChild(0).localPosition = Vector3.Lerp(startPosition, startPosition + Vector3.up * 5, 0.05f);
        }
        else
        {
            transform.GetChild(0).localPosition = Vector3.Lerp(transform.GetChild(0).localPosition, startPosition, 0.05f);
        }
    }

}
