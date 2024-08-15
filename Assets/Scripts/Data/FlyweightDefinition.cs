using System;
using UnityEngine;

public enum FlyweightDefType
{
    ShotGun, ShotPlasma
}
public abstract class FlyweightDefinition : ScriptableObject
{
    [SerializeField] private string Id = "";
    [TextArea]
    [SerializeField] private string Name = "";

    public FlyweightDefType DefinitionType;
    public GameObject DefinitionPrefab;
    public abstract Flyweight Create();

    public virtual void OnGet(Flyweight flyweight)
    {
        flyweight.gameObject.SetActive(true);
    }
    public virtual void OnRelease(Flyweight flyweight)
    {
        flyweight.gameObject.SetActive(false);
    }
    public virtual void OnDestroyPooledObject(Flyweight flyweight)
    {
        Destroy(flyweight.gameObject);
    }

    protected void OnValodate()
    {
        if (Id == "")
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
