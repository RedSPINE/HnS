using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxHolder : MonoBehaviour
{
    [SerializeField] private bool drawPlayer = false;

    [SerializeField] private bool multiTarget = true;
    public bool MultiTarget { get => multiTarget; set => multiTarget = value; }

    private HitboxSettings settings;
    public HitboxSettings Settings
    {
        get
        {
            if (settings == null) settings = HitboxSettings.Instance;
            return settings;
        }
    }

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
        if (drawPlayer) Gizmos.DrawMesh(Settings.PlayerGizmosMesh, -1, Vector3.zero);
        checkGizmoColor();
        hitbox.DrawGizmos(transform.rotation);
    }

    private void checkGizmoColor()
    {
        // if (_state == null) return;
        switch (_state)
        {
            case ColliderState.Closed:
                Gizmos.color = Settings.inactiveColor;
                break;
            case ColliderState.Open:
                Gizmos.color = Settings.collisionOpenColor;
                break;
            case ColliderState.Colliding:
                Gizmos.color = Settings.collidingColor;
                break;
        }
    }
}
