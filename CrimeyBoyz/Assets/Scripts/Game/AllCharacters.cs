﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Collection of all character information in the game
public class AllCharacters : MonoBehaviour {

    public static AllCharacters Singleton { get; private set; }

    public List<string> characterNames;
    public List<Sprite> characterSprites;

    /// <summary>
    /// Sets the singleton for this class. Ensures only one copy of this script is instantiated.
    /// </summary>
    private void OnEnable() {

        if (Singleton != null && this != Singleton) {
            Destroy(this);
        } else {
            Singleton = this;
        }
    }

    /// <summary>
    /// Gets the default name for a character
    /// </summary>
    /// <returns>
    /// Returns a string containing the next default player's name
    /// Returns an empty string if otherwise
    /// </returns>
    public string getDefaultName() {
        if(characterNames.Count > 0) {
            return characterNames[0];
        } else {
            return "";
        }
    }

    /// <summary>
    /// Function to get the next name in a list of names
    /// </summary>
    /// <param name="currentName"> The current name being viewed </param>
    /// <returns>
    /// Returns a string containing the next character name.
    /// Returns a string containing the default character name if otherwise.
    /// </returns>
    public string getNextName(string currentName) {
        if(characterNames.Contains(currentName)) {

            int nextIndex = characterNames.IndexOf(currentName) + 1;
            if(nextIndex >= characterNames.Count) {
                nextIndex = 0;
            }

            return characterNames[nextIndex];

        } else {
            return getDefaultName();
        }
    }

    /// <summary>
    /// Gets the previous name in a list of names
    /// </summary>
    /// <param name="currentName"> The current name being viewed </param>
    /// <returns>
    /// Returns a string containing the previous character name.
    /// Returns a string containing the default character name if otherwise.
    /// </returns>
    public string getPreviousName(string currentName) {
        if (characterNames.Contains(currentName)) {

            int nextIndex = characterNames.IndexOf(currentName) - 1;
            if (nextIndex < 0) {
                nextIndex = characterNames.Count - 1;
            }

            return characterNames[nextIndex];

        } else {
            return getDefaultName();
        }
    }

    /// <summary>
    /// Returns the sprite being used by a character
    /// </summary>
    /// <param name="name"> The name of the character using a sprite </param>
    /// <returns>
    /// Returns the sprite of the player with the name 'name'
    /// </returns>
    public Sprite getSprite(string name) {

        int imageIndex = 0;

        if(characterNames.Contains(name)) {
            imageIndex = characterNames.IndexOf(name);
        }

        if(characterSprites.Count > imageIndex) {
            return characterSprites[imageIndex];
        } else {
            if(characterSprites.Count > 0 ) {
                return characterSprites[0];
            } else {
                return null;
            }
        }
    }

    public int getSpriteNumber(string name)
    {
        if (characterNames.Contains(name))
            return characterNames.IndexOf(name) + 1;
        return 0;
    }
}
