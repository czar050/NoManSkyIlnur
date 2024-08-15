using UnityEngine;

[CreateAssetMenu(fileName = "Def Proj Default", menuName = "Definition/Battle/ProjectileDefinition")]
public class ProjectileDefinition : FlyweightDefinition
{

    //[SerializeField] public float Velocity = 300f;
    [SerializeField] public ProjectileVelocityDefinition _projectileVelocityDefinition;
    [SerializeField] public float Damage = 100f;
    [SerializeField] public float LifetimeTotal = 10f; // Time before we destroy it (so it won't impact performance)
    [SerializeField] public LayerMask LayerMask;
    [SerializeField] public float RaycastDistance = 1.5f; // Raycast advance multiplier 
    [SerializeField] public float DelayAfterHit = 0.1f;
    [Header("Links")]
    [SerializeField] public GameObject ImpactPrefab;

    public override Flyweight Create()
    {
        var gameObject = Instantiate(DefinitionPrefab);
        gameObject.SetActive(false);
        gameObject.name = DefinitionPrefab.name;
        var flyweight = gameObject.AddComponent<Projectile>();
        flyweight.Definition = this;
        return flyweight;
    }
}
