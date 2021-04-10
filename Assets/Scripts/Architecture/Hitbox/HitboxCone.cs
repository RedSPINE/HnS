using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Hitbox/Cone")]
public class HitboxCone : Hitbox
{
    [SerializeField]
    private float length = 1;
    [SerializeField]
    [Range(0, 360)]
    private float angle = 1;
    [SerializeField]
    private int boxCount = 3;
    [SerializeField]
    private float boxWidth = 1;

    public override void DrawGizmos(Quaternion rotation)
    {
        Vector3 position = new Vector3(0, HitboxSettings.HorizontalHitboxHeight, zOffset);
        float effectiveAngle;
        for (int i = 0; i < boxCount; i++)
        {
            effectiveAngle = -angle/2 + i * (angle/(boxCount-1));
            rotation = Quaternion.Euler(rotation.x, rotation.y + effectiveAngle, rotation.z);
            Gizmos.matrix = Matrix4x4.TRS(position, rotation, new Vector3(boxWidth, HitboxSettings.HitboxYWidth, length));
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        }
    }
}
