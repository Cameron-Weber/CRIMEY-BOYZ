using System;

namespace CrimeyBoyz.GameState {
    //Information for each player's state
    public class PlayerInfo {

        [Obsolete("Use PlayerInfo.assignedController instead")]
        public int controllerNum;

        [Obsolete("Use PlayerInfo.characterName instead")]
        public string name;

        public int assignedController; //-1 for not assigned
        public string username;
        public string characterName;
        public int score;

        public PlayerInfo() {
            assignedController = -1;
            username = null;
            characterName = null;
            score = 0;
        }

        [Obsolete("Use new PlayerInfo() instead")]
        public PlayerInfo(int controllerNumber, string playerName) {
            assignedController = controllerNumber;
            controllerNum = assignedController;

            characterName = playerName;
            name = playerName;

            score = 0;
        }

        //Convert this class to the obsolete one (for backwards compatibility)
        /*public static implicit operator SessionManager.PlayerInfo(PlayerInfo x) {
            SessionManager.PlayerInfo result = new SessionManager.PlayerInfo(x.assignedController, x.characterName);

            result.score = x.score;

            return result;
        }*/
    }
}
