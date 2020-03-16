using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(FollowThePath))]
public class Animal : MonoBehaviour {
    public delegate void onCaughtDelegate(string _type);
    public event onCaughtDelegate OnCaught;

    private ScreenInput _screenInput;
    private AnimalManager _animalManager;
    private Collider _collider;

    [SerializeField]
    private ParticleSystem _catchEffect;

    public string _type;

    void Start() {
        _screenInput = GameObject.FindObjectOfType<ScreenInput>();
        _screenInput.OnPressed += CheckAnimal;

        _animalManager = GameObject.FindObjectOfType<AnimalManager>();

        _collider = gameObject.GetComponent<Collider>();
    }

    private void CheckAnimal(Collider _col) {
        if (_collider == _col) {
            AnimalCaught();
        }
    }

    private void AnimalCaught() {
        OnCaught?.Invoke(_type);
        Instantiate(_catchEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
