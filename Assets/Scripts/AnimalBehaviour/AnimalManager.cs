using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{

    public Dictionary<string, int> _animalDict = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        FillDictionary();
    }

    private void FillDictionary()
    {
        Animal[] animals = FindObjectsOfType<Animal>();
        for (int i = 0; i < animals.Length; i++)
        {
            if (!_animalDict.ContainsKey(animals[i]._type))
            {
                _animalDict.Add(animals[i]._type, 0);
            }
        }
    }

    private void CaughtAnimal(string _type)
    {
        if (_animalDict.ContainsKey(_type))
        {
            _animalDict[_type]++;
        }
        else
        {
            _animalDict.Add(_type, 1);
        }
    }
}
