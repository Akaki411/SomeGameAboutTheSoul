using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : ScriptableObject
{
    [HideInInspector] public Character player { get; set; }

    public virtual void Init()
    {
        
    }

    public abstract void Run();

    public virtual void Exit()
    {
        
    }
}
