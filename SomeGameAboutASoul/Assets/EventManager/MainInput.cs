using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInput : MonoBehaviour
{
    public static MainInput singleton { get; private set; }
    
    public static float x { get; private set; }
    public static float y { get; private set; }
    
    public delegate void JumpDelegate();
    public delegate void DropDelegate();

    public event JumpDelegate Jump;
    public event DropDelegate Drop;

    private void Start()
    {
        singleton = this;
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Drop.Invoke();
        }
    }
}
