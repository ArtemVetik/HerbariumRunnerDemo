using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicOrthographicSize : MonoBehaviour
{
    [SerializeField] private float _targetOrthographicSize;

    private void Start()
    {
        Camera.main.orthographicSize = _targetOrthographicSize * Screen.height / Screen.width / 2f;
    }
}
