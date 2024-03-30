using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public UnityEvent EndFade = new();

    [SerializeField] private float _fadeDuration;

    private Image _image;

    private float _timer;

    private Color _color;

    private bool _isFading;

    void Start()
    {
        _image = GetComponent<Image>();
        _color = _image.color;

        _image.color = new Color(_color.r, _color.g, _color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isFading == false)
            return;

        _timer += Time.deltaTime;

        if (_timer < _fadeDuration)
        {
            float persent = _timer / _fadeDuration;
            _color.a = persent;
            _image.color = _color;
        }
        else
        {
            _isFading = false;
            EndFade?.Invoke();
        }
    }

    public void StartFade()
    {
        _isFading = true;
    }
}
