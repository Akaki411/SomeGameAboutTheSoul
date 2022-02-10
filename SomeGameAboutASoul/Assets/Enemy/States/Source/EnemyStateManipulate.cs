using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyState", menuName = "Enemy/Manipulation")]
public class EnemyStateManipulate : EnemyState
{
    [Header("Бег")]
    [SerializeField] private AnimationCurve _xCurve;
    [SerializeField] private float _speed = 1f;
    
    [Header("Прыжок")]
    [SerializeField] private float _jumpForce;

    [Header("Прочее")] 
    [SerializeField] private GameObject soul;
    
    private float x;
    private float _runFactor = 1f;
    private Rigidbody2D _rigidbody;
    public override void Init()
    {
        _rigidbody = enemy.gameObject.GetComponent<Rigidbody2D>();
    }
    public override void Run()
    {
        x = Input.GetAxis("Horizontal");
        
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && enemy._isGround)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _runFactor = 1.7f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _runFactor = 1f;
        }
        Move();

        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject clone = Instantiate(soul, enemy.transform.position, Quaternion.Euler(0, 0, 0));
            CameraMove.singleton.NewPurpose(clone);
        }
    }
    public override void Exit()
    {
        
    }
    private void Move()
    {
        _rigidbody.velocity = new Vector2(_xCurve.Evaluate(x) * _speed * _runFactor, _rigidbody.velocity.y);
    }
    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse); 
    }
}
