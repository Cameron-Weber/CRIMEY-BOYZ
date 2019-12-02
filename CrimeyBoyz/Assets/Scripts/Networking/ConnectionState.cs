//Possible states for the ConnectionManager
public enum ConnectionState {
    STOPPED, //Connection closed, server / client stopped
    LISTENING, //Server listening for client
    SEARCHING, //Client broadcasting / searching for a server
    CONNECTING, //Client attempting to search for a server
    DENIED, //Client rejected by the server after attempting connection
    CONNECTED, //Client / Server connected
    DISCONNECTED //Client / Server were connected but not anymore
}