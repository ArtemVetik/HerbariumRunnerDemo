using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DestroyViewer : MonoBehaviour
{
    [SerializeField] private MapDestroyer _mapDestroyer;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _mapDestroyer.Destroyed += OnMapDestroyed;
        _mapDestroyer.ReadyToDestroy += OnReadyToDestroy;
    }

    private void OnDisable()
    {
        _mapDestroyer.Destroyed -= OnMapDestroyed;
        _mapDestroyer.ReadyToDestroy -= OnReadyToDestroy;
    }

    private void OnReadyToDestroy()
    {
        _image.enabled = true;
    }

    private void OnMapDestroyed()
    {
        _image.enabled = false;
    }
}
