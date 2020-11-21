using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinShop : MonoBehaviour
{
    [SerializeField] private SkinDataBase _skinDataBase;
    [SerializeField] private GameBalance _balance;
    [SerializeField] private SkinListView _skinListView;

    private SkinSaved _skinSaved;
    IEnumerable<SkinPresenter> _skinPresenters;

    private void OnEnable()
    {
        _skinSaved = new SkinSaved(_skinDataBase);
        _skinSaved.Load(new JsonSaveLoad());
        _skinPresenters = _skinListView.Render(_skinDataBase.Data, _skinSaved);
        InitSellButtons(_skinPresenters);
    }

    private void OnSelectedButtonClick(SkinData skinData, SkinPresenter presenter)
    {
        _skinSaved.SetCurrentSkin(skinData);
        _skinListView.SetSelectedSkin(presenter);
    }

    private void OnSellButtonClicked(SkinData skinData, SkinPresenter presenter)
    {
        if (_balance.Balance < skinData.Price)
            return;

        _balance.Spend(skinData.Price);
        _skinSaved.Add(skinData);
        presenter.Unlock(); 
    }

    private void InitSellButtons(IEnumerable<SkinPresenter> skinPresenters)
    {
        foreach (SkinPresenter presenter in skinPresenters)
        {
            presenter.SellButtonClick += OnSellButtonClicked;
            presenter.SelectedButtonClick += OnSelectedButtonClick;
        }
    }

    private void RemoveSellButtons(IEnumerable<SkinPresenter> skinPresenters)
    {
        foreach (SkinPresenter presenter in skinPresenters)
        {
            presenter.SellButtonClick -= OnSellButtonClicked;
            presenter.SelectedButtonClick -= OnSelectedButtonClick;
        }
    }

    private void OnDisable()
    {
        _skinSaved.Save(new JsonSaveLoad());
        RemoveSellButtons(_skinPresenters);

        foreach (SkinPresenter presenter in _skinPresenters)
            Destroy(presenter.gameObject);
    }
}
