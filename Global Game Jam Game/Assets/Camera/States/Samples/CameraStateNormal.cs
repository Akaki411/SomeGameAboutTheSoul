using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraState", menuName = "Camera/NormalState")]
public class CameraStateNormal : CameraState
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float size = 5f;
    [SerializeField] private float sizeSpeed = 1f;

    [SerializeField] private Vector3 offset;

    private Camera _camera;
    public override void Init()
    {
        _camera = camera.gameObject.GetComponent<Camera>();
    }

    public override void Run()
    {
        if (Math.Abs(size - _camera.orthographicSize) > 0.02f)
        {
            _camera.orthographicSize = Mathf.SmoothStep(_camera.orthographicSize, size, sizeSpeed);
        }

        camera.transform.position = Vector3.Lerp(camera.transform.position, camera.purpose.transform.position + offset, speed);
    }

    public override void ChangeSize(float size)
    {
        this.size = size;
    }
}
