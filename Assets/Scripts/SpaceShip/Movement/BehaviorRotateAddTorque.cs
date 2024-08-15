using UnityEngine;

public class BehaviorRotateAddTorque : MonoBehaviour, IBehaviorRotate
{
    [SerializeField] private float _pitchSpeed = 125000f;
    [SerializeField] private float _yawSpeed = 125000f;
    [SerializeField] private float _rollSpeed = 125000f;
    [Range(0.5f, 50f)]
    [SerializeField] private float _prorortionalAngularDrag = 5f;

    [SerializeField] private Rigidbody _rigidbody;

    public void Initialize(Rigidbody rigidbody, float pitchSpeed, float yawSpeed, float rollSpeed)
    {
        _rigidbody = rigidbody;
        _pitchSpeed = pitchSpeed;
        _yawSpeed = yawSpeed;
        _rollSpeed = rollSpeed;
    }
    public void Turn(float inputPitch, float inputYaw, float inputRoll)
    {
        if (!Mathf.Approximately(0f, inputPitch))
        {
            _rigidbody.AddTorque(transform.right * inputPitch * _pitchSpeed * Time.fixedDeltaTime);
        }
        if (!Mathf.Approximately(0f, inputYaw))
        {
            _rigidbody.AddTorque(transform.up * inputYaw * _yawSpeed * Time.fixedDeltaTime);
        }
        if (!Mathf.Approximately(0f, inputRoll))
        {
            _rigidbody.AddTorque(transform.forward * inputRoll * _rollSpeed * Time.fixedDeltaTime);
        }

        _rigidbody.AddTorque(-_rigidbody.angularVelocity * _prorortionalAngularDrag * Time.fixedDeltaTime);

    }
}
