using UnityEngine;

[CreateAssetMenu(fileName = "NewEntity", menuName = "ScriptableObjects/EntityData")]
public class EntitySO : ScriptableObject
{
    [SerializeField] protected float maximumHealth;
    public float MaximumHealth { get => maximumHealth; }

    [SerializeField] protected float movementSpeed;
    public float MovementSpeed { get => movementSpeed; }

    [SerializeField] protected float strength;
    public float Strength { get => this.strength; }

    [SerializeField] protected float haste;
    public float Haste { get => haste; }

    [SerializeField] protected float defense;
    public float Defense { get => defense; }
}
