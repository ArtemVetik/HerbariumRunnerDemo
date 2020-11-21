using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Game Balance", menuName = "Shop/GameBalance", order = 51)]
public class GameBalance : ScriptableObject
{
    [SerializeField] private string _saveKey;

    public event UnityAction<float> ValueChanged;

    public float Balance { get; private set; }

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
