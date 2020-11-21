using UnityEngine;

public class CameraTranslate : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _accelerationRate;

    public float Speed => _speed;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.forward, _speed * Time.deltaTime);
        _speed += _accelerationRate * Time.deltaTime;
    }
}