using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class BaseShopSaved
{
    public abstract void Save(ISaveLoadVisiter saveLoadVisiter);
    public abstract void Load(ISaveLoadVisiter saveLoadVisiter);
}
