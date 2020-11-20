using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameBalance _balance;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
            _balance.AddBalance(100f);

        if (Input.GetKeyDown(KeyCode.F10))
        {
            PlayerPrefs.DeleteAll();
            SkinSaved skinSaved = new SkinSaved();
            skinSaved.Save(new JsonSaveLoad());
        }
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void GoHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
