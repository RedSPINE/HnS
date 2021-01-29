using UnityEngine;

public abstract class Entity: MonoBehaviour
{
    protected virtual float health
    {
        get;
        set;
    }

    protected abstract float maxHealth
    {
        get;
        set;
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
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
