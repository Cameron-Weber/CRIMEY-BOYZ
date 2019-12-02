using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DbResponseState {
    NOCONNECTION,
    NOTFOUND,
    SUCCESS,
    USERNAME_EXISTS,
    EMAIL_EXISTS,
    PASSWORDS_DONT_MATCH,
    OTHER
}

public class DbResponse {

    public DbResponseState state { get; private set; }
    public string message { get; private set; }
    public Dictionary<string, string> headers { get; private set; }

    public DbResponse(DbResponseState state, string text, Dictionary<string, string> headers) {
        this.state = state;
        this.message = text;
        this.headers = new Dictionary<string, string>(headers);
    }

    public DbResponse(DbResponse copy) {
        state = copy.state;
        message = copy.message;
        headers = new Dictionary<string, string>(copy.headers);
    }
}