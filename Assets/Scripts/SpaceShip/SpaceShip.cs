using UnityEngine;

public enum ShipLogicType
{
    PlayerFighter,
    EnemyFighter,
    AllyFighter
}
public class SpaceShip : MonoBehaviour
{
    public GameAgent _shipAgent;
    public ShipLogicType ShipLogicType;
    public IInputShipMovement InputShipMovement;
    public IInputShipWeapons InputShipWeapons;

    private void OnEnable()
    {
        if(_shipAgent == null )
            _shipAgent = GetComponent<GameAgent>();
        if (InputShipMovement == null)
            InputShipMovement = GetComponent<IInputShipMovement>();
        if (InputShipWeapons == null)
            InputShipWeapons = GetComponent<IInputShipWeapons>();
    }
}
