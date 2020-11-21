using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkinPresenter : MonoBehaviour
{
    [SerializeField] private Image _preview;
    [SerializeField] private Text _name;
    [SerializeField] private Text _price;
    [SerializeField] private Button _sellButton;
    [SerializeField] private Button _selectButton;
    [SerializeField] private Text _selectedButtonText;
    [SerializeField] private Image _borderImage;
    [SerializeField] private GameObject _lockGroup;

    private SkinData _skinData;

    public event UnityAction<SkinData, SkinPresenter> SellButtonClick;
    public event UnityAction<SkinData, SkinPresenter> SelectedButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnSellButtonClicked);
        _selectButton.onClick.AddListener(OnSelectButtonClicked);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnSellButtonClicked);
        _selectButton.onClick.RemoveListener(OnSelectButtonClicked);
    }

    public void Render(SkinData skinData)
    {
        _skinData = skinData;

        _preview.sprite = skinData.Preview;
        _name.text = skinData.Name;
        _price.text = skinData.Price.ToString();
    }

    public void Select()
    {
        _selectedButtonText.text = "Выбран";
        _borderImage.color = Color.green;
    }

    public void Deselect()
    {
        _selectedButtonText.text = "Выбрать";
        _borderImage.color = Color.white;
    }

    public void Unlock()
    {
        _sellButton.gameObject.SetActive(false);
        _selectButton.gameObject.SetActive(true);
        _lockGroup.SetActive(false);
    }

    private void OnSellButtonClicked()
    {
        SellButtonClick?.Invoke(_skinData, this);
    }

    private void OnSelectButtonClicked()
    {
        SelectedButtonClick?.Invoke(_skinData, this);
    }
}
