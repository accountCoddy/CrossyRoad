using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private Transform _leftSpawnPoint;
    [SerializeField] private Transform _rightSpawnPoint;

    [SerializeField] private Car[] _cars;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    [SerializeField] private float _minDelay;
    [SerializeField] private float _maxDelay;

    private Transform _spawnPoint;
    private float _speed;
    private float _delay;
    private bool _isRightDirection;
    private Vector3 _rotateCar;

    void Start()
    {
        _speed = Random.Range(_minSpeed, _maxSpeed);
        _delay = Random.Range(_minDelay, _maxDelay);
        _isRightDirection = Random.Range(0, 2) == 1;

        if (_isRightDirection == true)
        {
            _spawnPoint = _leftSpawnPoint;
            _rotateCar = Vector3.up * 90;
        }
        else
        {
            _spawnPoint = _rightSpawnPoint;
            _rotateCar = Vector3.up * -90;
        }

        StartCoroutine(CarSpawn());
    }

    private IEnumerator CarSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            Car randomCar = _cars[Random.Range(0, _cars.Length)];
            Car newCar = Instantiate(randomCar, _spawnPoint.position, Quaternion.Euler(_rotateCar), transform);
            newCar.Initialize(_speed);
        }
    }
}
