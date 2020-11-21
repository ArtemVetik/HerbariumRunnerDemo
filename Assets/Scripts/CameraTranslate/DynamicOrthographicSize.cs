using UnityEngine;

public class DynamicOrthographicSize : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _targetOrthographicSize;

    private void Start()
    {
        _camera.orthographicSize = _targetOrthographicSize * Screen.height / Screen.width / 2f;
    }
}
