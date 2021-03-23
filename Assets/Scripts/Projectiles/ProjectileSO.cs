using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "ScriptableObjects/Projectile")]
public class ProjectileSO : ScriptableObject
{
    [SerializeField] protected float radius;
    public float Radius { get => radius; }

    [SerializeField] protected GameObject explosion;
    public GameObject Explosion { get => explosion; }

    [SerializeField] protected float lifetime;
    public float Lifetime { get => lifetime; }

    [SerializeField] protected float speed;
    public float Speed { get => speed; }
}