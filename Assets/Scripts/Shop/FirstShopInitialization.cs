using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstShopInitialization : MonoBehaviour
{
    [SerializeField] private SkinDataBase _skinDataBase;
    [SerializeField] private int _numberOfDefaultSkin;

    private void Awake()
    {
        SkinSaved skinSaved = new SkinSaved(_skinDataBase);
        skinSaved.Load(new JsonSaveLoad());

        if (skinSaved.GetSavedSkins().Count == 0)
        {
            skinSaved.Add(_skinDataBase[_numberOfDefaultSkin]);
            skinSaved.SetCurrentSkin(_skinDataBase[_numberOfDefaultSkin]);
            skinSaved.Save(new JsonSaveLoad());
        }
    }
}