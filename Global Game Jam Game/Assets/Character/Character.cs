using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private PlayerState _currentState;

    [SerializeField] private PlayerState _human;
    


    private void Start()
    {
        _currentState = _human;
        _currentState.player = this;
        _currentState.Init();
    }

    private void Update()
    {
        _currentState.Run();
    }
    
    

    public void ChangeState(PlayerState state)
    {
        _currentState.Exit();
        _currentState = state;
        _currentState.player = this;
        _currentState.Init();
    }
}
