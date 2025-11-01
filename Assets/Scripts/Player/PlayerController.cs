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

    PlayerState _currentState = PlayerState.idle;

    [SerializeField] Rigidbody2D _rbody;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _attackRenge;
    [SerializeField] GameObject _interactiveRenge;
    [SerializeField] GameObject _createCursor;
    [SerializeField] float _defSize = 6;
    float _moveSpeed;
    Vector2 _moveInput;
    Vector2 _rotation = Vector2.right;

    public float MoveSpeed => _moveSpeed;

    private void Start()
    {
        _moveSpeed = CSVDataBase.playerStatus.MoveSpeed;
    }

    private void Update()
    {
        if (_currentState == PlayerState.attack)
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
        if (_currentState == nextState) return;
        EndState();
        _currentState = nextState;
    }

    void EndState()
    {
        switch (_currentState)
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
        switch (_currentState)
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
    }

    public void TurnRight()
    {
        _rotation = Vector2.right;
        transform.localScale = new Vector2(_rotation.x, 1) * _defSize;
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
