using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveLoadVisiter
{
    void Save(SkinSaved skinSaved);
    SkinSaved Load(SkinSaved shopSaved);
}
