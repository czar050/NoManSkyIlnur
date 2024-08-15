using UnityEngine;

public class EngineLight : MonoBehaviour
{


    public Light myLight; // ������ �� ��������� Light
    public float minIntensity = 0.0f; // ����������� ������������� �����
    public float maxIntensity = 1.0f; // ������������ ������������� �����
    public float maxIntensityMove = 10.0f;
    public float transitionSpeed = 1.0f; // �������� �������� ����� ��������������
    private bool _isMove = false;

    private float targetIntensity; // ������� �������������
    private float currentIntensity; // ������� �������������

    void Start()
    {
        // �������� ��������� Light, ���� �� �� ��� ��������
        if (myLight == null)
        {
            myLight = GetComponent<Light>();
        }

        currentIntensity = myLight.intensity;
        targetIntensity = maxIntensity; // ������ � ������������ �������������
    }

    void Update()
    {
        if(_isMove)
        {
            // ������ �������� ������� �������������
            currentIntensity = Mathf.MoveTowards(currentIntensity, targetIntensity, transitionSpeed * Time.deltaTime);
            myLight.intensity = currentIntensity;

            // ���� �������� ������� �������������, ������ ����
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

