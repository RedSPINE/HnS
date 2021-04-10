using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxHolder : MonoBehaviour
{
    [SerializeField] private bool drawPlayer = false;

    [SerializeField] private bool multiTarget = true;
    public bool MultiTarget { get => multiTarget; set => multiTarget = value; }

    private HitboxSettings settings;
    [SerializeField]
    private Hitbox hitbox;

    public enum ColliderState
    {
        Closed,
        Open,
        Colliding
    }
    private ColliderState _state;

    private void OnDrawGizmos()
    {
        if (drawPlayer) Gizmos.DrawMesh(settings.PlayerGizmosMesh, -1, Vector3.zero);
        if (settings == null) settings = HitboxSettings.Instance;

        checkGizmoColor();
        hitbox.DrawGizmos(transform.rotation);
    }

    private void checkGizmoColor()
    {
        switch (_state)
        {
            case ColliderState.Closed:
                Gizmos.color = settings.inactiveColor;
                break;
            case ColliderState.Open:
                Gizmos.color = settings.collisionOpenColor;
                break;
            case ColliderState.Colliding:
                Gizmos.color = settings.collidingColor;
                break;
        }
    }
}
