using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SkinDataBase _dateBase;

    private SkinSaved _skinSaved;

    private void Start()
    {
        _skinSaved = new SkinSaved(_dateBase);
        _skinSaved.Load(new JsonSaveLoad());

        GameObject skin = _skinSaved.CurrentSkin.Prefab;
        Instantiate(skin, _player.transform);
    }
}
