using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShipWeapons : MonoBehaviour
{
    public SpaceShip _spaceShip;
    [SerializeField] private Rigidbody _shipRigidbody;
    public List<IWeapon> Weapons = new List<IWeapon>();

    public float _maxDistanceToTarget = 250f;

    [SerializeField] public LayerMask _layerMask;

    private void Awake()
    {
        if (_spaceShip == null)
            _spaceShip = GetComponentInParent<SpaceShip>();
        if (_shipRigidbody == null)
                _shipRigidbody = GetComponentInParent<Rigidbody>();
    }

    [ContextMenu("InitWeapons")]
    private void InitWeapons()
    {
        Weapons = GetComponentsInChildren<IWeapon>().ToList();
        foreach (var weapon in Weapons)
        {
            weapon.Initialize(new DataWeaponExtrinsic() {_shipRigidbody = _shipRigidbody, GameAgent = _spaceShip._shipAgent});
        }
    }

    private void OnEnable()
    {
        InitWeapons();
        _spaceShip.InputShipWeapons.OnAttackInput += FireWeapons;
    }
    private void OnDisable()
    {
        _spaceShip.InputShipWeapons.OnAttackInput -= FireWeapons;

    }

    public void FireWeapons()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay( new Vector3(0.5f, 0.5f, 0));  
        if(Physics.Raycast(ray, out hit, _maxDistanceToTarget, _layerMask))
        {
            foreach (var weapon in Weapons)
            {
                weapon.FireWeapon(hit.point);
            }
        }
        else
        {
            foreach (var weapon in Weapons)
            {
                weapon.FireWeapon(ray.origin + ray.direction * _maxDistanceToTarget);
            }
        }
    }
}
