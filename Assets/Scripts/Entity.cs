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

    private float movementSpeed;
    public float MovementSpeed { get => entityData.MovementSpeed; }

    private float haste = 1;
    public float Haste { get => haste; }

    private float strength = 1;
    public float Strength { get => strength; }

    public float MaxHealth { get => entityData.MaximumHealth; }
    
    private void Start() {
        health = entityData.MaximumHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        
        Debug.Log("TakeDamage");
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
