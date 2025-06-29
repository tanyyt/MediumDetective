using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering.Universal;
using Random = UnityEngine.Random;

public class RandomIntensity : MonoBehaviour
{
    private Light2D m_Light2D;
    private float m_TargetIntensity;
    
    void Awake()
    {
        m_Light2D = GetComponent<Light2D>();
        m_TargetIntensity = Random.Range(0.8f, 1.2f);
    }

    void Update()
    {
        m_Light2D.intensity = Mathf.Lerp(m_Light2D.intensity, m_TargetIntensity, Time.deltaTime * 10f);
        if (Mathf.Approximately(m_Light2D.intensity, m_TargetIntensity))
        {
            m_TargetIntensity = Random.Range(0.8f, 1.2f);
        }
    }
}
