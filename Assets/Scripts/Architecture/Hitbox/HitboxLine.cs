using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Hitbox/Line")]
public class HitboxLine : Hitbox
{
    [SerializeField]
    private float length = 1;
    [SerializeField]
    private float width = 1;
    [SerializeField]
    private bool centerPivot = true;

    public override void DrawGizmos(Quaternion rotation)
    {
        Vector3 position = new Vector3(0, HitboxSettings.HorizontalHitboxHeight, zOffset);

        if (!centerPivot)
            position.Set(position.x, position.y, position.z + length / 2);

        Gizmos.matrix = Matrix4x4.TRS(position, rotation, new Vector3(width, HitboxSettings.HitboxYWidth, length));
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
    }
}
