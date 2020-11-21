using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface ISavedObject
{
    void Save(ISaveLoadVisiter saveLoadVisiter);
    void Load(ISaveLoadVisiter saveLoadVisiter);
}
