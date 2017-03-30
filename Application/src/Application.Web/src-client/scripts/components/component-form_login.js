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
    <form className="form-login" onSubmit={this._handleLogin}>
      <h1 className="form-header">Vendor Login</h1>
      <div className="form-group">
        <label htmlFor="exampleInputEmail1">Email:</label>
        <input type="text" className="form-control input-lg font2" name="emailField" placeholder="Enter Email"/>
      </div>
      <div className="form-group">
        <label htmlFor="exampleInputPassword1">Password:</label>
        <input type="password" className="form-control font2" name="passwordField" placeholder="Enter Password"/>
      </div>
      <div className="form-group">
        <button type="submit" className="btn submit-button">Login</button>
      </div>
    </form>
    )
  }
})


      // <select>
      //   <option value="" selected disabled>Are you a Vendor?</option>
      //   <option value="">Yes</option>
      //   <option value="">No</option>
      // </select>

  // <span className="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>

{/* <div className="form-group">
    <div className="big-checkbox">
      <label><input type="checkbox"/> Are you a vendor?</label>
    </div>
</div> */}
