using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Состояния")]
    [SerializeField] private PlayerState _human;
    [SerializeField] private PlayerState _void;
    [SerializeField] private float _hideSpeed;
    
    [Header("Прыжок")]
    [SerializeField] private LayerMask _ground;
    [SerializeField] public Vector3 _groundOffset;
    [SerializeField] public float _groundCheckSize;
    
    private PlayerState _currentState;
    private Rigidbody2D _rigidbody;
    private Collider2D _foot;
    private SpriteRenderer _spriteRenderer;
    public bool isActive { get; private set; }
    public bool _isGround { get; private set; }
    private void Start()
    {
        _currentState = _human;
        _currentState.player = this;
        _currentState.Init();
        isActive = true;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _currentState.Run();

        if (isActive)
        {
            _foot = Physics2D.OverlapCircle(transform.position + _groundOffset, _groundCheckSize, _ground);
            _isGround = _foot;
        }
    }

    public void Hide(bool hide)
    {
        if (hide)
        {
            ChangeState(_void);
            _rigidbody.velocity = new Vector2(0, 0);
            StartCoroutine(HideCharacter());
        }
        else
        {
            ChangeState(_human);
            StartCoroutine(ShowCharacter());
        }
    }
    private void ChangeState(PlayerState state)
    {
        _currentState.Exit();
        _currentState = state;
        _currentState.player = this;
        _currentState.Init();
    }
    private IEnumerator HideCharacter()
    {
        Color c;
        for (float i = _spriteRenderer.color.a; i > 0.15f; i -= Time.deltaTime * _hideSpeed)
        {
            c = _spriteRenderer.color;
            c.a = i;
            _spriteRenderer.color = c;
            yield return null;
        }
        c = _spriteRenderer.color;
        c.a = 0.15f;
        _spriteRenderer.color = c;
        isActive = false;
    }
    private IEnumerator ShowCharacter()
    {
        Color c;
        for (float i = _spriteRenderer.color.a; i < 1; i += Time.deltaTime * _hideSpeed)
        {
            c = _spriteRenderer.color;
            c.a = i;
            _spriteRenderer.color = c;
            yield return null;
        }
        c = _spriteRenderer.color;
        c.a = 1;
        _spriteRenderer.color = c;
        isActive = true;
    }
}
