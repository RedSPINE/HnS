using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "ScriptableObjects/Projectile")]
public class ProjectileSO : ScriptableObject
{
    [SerializeField] protected float radius;
    public float Radius { get => radius; }
}