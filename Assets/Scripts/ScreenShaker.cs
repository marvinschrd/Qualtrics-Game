using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaker : MonoBehaviour
{

    private float screenShakeTime = 0f;
    [SerializeField]private float screenShakeMagnitude = 0.1f;
    [SerializeField]private float fadingSpeed = 1.0f;

    private float initialScreenShakeTime = 0f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        if (screenShakeTime > 0f)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * screenShakeMagnitude * (screenShakeTime / initialScreenShakeTime);

            screenShakeTime -= Time.deltaTime * fadingSpeed;
        }
        else
        {
            screenShakeTime = 0f;
            transform.localPosition = initialPosition;
        }
    }

    public void TriggerShake(float time)
    {
        screenShakeTime = time;
        initialScreenShakeTime = time;
    }
}
