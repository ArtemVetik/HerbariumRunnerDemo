using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct SkinData
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Sprite _preview;
    [SerializeField] private string _name;
    [SerializeField] private int _price;

    public GameObject Prefab => _prefab;
    public Sprite Preview => _preview;
    public string Name => _name;
    public int Price => _price;
}
