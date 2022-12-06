using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "ScriptableObjects/Projectile")]
public class ProjectileSO : ScriptableObject
{
    [SerializeField] protected float radius;
    public float Radius { get => radius; }

    [SerializeField] protected GameObject explosion;
    public GameObject Explosion { get => explosion; }

    [SerializeField] protected float lifetime = 1;
    public float Lifetime { get => lifetime; }

    [SerializeField] protected float speed = 1;
    public float Speed { get => speed; }

    [SerializeField] protected float damage = 0;
    public float Damage { get => damage; }
}