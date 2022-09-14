using System;
using System.Collections;

public static class Messages {
    public static Messages() {

    }

    //This message will only be used when the application initializes.
    public static string InicializingProgram() {
        try {
            return "Program has started";
        } catch () {
            return "An error has occurred";
        }
    }

    //These will be the messages in API from the front end, to the back end
    public static string SendMessage() {
        try {
            return "Message";
        } catch(Exception ex) {
            return "The following exception has occurred during the process of the applicaciton: {0}", ex;
        }
    }
}