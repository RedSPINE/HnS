using System.Globalization;
using UnityEngine;

public class ProjectilePawn : MonoBehaviour
{
    public ProjectileSO projectile;
    public GameObject explosion;

    [SerializeField] private float lifetime = 0f;
    private float internalLifetime;

    [SerializeField] public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        internalLifetime = 0f;
        if (projectile != null)
        {
            explosion = projectile.Explosion;
            speed = projectile.Speed;
            lifetime = projectile.Lifetime;
        }
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
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.name);
        AutoDestroy();
    }
}
