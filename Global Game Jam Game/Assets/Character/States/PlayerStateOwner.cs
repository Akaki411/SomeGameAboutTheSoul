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
    private float x;
    public override void Init()
    {
        _rigidbody = player.gameObject.GetComponent<Rigidbody2D>();
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

        if (Input.GetKeyDown(KeyCode.Tab) && player.isActive)
        {
            GameObject clone = Instantiate(soul, player.transform.position, Quaternion.Euler(0, 0, 0));
            CameraMove.singleton.NewPurpose(clone);
            player.Hide(true);
        }
    }
    public override void Exit()
    {
        
    }
    private void Move()
    {
        _rigidbody.velocity = new Vector2(dynamic.Evaluate(x) * _speed * _runFactor, _rigidbody.velocity.y);
    }
    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpforce, ForceMode2D.Impulse);
    }
}
