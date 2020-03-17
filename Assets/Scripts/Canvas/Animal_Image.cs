using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal_Image : MonoBehaviour {

    [Tooltip("Source Image (Sprite)")]
    public Sprite _sprite;

    public AnimalTypes._animalTypes _type;

    private bool _isVisible;

    private Image _imageComponent;

    public void Init() {
        gameObject.AddComponent<CanvasRenderer>();
        _imageComponent = gameObject.AddComponent<Image>();
        _imageComponent.sprite = _sprite;
        _imageComponent.color = new Color(255, 255, 255, 0.5f);
    }

    public void MakeVisible() {
        _imageComponent.color = Color.cyan;
        //_imageComponent.color = new Color(255, 255, 255, 1f);
    }

    public AnimalTypes._animalTypes GetName() {
        return _type;
    }
}
