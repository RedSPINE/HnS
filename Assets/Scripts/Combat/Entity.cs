using System.ComponentModel.DataAnnotations;
using System;
using UnityEngine;

[DisallowMultipleComponent]
public class Entity: MonoBehaviour
{
    public EntitySO entityData;
    public event Action<float> OnHealthPctChange = delegate {};

    [SerializeField]
    private float health;
    public float Health { get => health; }

    private float defense;
    public float Defense { get => defense; }

    private float movementSpeed;
    public float MovementSpeed { get => movementSpeed; }

    private float haste = 1;
    public float Haste { get => haste; }

    private float strength = 1;
    public float Strength { get => strength; }

    private float maximumHealth;
    public float MaxHealth { get => maximumHealth; }
    
    private void Start() {
        defense = entityData.Defense;
        movementSpeed = entityData.MovementSpeed;
        strength = entityData.Strength;
        maximumHealth = entityData.MaximumHealth;
        health = maximumHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log($"TakeDamage: {damage}, new health: {health}");
        OnHealthPctChange(health/MaxHealth);
        
        if(health<=0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
