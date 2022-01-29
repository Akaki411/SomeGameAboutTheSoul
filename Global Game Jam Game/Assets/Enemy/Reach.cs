using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reach : MonoBehaviour
{
    private Enemy parent;

    private void Start()
    {
        parent = GetComponentInParent<Enemy>();
    }
    
    public void StartManipulate()
    {
        parent.StartManipulate();
    }

    public GameObject GetParent()
    {
        return parent.gameObject;
    }
}
