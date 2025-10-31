using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IMovable, ITurnable
{
    public enum PlayerState
    {
        idle,
        move,
        attack
    }

    PlayerState currentState = PlayerState.idle;

    [SerializeField] Rigidbody2D _rbody;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _attackRenge;
    [SerializeField] float _defSize = 6;
    [SerializeField] float _moveSpeed;
    Vector2 _moveInput;
    Vector2 _rotation = Vector2.right;

    private void Start()
    {
        _moveSpeed = CSVDataBase.playerStatus.MoveSpeed;
    }

    private void Update()
    {
        if (currentState == PlayerState.attack)
        {
            _rbody.linearVelocityX = 0;
            PlayAnimation();
            return;
        }

        if (_moveInput.x < 0)
        {
            TurnLeft();
        }
        else if (_moveInput.x > 0)
        {
            TurnRight();
        }

        if (_moveInput.x != 0)
        {
            Move();
        }
        else
        {
            _rbody.linearVelocityX = 0;
                ChangeState(PlayerState.idle);
        }


        PlayAnimation();
    }

    public void ChangeState(PlayerState nextState)
    {
        if (currentState == nextState) return;
        EndState();
        currentState = nextState;
    }

    void EndState()
    {
        switch (currentState)
        {
            case PlayerState.move:
                _animator.SetBool("isMove", false);
                break;
            case PlayerState.attack:
                _animator.SetBool("isAttack", false);
                break;
        }
    }

    void PlayAnimation()
    {
        switch (currentState)
        {
            case PlayerState.move:
                _animator.SetBool("isMove", true);
                break;
            case PlayerState.attack:
                _animator.SetBool("isAttack", true);
                break;
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void Move()
    {
        ChangeState(PlayerState.move);
        _rbody.linearVelocityX = _moveInput.x * _moveSpeed;
    }


    public void TurnLeft()
    {
        _rotation = Vector2.left;
        transform.localScale = new Vector2(_rotation.x, 1) * _defSize;
        _attackRenge.transform.position = new Vector2(transform.position.x - 1.0f, transform.position.y);
    }

    public void TurnRight()
    {
        _rotation = Vector2.right;
        transform.localScale = new Vector2(_rotation.x, 1) * _defSize;
        _attackRenge.transform.position = new Vector2(transform.position.x + 1.0f, transform.position.y);
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ChangeState(PlayerState.attack);
            _attackRenge.SetActive(true);
        }
        else if (context.canceled)
        {
            ChangeState(PlayerState.idle);
            _attackRenge.SetActive(false);
        }
    }
}
