using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSize : MonoBehaviour
{
    [SerializeField]
    private float _minSize;
    [SerializeField]
    private float _maxSize;
    private float _randomSize;
    private Vector3 _changeSize;
    void Start()
    {
        _randomSize = Random.Range(_minSize, _maxSize);
        _changeSize = new Vector3(_randomSize, _randomSize, _randomSize);
    }

    
    void Update()
    {
        transform.localScale = _changeSize;
        print(_changeSize);
    }
}
