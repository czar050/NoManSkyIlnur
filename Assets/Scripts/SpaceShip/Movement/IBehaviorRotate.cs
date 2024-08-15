
using UnityEngine;

public interface IBehaviorRotate
{
    void Initialize(Rigidbody rigidbody, float pitchSpeed, float yawSpeed, float rollSpeed);
    void Turn(float inputPitch, float inputYaw, float inputRoll);
}
