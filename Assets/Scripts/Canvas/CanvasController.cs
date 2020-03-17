using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {
    [HideInInspector]
    public static CanvasController Instance;

    private Dictionary<AnimalTypes._animalTypes, int> _animalDict = new Dictionary<AnimalTypes._animalTypes, int>();

    [SerializeField]
    private List<Animal_Image> _images;

    void Start() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(Instance);
        } else {
            Destroy(this);
        }
        _animalDict = AnimalManager.Instance.GetDictionary();
        AnimalManager.Instance.OnDictionaryUpdate += CheckDictionary;
        InitImages();
    }

    private void CheckDictionary() {

        /*if (_animalDict.Count != _images.Count) {
            Debug.LogError("Animal Gameobject and Animal Image count mismatch");
            return;
        }*/


        for (int i = 0; i < _animalDict.Count; i++) {
            if (_animalDict.ContainsKey(_images[i]._type)) {
                if (_animalDict[_images[i]._type] > 0) {
                    _images[i].MakeVisible();
                }
            }
        }
    }

    private void InitImages() {
        for (int i = 0; i < _images.Count; i++) {
            _images[i].Init();
        }
    }


}
