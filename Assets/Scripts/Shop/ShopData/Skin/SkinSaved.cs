using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SkinSaved : BaseShopSaved
{
    [SerializeField] private List<SkinData> _buyedSkins = new List<SkinData>();
    [SerializeField] private SkinData _currentSkin;

    public List<SkinData> BuyedSkins => _buyedSkins;
    public SkinData CurrentSkin => _currentSkin;

    public void Add(SkinData skinData)
    {
        _buyedSkins.Add(skinData);
    }

    public void SetCurrentSkin(SkinData skinData)
    {
        if (_buyedSkins.Contains(skinData) == false)
            throw new ArgumentException();

        _currentSkin = skinData;
    }

    public override void Load(ISaveLoadVisiter saveLoadVisiter)
    {
        SkinSaved saved = saveLoadVisiter.Load(this);
        _buyedSkins = saved.BuyedSkins;
        _currentSkin = saved.CurrentSkin;
    }

    public override void Save(ISaveLoadVisiter saveLoadVisiter)
    {
        saveLoadVisiter.Save(this);
    }
}
