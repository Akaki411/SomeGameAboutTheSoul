using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraState : ScriptableObject
{
    [HideInInspector] public CameraMove camera {get; set;}

    public virtual void Init() { }

    public abstract void Run();

    public abstract void ChangeSize(int size);
}
