﻿using UnityEngine;

public class CameraShake : MonoBehaviour {

    public Camera camTransform;       //흔들 카메라 위치
    private float shake = 0.0f;          //흔들리는 시간
    private float decreaseFactor = 1.0f;

    public float shakeAmount = 0.05f;    //카메라 흔들리는 정도. 숫자가 커질수록 거칠어짐

    void Update()
    {
        if (shake > 0.0f)
            shaking();
        else
            shake = 0.0f;
    }

    void setShake(float AddTime)
    {
        shake = AddTime;
    }

    void setshakeAmount(float amount)
    {
        shakeAmount = amount;
    }

    void shaking()
    {
        camTransform.transform.position += Random.insideUnitSphere * shakeAmount;
        shake -= Time.deltaTime * decreaseFactor;
    }

    void resetCamera()
    {
        Vector3 reset = new Vector3(0f, 0f, -10f);
        camTransform.transform.localPosition = reset;
    }
}