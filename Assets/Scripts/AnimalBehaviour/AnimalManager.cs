using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour {

    [HideInInspector]
    public static AnimalManager Instance;

    public delegate void onDictionaryUpdateDelegate();
    public event onDictionaryUpdateDelegate OnDictionaryUpdate;

    private Dictionary<AnimalTypes._animalTypes, int> _animalDict = new Dictionary<AnimalTypes._animalTypes, int>();

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(Instance);
        } else {
            Destroy(this);
        }
        FillDictionary();
    }

    private void FillDictionary() {
        Animal[] animals = FindObjectsOfType<Animal>();
        for (int i = 0; i < animals.Length; i++) {
            if (!_animalDict.ContainsKey(animals[i]._type)) {
                _animalDict.Add(animals[i]._type, 0);
                animals[i].OnCaught += CaughtAnimal;
            }
        }
    }


    public Dictionary<AnimalTypes._animalTypes, int> GetDictionary() {
        return _animalDict;
    }

    public void CaughtAnimal(AnimalTypes._animalTypes _type) {
        if (_animalDict.ContainsKey(_type)) {
            _animalDict[_type]++;
        } else {
            _animalDict.Add(_type, 1);
        }
        OnDictionaryUpdate?.Invoke();
    }
}
