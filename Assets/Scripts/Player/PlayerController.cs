using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IMovable, ITurnable, ICreatable, IShotable
{
    public enum PlayerState
    {
        idle,
        move,
        attack
    }

    PlayerState _currentState = PlayerState.idle;

    [SerializeField] AudioSource _audioSource;
    [SerializeField] ArrowFactory _arrowFactory;
    [SerializeField] BombFactory _bombFactory;
    [SerializeField] Rigidbody2D _rbody;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _attackRenge;
    [SerializeField] GameObject _interactiveCursor;
    [SerializeField] float _defSize = 6;
    [SerializeField] float _bowCoolTime = 0.2f;
    float _moveSpeed;
    Vector2 _moveInput;
    Vector2 _rotation = Vector2.right;
    bool isBowAttack; //弓攻撃中かどうか
    float _timer;

    public float MoveSpeed => _moveSpeed;

    private void Start()
    {
        _moveSpeed = CSVDataBase.playerStatus.MoveSpeed;
    }

    private void Update()
    {
        if (GameManager.currentState != GameManager.GameState.play) return;

        if (_currentState == PlayerState.attack)
        {
            _rbody.linearVelocityX = 0;
            PlayAnimation();
            if (!_audioSource.isPlaying)
                _audioSource.Play();
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

        if (isBowAttack && _timer >= _bowCoolTime)
        {
            _timer = 0;
            Shot();
        }
        _timer += Time.deltaTime;
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

    public void OnCollection(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ChangeState(PlayerState.attack);
        }
        else if (context.performed)
        {
            _attackRenge.SetActive(true);
        }
        else if (context.canceled)
        {
            ChangeState(PlayerState.idle);
            _attackRenge.SetActive(false);
        }
    }

    public void OnBowAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isBowAttack = true;
        }
        else if (context.canceled)
        {
            isBowAttack = false;
        }
    }

    public void OnCreate(InputAction.CallbackContext context)
    {
        if (GameManager.resourceManager.ResourcePouch.Any(x => x.Value > 0))
        {
            if (context.performed)
                Create();
        }
    }

    public void Create()
    {
        _bombFactory.GenerateBomb(_interactiveCursor.transform.position, _rotation.x);
    }

    public void Shot()
    {
        _arrowFactory.GenerateArrow(_interactiveCursor.transform.position, _rotation.x);
    }
}
