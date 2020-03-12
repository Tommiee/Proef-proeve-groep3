using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {
    [HideInInspector]
    public static CanvasController Instance;

    private AnimalManager _animalManager;
    private Dictionary<string, int> _animalDict = new Dictionary<string, int>();

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

        if (_animalDict.Count != _images.Count) {
            Debug.LogError("Animal Gameobject and Animal Image count mismatch");
            return;
        }

        for (int i = 0; i < _animalDict.Count; i++) {
            if (_animalDict.ContainsKey(_images[i]._animalName)) {
                if (_animalDict[_images[i]._animalName] > 0) {
                    _images[i].MakeVisible();
                }
            }
        }
    }

    private void InitImages() {
        for (int i = 0; i < _images.Count; i++) {
            _images[i].GetComponent<Animal_Image>().Init();
        }
    }


}
