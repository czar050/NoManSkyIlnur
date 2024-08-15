using System.Collections.Generic;
using UnityEngine;

public class ManagerPlayerShips : MonoBehaviour
{
    public int _currentShipID;
    public Transform _shipVisual;
    public GameObject _currentShip;

    [SerializeField] private List<GameObject> _shipsPrefabs = new List<GameObject>();

    private void Update()
    {
        if(Input.GetButtonDown("ShipChange"))
        {
            ChangeShipToNext();
        }
    }

    private void ChangeShipToNext()
    {
        _currentShipID++;
        if(_currentShipID == _shipsPrefabs.Count)
        {
            _currentShipID = 0;
        }

        ChangeShip(_currentShipID);
    }


    private void ChangeShip(int ID)
    {
        Destroy(_currentShip);

        _currentShip = Instantiate(_shipsPrefabs[_currentShipID], _shipVisual);
    }
}
