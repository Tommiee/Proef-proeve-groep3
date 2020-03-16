using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour {

    [HideInInspector]
    public static AnimalManager Instance;

    public delegate void OnDictionaryUpdateDelegate();
    public event OnDictionaryUpdateDelegate OnDictionaryUpdate;

    private Dictionary<string, int> _animalDict = new Dictionary<string, int>();

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

    public void CaughtAnimal(string _type) {
        _animalDict[_type]++;
        OnDictionaryUpdate?.Invoke();
    }

    public Dictionary<string, int> GetDictionary() {
        return _animalDict;
    }
}
