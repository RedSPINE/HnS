using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem ripples = default;

    public void InstantiateRipple()
    {
        Instantiate(ripples, new Vector3(transform.position.x, 0.05f, transform.position.z), ripples.transform.rotation);
    }

}
