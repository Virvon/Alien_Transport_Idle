using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraZoom : MonoBehaviour
{
    [SerializeField] private float _zoomSpeed;

    private Vector3 _defaultPosition;

    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _defaultPosition = transform.position;
    }

    public void ActiveZoom(Transform target, float value)
    {
        if(_camera.IsBlocked == true)
        {
            if (target == null)
                return;

            Vector3 zoomPosition = new Vector3(target.position.x, target.position.y + value, target.position.z - CalculateHorizonDistance(value));
            StartCoroutine(TakeNewPosition(zoomPosition, _zoomSpeed));
        }
    }

    public void DeactiveZoom()
    {
        Vector3 zoomPosition = _defaultPosition;
        StartCoroutine(TakeNewPosition(zoomPosition, _zoomSpeed));
    }

    private float CalculateHorizonDistance(float height)
    {
        return (Mathf.Sqrt(Mathf.Pow(height / Mathf.Sin(transform.rotation.x), 2) - Mathf.Pow(height, 2))) / 2;
    }

    private IEnumerator TakeNewPosition(Vector3 targetPosition, float movingTime)
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movingTime * Time.deltaTime);
            yield return null;
        }
    }
}
