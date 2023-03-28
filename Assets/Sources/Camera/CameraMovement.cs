using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 1;

    private Rigidbody _rigidbody;

    private Camera _camera;

    private CameraInput _cameraInput;

    private Vector2 _deltaPosition;

    private void Awake()
    {
        _cameraInput = new CameraInput();
        _cameraInput.Enable();
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (_camera.IsBlocked == false)
        {
            _deltaPosition = _cameraInput.Camera.Move.ReadValue<Vector2>();

            if(_deltaPosition != Vector2.zero)
                _rigidbody.velocity = new Vector3(-1 * _deltaPosition.x * _sensitivity, 0, -1 * _deltaPosition.y * _sensitivity);
        }
    }
}
