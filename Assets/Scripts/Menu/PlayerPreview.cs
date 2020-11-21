using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreview : MonoBehaviour
{
    [SerializeField] private SkinDataBase _dateBase;

    private void Start()
    {
        SkinSaved skinSaved = new SkinSaved(_dateBase);
        skinSaved.Load(new JsonSaveLoad());
        
        Instantiate(skinSaved.CurrentSkin.Prefab, transform);
    }
}
