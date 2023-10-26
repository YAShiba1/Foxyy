using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        InstantiateGameObjects();
    }

    private void InstantiateGameObjects()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Instantiate(_prefab, _spawnPoints[i].position, Quaternion.identity);
        }
    }
}
