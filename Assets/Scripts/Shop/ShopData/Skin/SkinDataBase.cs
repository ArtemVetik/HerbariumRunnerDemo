using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skin Data Base", menuName = "Shop/SkinDataBase", order = 51)]
public class SkinDataBase : ScriptableObject
{
    [SerializeField] private List<SkinData> _skinDatas = new List<SkinData>();

    public IEnumerable<SkinData> Data => _skinDatas;
    public int Count => _skinDatas.Count;
}
