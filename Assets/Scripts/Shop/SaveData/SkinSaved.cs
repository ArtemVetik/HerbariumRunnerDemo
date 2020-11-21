using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SkinSaved : ISavedObject
{
    [SerializeField] private List<string> _buyedUID = new List<string>();
    [SerializeField] private string _currentUID;

    private SkinDataBase _dataBase;

    public SkinData CurrentSkin => _dataBase[_currentUID];

    public SkinSaved(SkinDataBase dateBase)
    {
        _dataBase = dateBase;
    }

    public void Add(SkinData skinData)
    {
        _buyedUID.Add(skinData.UID);
    }

    public void SetCurrentSkin(SkinData skinData)
    {
        if (_buyedUID.Contains(skinData.UID) == false)
            throw new ArgumentException();

        _currentUID = skinData.UID;
    }

    public List<SkinData> GetSavedSkins()
    {
        List<SkinData> skinDatas = new List<SkinData>();
        foreach (string uid in _buyedUID)
            skinDatas.Add(_dataBase[uid]);

        return skinDatas;
    }

    public void Load(ISaveLoadVisiter saveLoadVisiter)
    {
        SkinSaved saved = saveLoadVisiter.Load(this);
        if (saved == null)
            return;

        _buyedUID = saved._buyedUID;
        _currentUID = saved._currentUID;
    }

    public void Save(ISaveLoadVisiter saveLoadVisiter)
    {
        saveLoadVisiter.Save(this);
    }
}
