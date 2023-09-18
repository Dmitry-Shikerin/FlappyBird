using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _deley;

    private float _currentTime = 0;

    private void Update()
    {
        _currentTime += Time.deltaTime;
        
        if (_currentTime >= _deley)
        {
            _currentTime = 0;
            
            Shoot(_shootPoint);
        }
    }

    public void Shoot(Transform shootPoint)
    {
        Instantiate(_bullet, shootPoint.position, Quaternion.identity);
    }
}
