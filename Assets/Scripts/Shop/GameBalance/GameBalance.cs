using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Game Balance", menuName = "Shop/GameBalance", order = 51)]
public class GameBalance : ScriptableObject
{
    [SerializeField] private string _saveKey;

    public float Balance { get; private set; }

    public event UnityAction<float> ValueChanged;

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey(_saveKey))
            Balance = PlayerPrefs.GetFloat(_saveKey);
        else
            Balance = 0f;
    }

    public void AddBalance(float value)
    {
        Balance += value;
        PlayerPrefs.SetFloat(_saveKey, Balance);
        ValueChanged?.Invoke(Balance);
    }

    public void Spend(float value)
    {
        Balance -= value;
        PlayerPrefs.SetFloat(_saveKey, Balance);
        ValueChanged?.Invoke(Balance);
    }
}
