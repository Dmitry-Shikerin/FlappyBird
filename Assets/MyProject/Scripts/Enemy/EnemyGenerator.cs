using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class EnemyGenerator : EnemyPool
{
    [SerializeField] private GameObject _tamplate;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _maxSpawnPositionY;
    [SerializeField] private float _minSpawnPositionY;

     private Coroutine _coroutine;
     private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        Initialize(_tamplate);
        _waitForSeconds = new WaitForSeconds(_secondsBetweenSpawn);
        _coroutine = StartCoroutine(GenerateEnemy());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }
    
    private IEnumerator GenerateEnemy()
    {
        do
        {
            if (TryGetObject(out GameObject enemy))
            {
                float spawnPositionY = Random.Range(_minSpawnPositionY, _maxSpawnPositionY);
                Vector3 spawnpoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                enemy.SetActive(true);
                enemy.transform.position = spawnpoint;

                DisableObjectAbroadScreen();

                yield return _waitForSeconds;
            }
        } while (Time.timeScale != 0);
    }
}
