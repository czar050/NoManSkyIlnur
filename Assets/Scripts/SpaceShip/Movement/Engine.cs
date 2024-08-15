using System;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    [Serializable]
    class EngineVisuals
    {
        [SerializeField] private ParticleSystem _particleSysstem;
        [SerializeField] private float _psEmittedMax = 50;
        [SerializeField] private float _psEmittedMin = 0;
        [SerializeField] private float _visualizationLerpRate = 0.25f;
        [SerializeField] private float _psEmittedCurrently = 50f;
        [SerializeField] private float _vizualizationCurrentlyNormalized = 0f;

        public void VizualeThrust(float inputMove)
        {
            var emission = _particleSysstem.emission;
            _vizualizationCurrentlyNormalized = Mathf.Lerp(_vizualizationCurrentlyNormalized, inputMove, _visualizationLerpRate);
            _psEmittedCurrently = _psEmittedMax * _vizualizationCurrentlyNormalized;
            emission.rateOverTime = Mathf.Max(_psEmittedCurrently, _psEmittedMin);
        }
    }

    [SerializeField] private float _moveSpeed = 100f;
    [SerializeField] private List<EngineVisuals> _engineVisuials = new List<EngineVisuals>();

    public Vector3 Thrust(float inputMove)
    {
        VisualizeThrust(inputMove);
        var calculatedThrust = inputMove * _moveSpeed;     
        return -transform.forward * calculatedThrust;
    }
    private void VisualizeThrust(float inputMove)
    {
        foreach (var ev in _engineVisuials)
        {
            ev.VizualeThrust(inputMove);
        }
    }
}
