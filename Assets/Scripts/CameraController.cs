using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform target = default;
    private Vector3 anchorPos;
    private float cameraYOffset;

    // Start is called before the first frame update
    void Start()
    {
        anchorPos = transform.position;
        cameraYOffset = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(target)
            transform.position = new Vector3(anchorPos.x + target.position.x, cameraYOffset, anchorPos.z + target.position.z);   
    }
}
