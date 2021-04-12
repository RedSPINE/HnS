using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Hitbox/Circle")]
public class HitboxCircle : Hitbox
{
    [SerializeField]
    private float radius = 1;

    public override void DrawGizmos(Quaternion rotation)
    {
        Vector3 position = new Vector3(0, HitboxSettings.HorizontalHitboxHeight, zOffset);
        position = rotation * position;
        Gizmos.matrix = Matrix4x4.TRS(position, rotation, Vector3.one);
        Gizmos.DrawWireSphere(Vector3.zero, radius);
    }
}
