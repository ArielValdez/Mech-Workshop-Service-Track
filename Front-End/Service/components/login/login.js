//Delete login.css if needed

import React from 'react';
import "./login.css";

const [popupStyle, showPopup] = useState("hide")

const popup = () => {
    showPopup("login-popup")
    setTimeout(() => showPopup("hide"), 3000)
}

const LoginForm = () => {
    return (
        <div className="cover">
            <h1> Login </h1>
            <input type="text" placeholder="username"/>
            <input type="password" placeholder="password"/>
            
            <div className="login-btn" onClick={popup}> Login </div>

            {/* This block below offers an alternate login for the user,
            that may or may not be required for this app */}

            <p className="text"> Or login using </p>
            <div className="alt-login">
                <div className="facebook"> </div>
                <div className="google"> </div>
            </div>

            <div className={"popupStyle"}>
                <h3> Login Failed </h3>
                <p> Username or Password Incorrect</p>
            </div>

        </div>
    )
}

export default login;

//Video: https://www.youtube.com/watch?v=4BhhGs0PFHU
//Another Video: https://www.youtube.com/watch?v=W1RWa0aU1pE&t=2s
//Yet Another Video: https://www.youtube.com/watch?v=d1j1NcRMvV0 | https://github.com/moses-netshitangani/responsive-login-form
//Using hooks: https://www.youtube.com/watch?v=8hU0I8rY4u4
