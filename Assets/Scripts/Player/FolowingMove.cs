using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FolowingMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _targetPosition;

    public event UnityAction MoveEnded;

    public bool IsMoving => enabled;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    public void Move(Vector3 toPosition)
    {
        _targetPosition = toPosition;
        enabled = true;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        if (transform.position == _targetPosition)
        {
            enabled = false;
            MoveEnded?.Invoke();
        }
    }
}
