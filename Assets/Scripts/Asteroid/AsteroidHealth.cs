using UnityEngine;

public class AsteroidHealth : MonoBehaviour, IDamageable
{
    public float Health { get; }
    [SerializeField] private GameObject _explosionPrefab;

    public void ReceiveDamage(float damageAmount, Vector3 hitPosition, GameAgent sender)
    {
        ManagerScore.Instance.AddScore(1);
        Destroy(Instantiate(_explosionPrefab, transform.position, Quaternion.identity),2);
        Destroy(gameObject);
    }

    public void ReceiveHealth(float healAmount, Vector3 hitPosition, GameAgent sender)
    {
        throw new System.NotImplementedException();
    }
}
