import React from 'react'
import {ACTIONS} from '../actions.js'
import {AllVendorsComponent} from '../components/component-list_all_vendors.js'
import {AppRouter} from '../router.js'

export const RegisterComponent = React.createClass({
  getInitialState: function(){
    return {
      registeredUser: ''
    }
  },

  _handleSubmit: function(evt){
    evt.preventDefault()
  	let formEl = evt.target
  	let objToSave = {
  		  email: formEl.emailField.value,
  	    password: formEl.passwordField.value,
        passwordconfirm: formEl.passwordConfirmField.value
  	}
   ACTIONS.registerNewUser(objToSave)
  },

  render: function(){
    return (
      <form className="form-register" onSubmit={this._handleSubmit}>
        <h1 className="form-header">Register a Vendor Account</h1>
        <div className="form-group">
          <label htmlFor="InputEmail">Email:</label>
          <input type="text" className="form-control font2" name="emailField" placeholder="Enter Email"/>
        </div>
        <div className="form-group">
          <label htmlFor="InputPassWord">Password:</label>
          <input type="password" className="form-control font2" name="passwordField" placeholder="Enter Password"/>
        </div>
        <div className="form-group">
          <label htmlFor="InputConfirmPass">Confirm Password:</label>
          <input type="password" className="form-control font2" name="passwordConfirmField" placeholder="Confirm Password"/>
        </div>
        <div className="form-group">
          <button type="submit" className="btn submit-button">Sign-Up</button>
        </div>
      </form>
    )
  }
})
//
// <div className="form-group">
//   <select>
//     <option value="" selected disabled>Are you a Vendor?</option>
//     <option value="">Yes</option>
//     <option value="">No</option>
//   </select>
// </div>
