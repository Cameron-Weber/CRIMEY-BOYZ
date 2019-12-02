
//Each Settings Menu script should implement these functions
public interface SettingsMenuItem {
    //See the settings menu controller
    void SaveSettings(); //Save current settings values to file
    void LoadSettings(); //Populate settings values from file
    bool IsRestartRequired(); //Return true if a setting has been changed that requires a restart.
}
