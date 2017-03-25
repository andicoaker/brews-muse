import React from 'react'
import {ACTIONS} from '../actions.js'
import {VendorsListComponent} from '../components/component-list_all_vendors.js'
import {AppRouter} from '../router.js'

export const RegisterComponent = React.createClass({
  getInitialState: function(){
    return {
      registeredUser: ''
    }
  },

  _handleSubmit: function(evt){
  // let clickedRoute = evt.target.dataset.route
  // let routeMapping = {
  //   "ALL_VENDORS" : 'allvendors',
  // }
  // ACTIONS.routeTo(routeMapping[clickedRoute])
    evt.preventDefault()
  	let formEl = evt.target
  	let objToSave = {
  		 email: formEl.emailField.value ,
  	   password: formEl.passwordField.value
  	}
  	ACTIONS.registerNewUser(objToSave)
    ACTIONS.routeTo(routeMapping[clickedRoute])
  },

  render: function(){
    return (
    <form onSubmit={this._handleSubmit}>
       <h1>Register</h1>
        {/* <div className="form-group">
          <label htmlFor="InputUserName">Username:</label>
          <input type="text" className="form-control" name="userNameField" placeholder="Enter Username"/>
        </div> */}
        <div className="form-group">
          <label htmlFor="InputEmail">Email:</label>
          <input type="text" className="form-control" name="emailField" placeholder="Enter email"/>
        </div>
        <div className="form-group">
          <label htmlFor="InputPassWord">Password:</label>
          <input type="text" className="form-control" name="passwordField" placeholder="Enter password"/>
        </div>
        {/* <div className="form-group">
            <label htmlFor="InputConfirmPass">Confirm password:</label>
            <input type="text" className="form-control" name="confirmPassField" placeholder="Confirm password"/>
        </div> */}
        <div className="form-group">
            <div className="checkbox">
              <label><input type="checkbox"/> Are you a vendor?</label>
            </div>
        </div>
        <div className="form-group">
            <button type="submit" className="btn btn-default">Sign Up</button>
        </div>
    </form>
    )
  }
})
