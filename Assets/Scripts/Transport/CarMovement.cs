using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _speed;

    public Transform startPoint;
    public Transform endPoint;
    private void Start()
    {
        
    }

    private void Update()
    {
        Move(startPoint, endPoint);
    }

    public void SetPointsAndSpeed(Transform StartPoint, Transform EndPoint, float Speed)
    {
        startPoint = StartPoint;
        endPoint = EndPoint;
        _speed = Speed;
    }
    private void Move(Transform startPoint, Transform endPoint)
    {
        transform.position = Vector3.MoveTowards(transform.position, endPoint.position, _speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
