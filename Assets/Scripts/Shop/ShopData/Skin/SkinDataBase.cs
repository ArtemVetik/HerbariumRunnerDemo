using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skin Data Base", menuName = "Shop/SkinDataBase", order = 51)]
public class SkinDataBase : ScriptableObject
{
    [SerializeField] private List<SkinData> _skinDatas = new List<SkinData>();

    public SkinData this[int index] => _skinDatas[index];
    public SkinData this[string uid] => _skinDatas.Find((skinData) => skinData.UID == uid);

    public IEnumerable<SkinData> Data => _skinDatas;
    public int Count => _skinDatas.Count;
}