using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState", menuName = "Character/HumanState")]
public class PlayerStateHuman : PlayerState
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _jumpforce = 5f;
    [SerializeField] private AnimationCurve dynamic;

    private Rigidbody2D _rigidbody;
    private float x;
    private float y;
    
    public override void Init()
    {
        _rigidbody = player.gameObject.GetComponent<Rigidbody2D>();
    }
    public override void Run()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        
        Move();

        if (y > 0.8f || Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }
    public override void Exit()
    {
        
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(dynamic.Evaluate(x) * _speed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpforce, ForceMode2D.Impulse);
    }
}
