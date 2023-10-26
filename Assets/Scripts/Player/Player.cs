using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerAnimation), typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private BoxCollider2D _colliderToDisable;
    [SerializeField] private JumpChecker _jumpChecker;

    private int _gemsCount;
    private Coroutine _disableColliderJob;

    private PlayerAnimation _playerAnimation;
    private PlayerMovement _playerMovement;

    public event UnityAction GemPicked;
    public event UnityAction GoalReached;

    private void Start()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        _playerAnimation.SetSpeed(_playerMovement.GetInputHorizontal());
        _playerAnimation.SetIsJumping(_jumpChecker.CanJump == false && _playerMovement.Rigidbody2D.velocity.y > 0);
        _playerAnimation.SetIsFalling(_jumpChecker.CanJump == false && _playerMovement.Rigidbody2D.velocity.y < 0);
    }

    public void JumpAway(float pushForce)
    {
        Vector2 currentVelocity = _playerMovement.Rigidbody2D.velocity;

        _playerMovement.Rigidbody2D.AddForce((Vector2.up * pushForce) - currentVelocity, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            StopDisableColliderCoroutine();

            _playerAnimation.SetHurt();

            _disableColliderJob = StartCoroutine(DisableColliderAndMoveForSeconds());
        }
    }

    public void IncreaseGems()
    {
        _gemsCount++;
        GemPicked?.Invoke();

        if (_gemsCount == _gameManager.GemsToCollect)
        {
            GoalReached?.Invoke();
        }
    }

    public IEnumerator DisableColliderAndMoveForSeconds()  // переименовать
    {
        var waitForSeconds = new WaitForSeconds(0.95f);

        _colliderToDisable.enabled = false;
        _playerMovement.SetCanMove(false);

        yield return waitForSeconds;

        _colliderToDisable.enabled = true;
        _playerMovement.SetCanMove(true);
    }

    public void StopDisableColliderCoroutine()
    {
        if (_disableColliderJob != null)
        {
            StopCoroutine(_disableColliderJob);
        }
    }
}
