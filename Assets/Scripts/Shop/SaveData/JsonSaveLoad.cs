using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonSaveLoad : ISaveLoadVisiter
{
    private const string SkinSavedKey = "SkinSaved";

    public SkinSaved Load(SkinSaved skinSaved)
    {
        if (PlayerPrefs.HasKey(SkinSavedKey))
        {
            string saveJson = PlayerPrefs.GetString(SkinSavedKey);
            return JsonUtility.FromJson<SkinSaved>(saveJson);
        }

        return null;
    }

    public void Save(SkinSaved skinSaved)
    {
        string saveJson = JsonUtility.ToJson(skinSaved);
        PlayerPrefs.SetString(SkinSavedKey, saveJson);
        PlayerPrefs.Save();
    }
}
