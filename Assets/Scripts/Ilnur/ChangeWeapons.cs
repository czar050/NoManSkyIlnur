using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Weapon
{
    public string weaponName;
    public GameObject weaponPrefab; // Префаб орудия
}

public class ChangeWeapons : MonoBehaviour
{
    public List<Weapon> weapons; // Список доступных орудий
    private int currentWeaponIndex = 0;
    private GameObject currentWeaponObject;

    void Start()
    {
        EquipWeapon(currentWeaponIndex); // Начальное орудие
    }

    void Update()
    {
        // Переключение орудий с помощью клавиш 1 и 2
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 1 - первое орудие
        {
            EquipWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // 2 - второе орудие
        {
            EquipWeapon(1);
        }
        // Добавьте дополнительные клавиши для других орудий, если нужно
    }

    void EquipWeapon(int index)
    {
        if (currentWeaponObject != null)
        {
            Destroy(currentWeaponObject); // Уничтожаем текущее орудие
        }

        currentWeaponIndex = index;
        Weapon weaponToEquip = weapons[currentWeaponIndex];
        currentWeaponObject = Instantiate(weaponToEquip.weaponPrefab, transform.position, transform.rotation);
        currentWeaponObject.transform.SetParent(transform); // Сделаем орудие дочерним объектом игрока или другого объекта
    }
}