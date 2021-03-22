using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSkill", menuName = "ScriptableObjects/Skills/ProjectileSkill")]
public class ProjectileSkill : SkillSO
{
    [SerializeField] private GameObject projectile = null;
    [Range(0,1)][SerializeField] private float shootTiming = 0;
    private bool hasShoot;

    public override void HandleInput()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnEnter(PlayerController controller)
    {
        hasShoot = false;
        return;
    }
    
    protected override void OnUpdate(PlayerController controller)
    {
        if (internalCounter/skillDuration > shootTiming && !hasShoot)
        {
            var go = GameObject.Instantiate(projectile, controller.transform.position, Quaternion.identity);
            go.transform.rotation = Quaternion.LookRotation(direction);
            go.layer = LayerMask.NameToLayer("PlayerProjectile");
            hasShoot = true;
        }
        return;
    }
}
