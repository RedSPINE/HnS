using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField] private bool drawPlayer = false;

    [SerializeField] private bool multiTarget = true;
    public bool MultiTarget { get => multiTarget; set => multiTarget = value; }

    public Color inactiveColor;
    public Color collisionOpenColor;
    public Color collidingColor;

    private HitboxSettings settings;

    public enum ColliderState
    {
        Closed,
        Open,
        Colliding
    }
    private ColliderState _state;

    public enum Type
    {
        Line,
        Sphere,
        Cone
    }
    public Type type;

    [Range(0, 10)]
    public float sphereRadius;
    [Range(-10, 10)]
    public float offset;


    private void OnDrawGizmos()
    {
        if (drawPlayer) Gizmos.DrawMesh(settings.PlayerGizmosMesh, -1, Vector3.zero);
        if (settings == null) settings = HitboxSettings.Instance;
        var relativePosition = new Vector3(0, settings.HorizontalHitboxHeight, offset);
        Gizmos.matrix = Matrix4x4.TRS(relativePosition, transform.rotation, transform.localScale);
        checkGizmoColor();
        switch (type)
        {
            case Type.Line:
                Gizmos.matrix = Matrix4x4.TRS(relativePosition, transform.rotation, new Vector3(1, settings.HitboxYWidth, 1));
                Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
                break;
            case Type.Sphere:
                Gizmos.DrawWireSphere(Vector3.zero, sphereRadius);
                Gizmos.DrawSphere(Vector3.zero, sphereRadius);
                return;
            case Type.Cone:
                return;
            default:
                return;
        }
    }

    private void checkGizmoColor()
    {
        switch (_state)
        {
            case ColliderState.Closed:
                Gizmos.color = inactiveColor;
                break;
            case ColliderState.Open:
                Gizmos.color = collisionOpenColor;
                break;
            case ColliderState.Colliding:
                Gizmos.color = collidingColor;
                break;
        }
    }

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
