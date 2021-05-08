using UnityEngine;

public class HitboxHolder : MonoBehaviour
{
    [SerializeField] private bool drawPlayer = false;
    [SerializeField] private bool multiTarget = true;
    [SerializeField] private HitboxSO hitbox;

    public enum ColliderState
    {
        Closed,
        Open,
        Colliding
    }
    [SerializeField]
    private ColliderState _state;

    public void Open()
    {
        _state = ColliderState.Open;
    }

    public void Close()
    {
        _state = ColliderState.Closed;
    }

    private void OnDrawGizmos()
    {
        HitboxSettings Settings = HitboxSettings.Instance;
        if (drawPlayer) Gizmos.DrawMesh(Settings.PlayerGizmosMesh, -1, Vector3.zero);
        checkGizmoColor();
        hitbox.DrawGizmos(transform);
    }

    private void checkGizmoColor()
    {
        HitboxSettings Settings = HitboxSettings.Instance;
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

    private void Update() {
        if (_state == ColliderState.Closed) return;
        if (Cast().Length != 0) _state = ColliderState.Colliding;
        else _state = ColliderState.Open;
    }

    public Collider[] Cast()
    {
        Collider[] hits = hitbox.Cast(transform);
        foreach (Collider hit in hits)
        {
            Debug.Log(hit.ToString());
        }
        return hits;
    }
}
