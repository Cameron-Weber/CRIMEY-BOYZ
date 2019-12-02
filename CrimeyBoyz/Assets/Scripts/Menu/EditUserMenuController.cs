using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CrimeyBoyz.Menu.MissionControl {
    public class EditUserMenuController : MonoBehaviour {

        public InputField usernameInput;
        public InputField passwordInput;
        public GameObject loginFailed;
        public GameObject loadingWheel;
        public CanvasGroup disableWhenLoading;
        public MissionControlLobbyController myContoller;

        private string username = "";

        private void OnEnable() {
            ResetFields("");
        }

        public void UpdateEditMenu(string username, DbResponse response) {
            SetLoading(false);
            if (response == null || !this.username.Equals(username)) {
                ResetFields(username);

            } else if (response.state == DbResponseState.NOTFOUND) {
                SetLoginFailed(true);
                SetEnabled(true);

            } else if (response.state == DbResponseState.SUCCESS) {
                SetLoginFailed(false);
                SavedAccounts.SaveUser(username, passwordInput.text);

            } else {
                Debug.LogWarning("Unexpected response when logging in user");
                SetLoginFailed(true);
                SetEnabled(false);
            }
        }

        public void AttemptLogin() {
            myContoller.LoginUser(username, passwordInput.text);
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

        private void ResetFields(string username) {
            this.username = username;
            usernameInput.text = username;
            passwordInput.text = "";
            SetEnabled(true);
            SetLoginFailed(false);
            SetLoading(false);
        }
    }
}
