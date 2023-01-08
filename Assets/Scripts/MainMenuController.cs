using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Can only have 1 parameter
    public void PlayGame() {

      int selectedCharacter =
        // converts string representation of a number into an int
        // make sure that string has only numbers in it or won't work
        int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

      // Use class name to call static variable to access all public
      // variables and public functions
      GameManager.instance.CharIndex = selectedCharacter;

      SceneManager.LoadScene("Gameplay");

    }


} // class
