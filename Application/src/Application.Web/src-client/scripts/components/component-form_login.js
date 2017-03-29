import React from 'react'
import {ACTIONS} from '../actions.js'

export const LoginComponent = React.createClass({
  _handleLogin: function(evt){
    evt.preventDefault()
  	let formEl = evt.target
  	let emailVal = formEl.emailField.value
    let passwordVal = formEl.passwordField.value
    ACTIONS.loginUser(emailVal, passwordVal)
  },

  render: function(){
    return (
    <form onSubmit={this._handleLogin}>
      <h1>Login</h1>
      <div className="form-group">
        <label htmlFor="exampleInputEmail1">Email:</label>
        <input type="text" className="form-control" name="emailField" placeholder="Enter email"/>
      </div>
      <div className="form-group">
          <label htmlFor="exampleInputPassword1">Password:</label>
          <input type="password" className="form-control" name="passwordField" placeholder="Enter password"/>
        </div>
        <div className="form-group">
            <div className="checkbox">
              <label><input type="checkbox"/> Are you a vendor?</label>
            </div>
        </div>
        <div className="form-group">
            <button type="submit" className="btn submit-button">Login</button>
        </div>
    </form>
    )
  }
})
