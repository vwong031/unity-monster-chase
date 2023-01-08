using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [SerializeField]
    private GameObject[] characters;

    private int _charIndex;
    public int CharIndex {
      get { return _charIndex; }
      set { _charIndex = value; }
    }

    private void Awake() 
    {
        // Singleton Pattern: allows us to only have 1 copy of a game object
        if (instance == null) {
          // Creates a copy
          instance = this;
          // Makes game object move from 1 scene to another scence
          DontDestroyOnLoad(gameObject);
        }
        else {
          // We already have an instance
          // Destroys duplicate
          Destroy(gameObject);
        }
    }

    // Events and Delegates
    private void OnEnable() {
      SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    private void OnDisable() {
      SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
      if (scene.name == "Gameplay") {
        Instantiate(characters[CharIndex]);
      }
    }

    // Events and Delegates
} // class


/*
DELEGATION
- allows us to subscribe to an event
- how to declare a delegate: "public delegate void [name of delegate]();"

- "public static event [name of delegate] [event name];"
  - use static so can subscribe from any class

- a function that subscribes to an event must have the same signature (parameters)
- test if event = null. if not, call the event

*/
