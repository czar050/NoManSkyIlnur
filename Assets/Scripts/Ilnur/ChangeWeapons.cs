using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Weapon
{
    public string weaponName;
    public GameObject weaponPrefab; // ������ ������
}

public class ChangeWeapons : MonoBehaviour
{
    public List<Weapon> weapons; // ������ ��������� ������
    private int currentWeaponIndex = 0;
    private GameObject currentWeaponObject;

    void Start()
    {
        EquipWeapon(currentWeaponIndex); // ��������� ������
    }

    void Update()
    {
        // ������������ ������ � ������� ������ 1 � 2
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 1 - ������ ������
        {
            EquipWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // 2 - ������ ������
        {
            EquipWeapon(1);
        }
        // �������� �������������� ������� ��� ������ ������, ���� �����
    }

    void EquipWeapon(int index)
    {
        if (currentWeaponObject != null)
        {
            Destroy(currentWeaponObject); // ���������� ������� ������
        }

        currentWeaponIndex = index;
        Weapon weaponToEquip = weapons[currentWeaponIndex];
        currentWeaponObject = Instantiate(weaponToEquip.weaponPrefab, transform.position, transform.rotation);
        currentWeaponObject.transform.SetParent(transform); // ������� ������ �������� �������� ������ ��� ������� �������
    }
}