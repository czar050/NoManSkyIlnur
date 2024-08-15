using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultExecutionOrder WS Default", menuName = "Definition/Battle/WeaponSpawnerDefinition")]
public class WeaponSpanerDefinition : ScriptableObject
{
    [SerializeField] private string Id = "";
    [TextArea] 
    [SerializeField] private string Name = "";

    [Range(0f, 5f)]
    public float _cooldownTimeTotal = 0.25f;
    private void OnValodate()
    {
        if(Id == "")
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
