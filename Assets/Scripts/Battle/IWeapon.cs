using UnityEngine;

public interface IWeapon
{
    Vector3 FireWeapon(Vector3 targetPosition);
    //void Damage(float _damageAmount, Vector3 targetHitPosition, GameAgent sender);
    void Initialize(DataWeaponExtrinsic dataWeaponExtrinsic);
    void VizualizeFireWeapon(Vector3 targetPosition);
}
