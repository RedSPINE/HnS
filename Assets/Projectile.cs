using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float lifetime = 0f;
    private float internalLifetime;

    [SerializeField] public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        internalLifetime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        internalLifetime += Time.deltaTime;
        if(internalLifetime > lifetime) AutoDestroy();
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void AutoDestroy()
    {
        Destroy(this.gameObject);
    }
}
