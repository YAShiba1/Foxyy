using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _movementSpeed;

    private Transform _target;
    private bool _isFacingRight = true;

    private void Start()
    {
        _target = _pointA;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        const float MinDistanceToTarget = 0.01f;

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _movementSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _target.position) < MinDistanceToTarget)
        {
            if (_target == _pointA)
            {
                _target = _pointB;
            }
            else
            {
                _target = _pointA;
            }

            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
