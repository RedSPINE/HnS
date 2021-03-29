using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageButton : MonoBehaviour
{
    public Entity entity;
    public float damage;

    public void OnClick()
    {
        entity.TakeDamage(damage);
    }
}
