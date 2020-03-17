using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Animal : MonoBehaviour {
    public delegate void onCaughtDelegate(AnimalTypes._animalTypes _type);
    public event onCaughtDelegate OnCaught;

    private ScreenInput _screenInput;
    private AnimalManager _animalManager;
    private Collider _collider;

    [SerializeField]
    private ParticleSystem _catchEffect;

    public AnimalTypes._animalTypes _type;

    void Start() {
        _screenInput = GameObject.FindObjectOfType<ScreenInput>();
        _screenInput.OnPressed += CheckAnimal;
        _collider = gameObject.GetComponent<Collider>();
    }

    private void CheckAnimal(Collider _col) {
        if (_collider == _col) {
            AnimalCaught();
        }
    }

    private void AnimalCaught() {
        OnCaught?.Invoke(_type);
        AnimalManager.Instance.SendMessage("CaughtAnimal", _type, SendMessageOptions.RequireReceiver);
        Instantiate(_catchEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
