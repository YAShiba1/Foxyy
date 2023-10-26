using UnityEngine;

public class JumpChecker : MonoBehaviour
{
    public bool CanJump { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out CanJump canJump))
        {
            CanJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CanJump canJump))
        {
            CanJump = false;
        }
    }
}
