using UnityEngine;

//Manages the Android Specific settings menu
//Currently a placeholder for future settings
public class AndroidSettingsMenu : MonoBehaviour, SettingsMenuItem {

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Defines ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Variables ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Behavioural ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void Awake() {
        LoadSettings();
    }


    /// <summary>
    /// Function that would save settings
    /// </summary>
    public void SaveSettings() {
        //Debug.Log("This is when android settings would be saved");
    }

    /// <summary>
    /// Function that would load settings
    /// </summary>
    public void LoadSettings() {
        //Debug.Log("This is when android settings would be loaded");
    }

    /// <summary>
    /// Function that would check if a restart is required
    /// </summary>
    /// <returns> Returns true if a restart is required, false if otherwise </returns>
    public bool IsRestartRequired() {
        return false;
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Public Functions ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Helper Functions ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
}
