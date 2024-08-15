using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class WeaponSpawner : MonoBehaviour, IWeapon
{
    [SerializeField] private FlyweightDefinition _flyweightDefinition;

    [SerializeField] private WeaponSpanerDefinition _weaponSpanerDefinition;

    private DataWeaponExtrinsic _dataWeaponExtrinsic;

    // Serialized for Debug
    [Header("Inner Workings")]
    [SerializeField] private bool _canFire = true;

    //private WaitForSeconds _waitForSecondsSpawning;
    private float _waitTimeSpawning => _weaponSpanerDefinition._cooldownTimeTotal;

    private WaitForSeconds _waitForSecondsMuzzleFlash;
    [SerializeField] private float _waitTimeMuzzleFlash = 0.05f;

    [Header("Links")]
    [SerializeField] private Transform _muzzle;
    [SerializeField] private GameObject _muzzleFlash;


    private void OnEnable()
    {
        _canFire = true;
    }

    public void Initialize(DataWeaponExtrinsic dataWeaponExtrinsic)
    {
        _dataWeaponExtrinsic = dataWeaponExtrinsic;
        _waitForSecondsMuzzleFlash = new WaitForSeconds(_waitTimeMuzzleFlash);
    }



    public Vector3 FireWeapon(Vector3 targetPosition)
    {
        if (!_canFire) return Vector3.zero;
        var spawned = FactoryFlyweight.Instance.Spawn(_flyweightDefinition, transform.position, Quaternion.LookRotation(targetPosition - transform.position));
        spawned.GetComponent<IWeaponSpawneable>().Initialize(_dataWeaponExtrinsic);
        VizualizeFireWeapon(targetPosition);

        StartCoroutine(ExecuteCooldown(_waitTimeSpawning));

        return Vector3.zero;
    }

    // _muzzle VFX
    public void VizualizeFireWeapon(Vector3 targetPosition)
    {
        if(_muzzleFlash != null)
        {
            StartCoroutine(VizualizeMuzzleflash(targetPosition));
        }
    }

    private IEnumerator VizualizeMuzzleflash(Vector3 targetPosition)
    {
        _muzzleFlash.transform.rotation = Quaternion.LookRotation(targetPosition - transform.position);
        _muzzleFlash.SetActive(true);

        yield return _waitForSecondsMuzzleFlash;
        _muzzleFlash.SetActive(false);
    }
    private IEnumerator ExecuteCooldown(float delay)
    {
        _canFire = false;

        yield return new WaitForSeconds(delay);
        _canFire = true;
    }

}
