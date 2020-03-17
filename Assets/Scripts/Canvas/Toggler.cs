using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggler : MonoBehaviour {
    private bool _isOn;

    [SerializeField]
    private GameObject _targetObject;


    private void Start() {
        _isOn = _targetObject.activeSelf;
    }

    public void Toggle() {
        _isOn = !_isOn;
        _targetObject.SetActive(_isOn);
    }


}
