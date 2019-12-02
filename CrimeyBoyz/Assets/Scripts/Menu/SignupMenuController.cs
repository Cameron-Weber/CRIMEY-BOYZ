using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CrimeyBoyz.Menu.MissionControl {
    public class SignupMenuController : MonoBehaviour {

        public InputField usernameInput;
        public InputField nameInput;
        public InputField emailInput;
        public InputField passwordInput;
        public InputField passwordVerify;
        public Toggle rememberMeButton;

        public GameObject usernameError;
        public GameObject nameError;
        public GameObject emailError;
        public GameObject passwordError;

        public GameObject loadingWheel;
        public CanvasGroup disableWhenLoading;
        public MissionControlLobbyController myContoller;

        private void OnEnable() {
            ResetFields();
        }

        //set response to null to reset
        public void UpdateSignUpPage(DbResponse response) {
            SetLoading(false);
            if (response == null) {
                ResetFields();

            } else if (response.state == DbResponseState.EMAIL_EXISTS) {
                SetEmailError("Email already in use");
                SetEnabled(true);

            } else if (response.state == DbResponseState.USERNAME_EXISTS) {
                SetUsernameError("Username already exists");
                SetEnabled(true);

            } else if (response.state == DbResponseState.PASSWORDS_DONT_MATCH) {
                SetPasswordError("Verify password does not match");
                SetEnabled(true);

            } else if (response.state == DbResponseState.SUCCESS) {
                ClearErrors();
                if (rememberMeButton.isOn) {
                    Debug.Log("Remembering this user");
                    SavedAccounts.SaveUser(usernameInput.text, passwordInput.text);
                }

            } else {
                Debug.LogWarning("Unexpected response when signing up as new user");
                Debug.Log(response.message);
                SetUsernameError("Something");
                SetNameError("went wrong!");
                SetEmailError("Please");
                SetPasswordError("try again");
                SetEnabled(true);
            }
        }


        public void AttemptSignup() {
            //TODO: match the signup verification with the same as the website
            if(usernameInput.text.Length < 5) {
                SetUsernameError("Username too short");

            } else if (nameInput.text.Length < 1) {
                SetNameError("Please enter a name");

            } else if (emailInput.text.Length < 1) {
                SetEmailError("Please enter an email");

            } else if (!passwordVerify.text.Equals(passwordInput.text)) {
                SetPasswordError("Verify password does not match");

            } else { 
                myContoller.SignUpUser(usernameInput.text, nameInput.text, emailInput.text, passwordInput.text, passwordVerify.text);
                SetLoading(true);
                ClearErrors();
                SetEnabled(false);
            }
        }

        public void OnCancel() {
            myContoller.BackToSignIn();
        }



        private void SetLoading(bool loading) {
            loadingWheel.SetActive(loading);

        }

        private void SetEnabled(bool enabled) {
            float alpha = enabled ? 1f : 0.5f;
            disableWhenLoading.alpha = alpha;
            disableWhenLoading.interactable = enabled;
        }

        //set error to "" or null to clear error box
        private void SetUsernameError(string error) {
            if(error == null || error.Equals("")) {
                usernameError.SetActive(false);
            } else {
                usernameError.GetComponentInChildren<Text>().text = error;
                usernameError.SetActive(true);
            }
        }

        //set error to "" or null to clear error box
        private void SetNameError(string error) {
            if (error == null || error.Equals("")) {
                nameError.SetActive(false);
            } else {
                nameError.GetComponentInChildren<Text>().text = error;
                nameError.SetActive(true);
            }
        }

        //set error to "" or null to clear error box
        private void SetEmailError(string error) {
            if (error == null || error.Equals("")) {
                emailError.SetActive(false);
            } else {
                emailError.GetComponentInChildren<Text>().text = error;
                emailError.SetActive(true);
            }
        }

        //set error to "" or null to clear error box
        private void SetPasswordError(string error) {
            if (error == null || error.Equals("")) {
                passwordError.SetActive(false);
            } else {
                passwordError.GetComponentInChildren<Text>().text = error;
                passwordError.SetActive(true);
            }
        }

        private void ClearErrors() {
            SetUsernameError("");
            SetNameError("");
            SetEmailError("");
            SetPasswordError("");
        }

        private void ResetFields() {
            usernameInput.text = "";
            nameInput.text = "";
            usernameInput.text = "";
            passwordInput.text = "";
            passwordVerify.text = "";
            rememberMeButton.isOn = false;
            ClearErrors();
            SetLoading(false);
            SetEnabled(true);
        }
    }
}
