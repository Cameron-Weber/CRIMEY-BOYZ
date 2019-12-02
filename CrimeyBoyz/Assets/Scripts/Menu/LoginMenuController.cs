using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CrimeyBoyz.Menu.MissionControl {
    public class LoginMenuController : MonoBehaviour {

        public InputField usernameInput;
        public InputField passwordInput;
        public Toggle rememberMeButton;
        public GameObject loginFailed;
        public GameObject loadingWheel;
        public CanvasGroup disableWhenLoading;
        public MissionControlLobbyController myContoller;


        private void OnEnable() {
            ResetFields();
        }


        public void UpdateLoginPage(DbResponse response) {
            SetLoading(false);
            if (response == null) {
                ResetFields();

            } else if (response.state == DbResponseState.NOTFOUND) {
                SetLoginFailed(true);
                SetEnabled(true);

            } else if (response.state == DbResponseState.SUCCESS) {
                SetLoginFailed(false);
                if (rememberMeButton.isOn) {
                    Debug.Log("Remembering this user");
                    SavedAccounts.SaveUser(usernameInput.text, passwordInput.text);
                }

            } else {
                Debug.LogWarning("Unexpected response when logging in user");
                SetLoginFailed(true);
                SetEnabled(false);
            }
        }

        public void AttemptLogin() {
            myContoller.LoginUser(usernameInput.text, passwordInput.text);
            SetLoading(true);
            SetLoginFailed(false);
            SetEnabled(false);
        }

        public void OnCancel() {
            myContoller.BackToSignIn();
        }


        private void SetLoading(bool loading) {
            loadingWheel.SetActive(loading);

        }

        private void SetLoginFailed(bool failed) {
            loginFailed.SetActive(failed);
        }

        private void SetEnabled(bool enabled) {
            float alpha = enabled ? 1f : 0.5f;
            disableWhenLoading.alpha = alpha;
            disableWhenLoading.interactable = enabled;
        }

        private void ResetFields() {
            usernameInput.text = "";
            passwordInput.text = "";
            rememberMeButton.isOn = false;
            SetEnabled(true);
            SetLoginFailed(false);
            SetLoading(false);
        }
    }
}
