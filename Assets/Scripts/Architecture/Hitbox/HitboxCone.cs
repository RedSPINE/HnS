using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Hitbox/Cone")]
public class HitboxCone : Hitbox
{
    [SerializeField]
    [Min(0.1f)]
    private float length = 1;
    [SerializeField]
    [Range(0, 360)]
    private float angle = 90;
    [SerializeField]
    [Min(2)]
    private int boxCount = 3;
    [SerializeField]
    [Min(0.01f)]
    private float boxWidth = 1;

    public override void DrawGizmos(Quaternion rotation)
    {
        Vector3 centerPos = new Vector3(0, HitboxSettings.HorizontalHitboxHeight, 0); // Character centre
        centerPos += rotation * Vector3.forward * zOffset; // Displace center of cone

        // Prepare variables for loops
        float effectiveAngle;
        Quaternion effectiveRotation;
        Vector3 effectivePos;

        for (int i = 0; i < boxCount; i++)
        {
            effectiveAngle = -angle / 2 + i * (angle / (boxCount - 1));
            effectiveRotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y + effectiveAngle, rotation.eulerAngles.z);
            Debug.Log(rotation);
            effectivePos = centerPos + length / 2 * (effectiveRotation * Vector3.forward);
            
            Gizmos.matrix = Matrix4x4.TRS(effectivePos, effectiveRotation, new Vector3(boxWidth, HitboxSettings.HitboxYWidth, length));
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        }
    }
}
