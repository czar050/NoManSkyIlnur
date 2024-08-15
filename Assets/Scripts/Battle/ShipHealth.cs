using UnityEngine;

public class ShipHealth : MonoBehaviour, IDamageable
{
    public float _health;
    [SerializeField] private GameObject _explosion;
    public float Health => _health;

    private void Start()
    {
        
    }

    public void ReceiveDamage(float damageAmount, Vector3 hitPosition, GameAgent sender)
    {
        _health -= damageAmount;
        if(_health < 0)
        {
            Debug.Log($"Attacker: {sender.gameObject.name}");
            Debug.Log($"Attacker fraction: {sender.ShipFraction}");
            Destroy(Instantiate(_explosion, transform.position, Quaternion.identity), 3);  
            Destroy(gameObject);
        }
    }

    public void ReceiveHealth(float healAmount, Vector3 hitPosition, GameAgent sender)
    {
        throw new System.NotImplementedException();
    }
}
