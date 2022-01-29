using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[CreateAssetMenu(fileName = "CameraState", menuName = "Camera/NormalState")]
public class CameraStateNormal : CameraState
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private int size = 5;
    [SerializeField] private float sizeSpeed = 1f;

    [SerializeField] private Vector3 offset;

    private PixelPerfectCamera _camera;

    private int width;
    private int height;
    
    public override void Init()
    {
        _camera = camera.gameObject.GetComponent<PixelPerfectCamera>();
        width = size;
        height = (int)(size * (9f / 16f));
        _camera.refResolutionX = width;
        _camera.refResolutionY = height;
    }

    public override void Run()
    {
        if (_camera.refResolutionX - width != 0 || _camera.refResolutionY - height != 0)
        {
            _camera.refResolutionX = (int) Mathf.Lerp(_camera.refResolutionX, width, sizeSpeed);
            _camera.refResolutionY = (int) Mathf.Lerp(_camera.refResolutionY, height, sizeSpeed);
        }

        camera.transform.position = Vector3.Lerp(camera.transform.position, camera.purpose.transform.position + offset, speed);
    }

    public override void ChangeSize(int size)
    {
        width = size;
        height = (int) (size * (9f / 16f));
    }
}
