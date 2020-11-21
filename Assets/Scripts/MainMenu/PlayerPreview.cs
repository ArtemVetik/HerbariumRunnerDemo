using UnityEngine;

public class PlayerPreview : MonoBehaviour
{
    [SerializeField] private SkinDataBase _dataBase;

    private void Start()
    {
        SkinSaved skinSaved = new SkinSaved(_dataBase);
        skinSaved.Load(new JsonSaveLoad());
        
        Instantiate(skinSaved.CurrentSkin.Prefab, transform);
    }
}
