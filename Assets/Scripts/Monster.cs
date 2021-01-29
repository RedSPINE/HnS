using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected float health
    {
        get;
        set;
    }

    protected float maxHealth
    {
        get;
        set;
    }

    [SerializeField] 
    private float _health2;
    public float health2
    {
        get { return _health2; }
        private set { _health2 = value; }
    }

    public float health3;

    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
