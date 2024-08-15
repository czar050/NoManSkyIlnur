using UnityEngine;
using System;

public class ShipLogicEnemyFighter : MonoBehaviour, IInputShipMovement, IInputShipWeapons
{
    [field: Header("Ship Movement Values")]
    [field: SerializeField] public float CurrentInputMove { get; private set; }
    [field: SerializeField] public float CurrentInputRotatePitch { get; private set; }
    [field: SerializeField] public float CurrentInputRotateYaw { get; private set; }
    [field: SerializeField] public float CurrentInputRotateRoll { get; private set; }

    [field: Header("Ship Attack Values")]
    [field: SerializeField] public bool CurrentInputAttack { get; private set; }
    public event Action OnAttackInput;


    [SerializeField] private float MovementSpeedDefault = 1f;
    [SerializeField] private float RotationSpeedDefault = 4f;

    private Rigidbody _shipRigidbody;
    [SerializeField] private GameObject _target;

    private void Awake()
    {
        if(_shipRigidbody == null)
            _shipRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Think();
    }

    private void Think()
    {
        if(_target == null)
        {
            _target = GameObject.FindGameObjectWithTag("Player");
        }

        if(_target != null)
        {
            OnAttackInput?.Invoke();
            CurrentInputMove = MovementSpeedDefault;
            var direction = _target.transform.position - _shipRigidbody.position;
            Debug.DrawRay(_shipRigidbody.position, direction.normalized * 100, Color.red);

            var desiredRotation = Quaternion.LookRotation(direction);
            var lerpRotation = Quaternion.Slerp(_shipRigidbody.rotation, desiredRotation, RotationSpeedDefault * Time.deltaTime);
            var lerpRotationVector3 = lerpRotation.eulerAngles;

            CurrentInputRotatePitch = lerpRotationVector3.x;
            CurrentInputRotateYaw = lerpRotationVector3.y;
            CurrentInputRotateRoll = lerpRotationVector3.z;
        }
    }
}
