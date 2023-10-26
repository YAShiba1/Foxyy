using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _followingTarget;
    [SerializeField, Range(0f, 1f)] private float _parallaxStrenght = 0.1f;
    [SerializeField] private bool _disableVerticalParallax;
    [SerializeField] private bool _disableHorizontParallax;

    private Vector3 _targetPreviousPosition;

    private void Start()
    {
        if (_followingTarget == false)
        {
            _followingTarget = Camera.main.transform;
        }

        _targetPreviousPosition = _followingTarget.position;
    }

    private void Update()
    {
        var delta = _followingTarget.position - _targetPreviousPosition;

        if (_disableVerticalParallax)
        {
            delta.y = 0;
        }

        if (_disableHorizontParallax)
        {
            delta.x = 0;
        }

        _targetPreviousPosition = _followingTarget.position;

        transform.position += delta * _parallaxStrenght;
    }
}
