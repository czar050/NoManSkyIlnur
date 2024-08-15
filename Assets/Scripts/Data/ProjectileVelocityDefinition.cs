using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Def Proj Velocity Default", menuName = "Definition/Battle/ProjectileVelocityDefinition")]
public class ProjectileVelocityDefinition : ScriptableObject
{
    [SerializeField] private string Id = "";
    [TextArea]
    [SerializeField] private string Name = "";


    [SerializeField] public float Velocity = 300f;

    private void OnValodate()
    {
        if (Id == "")
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
