using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    [SerializeField] private Player _player;

    private SkinSaved _skinSaved;

    private void Start()
    {
        _skinSaved = new SkinSaved();
        _skinSaved.Load(new JsonSaveLoad());

        GameObject skin = _skinSaved.CurrentSkin.Prefab;
        Instantiate(skin, _player.transform);
    }
}
