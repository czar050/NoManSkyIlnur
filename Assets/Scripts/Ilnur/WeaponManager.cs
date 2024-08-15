using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weapons; // Массив орудий

    private int currentWeaponIndex = 0;

    void Start()
    {
        EquipWeapon(currentWeaponIndex); // Начальное орудие
    }

    void Update()
    {
        // Переключение орудий с помощью клавиш 1 и 2
        /*if (Input.GetKeyDown(KeyCode.Alpha1)) // 1 - первое орудие
        {
            EquipWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // 2 - второе орудие
        {
            EquipWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // 3 - третье орудие (если есть)
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
        // Проверяем, находится ли индекс в пределах массива
        if (index < 0 || index >= weapons.Length)
            return;

        // Скрываем текущее орудие
        if (currentWeaponIndex >= 0 && currentWeaponIndex < weapons.Length)
        {
            weapons[currentWeaponIndex].SetActive(false);
        }

        // Обновляем индекс текущего орудия
        currentWeaponIndex = index;

        // Активируем новое орудие
        weapons[currentWeaponIndex].SetActive(true);
    }
}