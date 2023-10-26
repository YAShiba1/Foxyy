using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartCollider : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            _gameManager.LoadGameScene();
        }
    }
}
