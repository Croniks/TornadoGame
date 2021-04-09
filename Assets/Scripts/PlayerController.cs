using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEvents;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public Joystick joystick;
    public Rigidbody rb;

    private Transform _selfTransform;
    private Vector3 _lastPosition;
    private PlayerControllerEvents _playerEvents;
    

    private void Awake()
    {
        _playerEvents = EventsProvider.Get<PlayerControllerEvents>();
        _selfTransform = GetComponent<Transform>();
        _lastPosition = _selfTransform.position;
    }

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        Vector3 force = direction * speed * Time.fixedDeltaTime;

        rb.AddForce(force, ForceMode.VelocityChange);

        if (!_selfTransform.position.Equals(_lastPosition))
        {
            _playerEvents.OnPlayerMoving?.Invoke(_selfTransform.position - _lastPosition);
            _lastPosition = _selfTransform.position;
        }
    }
}