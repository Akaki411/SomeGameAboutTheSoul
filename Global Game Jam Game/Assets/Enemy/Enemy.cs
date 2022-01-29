using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Состояния")]
    [SerializeField] private EnemyState manipulationState;
    [SerializeField] private EnemyState idleState;
    
    [Header("Прыжок")]
    [SerializeField] private LayerMask _ground;
    [SerializeField] public Vector3 _groundOffset;
    [SerializeField] public float _groundCheckSize;
    
    [Header("Характеристики")]
    [SerializeField] private int strength = 1;
    
    public bool _isGround { get; private set; }
    private Collider2D _foot;
    private EnemyState _currentState;
    
    private void Start()
    {
        ChangeState(idleState);
    }
    private void Update()
    {
        _currentState.Run();
        _foot = Physics2D.OverlapCircle(transform.position + _groundOffset, _groundCheckSize, _ground);
        _isGround = _foot;
    }
    public void StartManipulate()
    {
        ChangeState(manipulationState);
    }
    public void SelectState()
    {
        ChangeState(idleState);
    }

    private void ChangeState(EnemyState state)
    {
        _currentState?.Exit();
        _currentState = state;
        _currentState.enemy = this;
        _currentState.Init();
    }
}
