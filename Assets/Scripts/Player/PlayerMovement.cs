using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _fallGravityValue;

    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private JumpChecker _jumpChecker;

    private float _defaultGravityScale;
    private bool _isFacingRight = true;
    private bool _canMove = true;

    public Rigidbody2D Rigidbody2D { get; private set; }

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        _defaultGravityScale = Rigidbody2D.gravityScale;
    }

    private void Update()
    {
        TryJump();
        FallAcceleration();
    }

    private void FixedUpdate()
    {
        TryMove();
    }

    private void TryMove()
    {
        if (_canMove)
        {
            Rigidbody2D.velocity = new Vector2(GetInputHorizontal() * _speed, Rigidbody2D.velocity.y);

            if (_isFacingRight == true && GetInputHorizontal() < 0)
            {
                Flip();
            }

            if (_isFacingRight == false && GetInputHorizontal() > 0)
            {
                Flip();
            }
        }
    }

    private void TryJump()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButtonDown("Jump")) && _jumpChecker.CanJump == true && _canMove == true)
        {
            _audioManager.PlayJump();
            Rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }

    private void FallAcceleration()
    {
        if(Rigidbody2D.velocity.y < 0)
        {
            Rigidbody2D.gravityScale = _fallGravityValue;
        }
        else
        {
            Rigidbody2D.gravityScale = _defaultGravityScale;
        }
    }

    public float GetInputHorizontal()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");

        return inputHorizontal;
    }

    public void SetCanMove(bool canMove)
    {
        _canMove = canMove;
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
