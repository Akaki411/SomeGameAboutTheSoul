using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerState", menuName = "Character/OwnerState")]
public class PlayerStateOwner : PlayerState
{
    [Header("Бег")]
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _jumpforce = 5f;
    [SerializeField] private AnimationCurve dynamic;
    [SerializeField] private float _runFactor = 1f;
    
    [Header("Прочее")]
    [SerializeField] private GameObject soul;
    
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private float x;
    private bool _isRight;
    public override void Init()
    {
        _rigidbody = player.gameObject.GetComponent<Rigidbody2D>();
        _animator = player.gameObject.GetComponent<Animator>();
    }
    public override void Run()
    {
        x = Input.GetAxis("Horizontal");
        
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && player._isGround)
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

        if (player._isGround && _animator.GetBool("isJump"))
        {
            _animator.SetBool("isJump", false);
        }

        if (!player._isGround && !_animator.GetBool("isJump"))
        {
            _animator.SetBool("isJump", true);
        }

        if (x > 0 && !_isRight)
        {
            Flip(true);
        }

        if (x < 0 && _isRight)
        {
            Flip(false);
        }

        if (Input.GetKeyDown(KeyCode.Tab) && player.isActive)
        {
            GameObject clone = Instantiate(soul, player.transform.position, Quaternion.Euler(0, 0, 0));
            CameraMove.singleton.NewPurpose(clone);
            _animator.SetFloat("Run", 0);
            _animator.SetBool("isJump", false);
            player.Hide(true);
        }
    }
    public override void Exit()
    {
        
    }
    private void Move()
    {
        if (player._isGround)
        {
            _animator.SetFloat("Run", Mathf.Abs(x * _runFactor * 0.588f));
        }
        else if (!player._isGround && _animator.GetFloat("Run") != 0)
        {
            _animator.SetFloat("Run", 0);
        }
        _rigidbody.velocity = new Vector2(dynamic.Evaluate(x) * _speed * _runFactor, _rigidbody.velocity.y);
    }
    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpforce, ForceMode2D.Impulse);
    }

    private void Flip(bool right)
    {
        _isRight = right;
        Vector3 scale = player.transform.localScale;
        scale.x *= -1;
        player.transform.localScale = scale;
    }
}
