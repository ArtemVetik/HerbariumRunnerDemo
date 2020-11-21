using UnityEngine;
using UnityEngine.Events;

public class FolowingMove : MonoBehaviour
{
    [SerializeField] private CameraTranslate _cameraTranslate;
    [Range(1f,2f), SerializeField] private float _speedRate;

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
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _cameraTranslate.Speed * _speedRate * Time.deltaTime);

        if (transform.position == _targetPosition)
        {
            enabled = false;
            MoveEnded?.Invoke();
        }
    }
}
