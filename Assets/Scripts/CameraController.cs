using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEvents;


[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    private Transform _selfTransform;
    private PlayerControllerEvents _playerEvents;
    
    
    private void Awake()
    {
        _selfTransform = GetComponent<Transform>();
        _playerEvents = EventsProvider.Get<PlayerControllerEvents>();
        _playerEvents.OnPlayerMoving += OnPlayerMoving;
    }
    
    private void OnPlayerMoving(Vector3 deltaPlayerPosition)
    {
        _selfTransform.position += deltaPlayerPosition;
    }
}