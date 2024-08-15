using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _pitchSpeed = 125000f;
    [SerializeField] private float _yawSpeed = 125000f;
    [SerializeField] private float _rollSpeed = 125000f;
    [SerializeField] private float _moveSpeed = 125000f;
    [Range(0.5f, 50f)]
    [SerializeField] private float _prorortionalAngularDrag = 5f;
    [Range(10f, 1000f)]
    [SerializeField] private float _prorortionalDrag = 100f;


    [SerializeField] private Engine _engine;

    public SpaceShip _spaceShip;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private List<Engine> Engines = new List<Engine>();
    [SerializeField] private IBehaviorRotate _behaviorRotate;

    private void OnEnable()
    {
        if (_spaceShip.ShipLogicType == ShipLogicType.PlayerFighter)
        {
            _behaviorRotate = gameObject.AddComponent<BehaviorRotateAddTorque>();
        }
        else if(_spaceShip.ShipLogicType == ShipLogicType.EnemyFighter)
        {
            _behaviorRotate = gameObject.AddComponent<BehaviorRotateQuaternion>();
        }
        _behaviorRotate.Initialize(_rigidbody, _pitchSpeed, _yawSpeed, _rollSpeed);
    }

    void FixedUpdate()
    {
        _behaviorRotate.Turn(_spaceShip.InputShipMovement.CurrentInputRotatePitch,
            _spaceShip.InputShipMovement.CurrentInputRotateYaw,
            _spaceShip.InputShipMovement.CurrentInputRotateRoll);
        Move(_spaceShip.InputShipMovement.CurrentInputMove);
    }

    

    private void Move(float inputMove)
    {
        Vector3 resultingThrust = new Vector3();
        resultingThrust = resultingThrust + _engine.Thrust(inputMove);
        //_spaceShip.Translate(resultingThrust);

        _rigidbody.AddForce(resultingThrust * _moveSpeed * Time.fixedDeltaTime);
        _rigidbody.AddForce(-_rigidbody.velocity * _prorortionalDrag * Time.fixedDeltaTime);
    }
}
