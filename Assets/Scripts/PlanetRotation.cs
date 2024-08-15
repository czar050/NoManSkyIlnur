using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    [SerializeField] private float _speed;
    void Update()
    {
        transform.Rotate(0, _speed * Time.deltaTime, 0);  
    }
}
