using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkinListView : MonoBehaviour
{
    [SerializeField] private SkinPresenter _template;
    [SerializeField] private UnityEngine.Transform _skinContainer;

    private SkinPresenter _selectedSkin;

    public IEnumerable<SkinPresenter> Render(IEnumerable<SkinData> skinList, SkinSaved unlockedSkins)
    {
         var skinPresenters = new List<SkinPresenter>();
        foreach (SkinData skin in skinList)
        {
            var instSkin = Instantiate(_template, _skinContainer);
            skinPresenters.Add(instSkin);
            instSkin.Render(skin);

            if (unlockedSkins.BuyedSkins.Contains(skin))
                instSkin.Unlock();

            if (skin.Equals(unlockedSkins.CurrentSkin))
                SetSelectedSkin(instSkin);
        }

        return skinPresenters;
    }

    public void SetSelectedSkin(SkinPresenter selectedSkin)
    {
        if (_selectedSkin != null)
            _selectedSkin.Deselect();

        _selectedSkin = selectedSkin;
        _selectedSkin.Select();
    }
}
