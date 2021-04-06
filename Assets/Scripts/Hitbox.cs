using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private bool multiTarget = true;
    public bool MultiTarget { get => multiTarget; set => multiTarget = value; }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"OnTriggerEnter called on : {other.name}");
        this.GetComponent<Rigidbody>().SweepTestAll(transform.forward, 0.0f);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"OnTriggerStay called on : {other.name}");
    }
}
