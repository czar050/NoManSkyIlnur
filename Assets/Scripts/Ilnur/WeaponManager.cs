using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weapons; // ������ ������

    private int currentWeaponIndex = 0;

    void Start()
    {
        EquipWeapon(currentWeaponIndex); // ��������� ������
    }

    void Update()
    {
        // ������������ ������ � ������� ������ 1 � 2
        /*if (Input.GetKeyDown(KeyCode.Alpha1)) // 1 - ������ ������
        {
            EquipWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // 2 - ������ ������
        {
            EquipWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // 3 - ������ ������ (���� ����)
        {
            EquipWeapon(2);
        }*/

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapons[0].SetActive(true);
            weapons[1].SetActive(true);
            weapons[2].SetActive(false);
            weapons[3].SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(false);
            weapons[2].SetActive(true);
            weapons[3].SetActive(true);
        }
    }

    void EquipWeapon(int index)
    {
        // ���������, ��������� �� ������ � �������� �������
        if (index < 0 || index >= weapons.Length)
            return;

        // �������� ������� ������
        if (currentWeaponIndex >= 0 && currentWeaponIndex < weapons.Length)
        {
            weapons[currentWeaponIndex].SetActive(false);
        }

        // ��������� ������ �������� ������
        currentWeaponIndex = index;

        // ���������� ����� ������
        weapons[currentWeaponIndex].SetActive(true);
    }
}