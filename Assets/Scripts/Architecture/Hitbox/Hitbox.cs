using System;
using UnityEngine;

public abstract class Hitbox : ScriptableObject
{
    private HitboxSettings hitboxSettings;
    public HitboxSettings HitboxSettings
    {
        get
        {
            if (hitboxSettings == null) hitboxSettings = HitboxSettings.Instance;
            return hitboxSettings;
        }
    }

    [Range(-10, 10)]
    public float zOffset;
    public abstract void DrawGizmos(Transform transform);
    public abstract Collider[] Cast(Transform transform);
}
