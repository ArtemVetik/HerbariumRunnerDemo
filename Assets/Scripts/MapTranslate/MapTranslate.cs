using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTranslate : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(-1 * Vector3.forward * _speed * Time.deltaTime);
    }
}