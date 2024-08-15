using UnityEngine;

public class EngineLight : MonoBehaviour
{


    public Light myLight; // Ссылка на компонент Light
    public float minIntensity = 0.0f; // Минимальная интенсивность света
    public float maxIntensity = 1.0f; // Максимальная интенсивность света
    public float maxIntensityMove = 10.0f;
    public float transitionSpeed = 1.0f; // Скорость перехода между интенсивностью
    private bool _isMove = false;

    private float targetIntensity; // Целевая интенсивность
    private float currentIntensity; // Текущая интенсивность

    void Start()
    {
        // Получаем компонент Light, если он не был назначен
        if (myLight == null)
        {
            myLight = GetComponent<Light>();
        }

        currentIntensity = myLight.intensity;
        targetIntensity = maxIntensity; // Начнем с максимальной интенсивности
    }

    void Update()
    {
        if(_isMove)
        {
            // Плавно изменяем текущую интенсивность
            currentIntensity = Mathf.MoveTowards(currentIntensity, targetIntensity, transitionSpeed * Time.deltaTime);
            myLight.intensity = currentIntensity;

            // Если достигли целевой интенсивности, меняем цель
            if (Mathf.Approximately(currentIntensity, targetIntensity))
            {
                targetIntensity = targetIntensity == maxIntensity ? minIntensity : maxIntensity;
            }
        }
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _isMove = false;
            myLight.intensity = Mathf.MoveTowards(myLight.intensity, maxIntensityMove, transitionSpeed * Time.deltaTime);
        }
        else
        {
            _isMove = true;
        }
    }
}

