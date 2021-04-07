using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/HitboxSettings")]
public class HitboxSettings : SingletonScriptableObject<HitboxSettings>
{
    [SerializeField]
    [Range(-2, 2)]
    private float horizontalHitboxHeight = 0;
    public float HorizontalHitboxHeight { get => horizontalHitboxHeight; }

    [SerializeField]
    [Range(0, 2)]
    private float hitboxYWidth = 0.1f;
    public float HitboxYWidth { get => hitboxYWidth; }

    [SerializeField]
    private Mesh playerGizmoMesh;
    public Mesh PlayerGizmosMesh { get => playerGizmoMesh; }
}
