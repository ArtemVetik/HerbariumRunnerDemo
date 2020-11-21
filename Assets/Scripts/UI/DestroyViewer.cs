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
        _image.color = Color.white;
    }

    private void OnMapDestroyed()
    {
        _image.color = Color.gray;
    }
}
