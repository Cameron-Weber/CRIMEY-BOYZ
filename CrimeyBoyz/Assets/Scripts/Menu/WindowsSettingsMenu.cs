using UnityEngine.UI;
using UnityEngine;

//Manages the windows specific settings prefab
//Currently has the following settings:
//  - Select Monitor (Choose which monitor to display the game on)
public class WindowsSettingsMenu : MonoBehaviour, SettingsMenuItem {

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Variables ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    public Dropdown monitorSelectionDropdown;

    private bool restartRequired;

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Behavioural ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void Awake() {
        restartRequired = false;
        LoadSettings();
        monitorSelectionDropdown.onValueChanged.AddListener(delegate { SetRestartRequired(); });
    }

    private void OnEnable() {
        restartRequired = false;
    }


    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Public Functions ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    public void SaveSettings() {
        SaveMonitorSettings();
        //Can add more setting here
    }

    public void LoadSettings() {
        LoadMonitorSettings();
        //Can add more setting here
    }

    public bool IsRestartRequired() {
        return restartRequired;
    }

    

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Helper Functions ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void SaveMonitorSettings() {
        int selectedValue = monitorSelectionDropdown.value;
        int savedValue = PlayerPrefs.GetInt("UnitySelectMonitor");

        if (selectedValue != savedValue) {
            PlayerPrefs.SetInt("UnitySelectMonitor", selectedValue);
            Debug.Log(string.Format("Monitor Saved to {0}", selectedValue));
            restartRequired = true;
        }
    }

    private void LoadMonitorSettings() {
        //Debug.Log(string.Format("Monitor read as {0}", PlayerPrefs.GetInt("UnitySelectMonitor")));
        int savedValue = PlayerPrefs.GetInt("UnitySelectMonitor");
        monitorSelectionDropdown.value = savedValue;
    }

    private void SetRestartRequired() {
        restartRequired = true;
    }
}
