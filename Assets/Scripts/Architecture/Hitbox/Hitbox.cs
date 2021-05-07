using System;
using UnityEngine;

public abstract class Hitbox : ScriptableObject
{
    public HitboxSettings HitboxSettings
    {
        get
        {
            return HitboxSettings.Instance;
        }
    }

    [Range(-10, 10)]
    public float zOffset;
    public abstract void DrawGizmos(Transform transform);
    public abstract Collider[] Cast(Transform transform);
}
