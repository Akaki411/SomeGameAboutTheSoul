using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyState : ScriptableObject
{
    [HideInInspector] public Enemy enemy;

    public virtual void Init()
    {
        
    }

    public abstract void Run();

    public virtual void Exit()
    {
        
    }
}
