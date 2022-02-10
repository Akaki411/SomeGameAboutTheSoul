using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private AnimationCurve _xCurve;
    [SerializeField] private AnimationCurve _yCurve;

    private float x;
    private float y;

    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        _rigidbody.velocity = new Vector2(_xCurve.Evaluate(x) * _speed, _yCurve.Evaluate(y) * _speed);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (other.TryGetComponent(out Reach enemy))
            {
                enemy.StartManipulate();
                CameraMove.singleton.NewPurpose(enemy.GetParent());
                Destroy(gameObject);
            }
        }
    }
}
