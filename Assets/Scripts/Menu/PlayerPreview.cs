using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreview : MonoBehaviour
{
    private void Start()
    {
        SkinSaved skinSaved = new SkinSaved();
        skinSaved.Load(new JsonSaveLoad());
        
        Instantiate(skinSaved.CurrentSkin.Prefab, transform);
    }
}
