using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BalanceViewer : MonoBehaviour
{
    [SerializeField] private GameBalance _balance;

    private Text _balanceText;

    private void Awake()
    {
        _balanceText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        _balance.ValueChanged += OnBalanceValueChanged;
    }

    private void OnDisable()
    {
        _balance.ValueChanged -= OnBalanceValueChanged;
    }

    private void Start()
    {
        _balanceText.text = ((int)(_balance.Balance)).ToString();
    }

    private void OnBalanceValueChanged(float value)
    {
        _balanceText.text = value.ToString();
    }
}