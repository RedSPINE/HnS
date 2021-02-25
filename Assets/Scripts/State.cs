using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State: ScriptableObject
{
    protected abstract Animation GetAnimation();
    protected abstract void HandleInput();
    protected abstract void Update();
}
