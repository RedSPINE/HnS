using UnityEngine;

[CreateAssetMenu(fileName = "NewEntity", menuName = "ScriptableObjects/EntityData")]
public class EntitySO : ScriptableObject
{
    [SerializeField] protected float maximumHealth;
    public float MaximumHealth { get => maximumHealth; }

    [SerializeField] protected float movementSpeed;
    public float MovementSpeed { get => movementSpeed; }
}