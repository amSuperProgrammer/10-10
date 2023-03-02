using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    MoveManager moveManager;

    private void Start()
    {
        moveManager = GetComponent<MoveManager>();
    }

    private void OnMouseUp()
    {
        
    }
}
