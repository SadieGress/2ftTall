using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour
{
    float currentFloat = 0f;
    [SerializeField] float floatSpeed = 1f, waveAmplitude = 0.5f;

    void Update()
    {
        currentFloat += floatSpeed * Time.deltaTime;
        transform.position = new Vector3(0f, waveAmplitude * Mathf.Sin(currentFloat), 0f);
    }
}
