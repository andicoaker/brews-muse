import React from 'react'
import {ACTIONS} from '../actions.js'

export const AnonNavbarComponent = React.createClass({

  _handleNavClick: function(evt){
		let clickedRoute = evt.target.dataset.route
		let routeMapping = {
			"REGISTER" : 'register',
			"LOGIN" : 'login',
			"ALL_VENDORS" : 'allvendors',
      "VENDOR_PROFILE" : 'vendorprofile',
      "HOME" : ''
		}
		// window.location.hash = evt.target.dataset.route
		ACTIONS.routeTo(routeMapping[clickedRoute])
	},

  render: function(){

    return (
      <nav className="navbar navbar-default navbar-fixed-bottom">
        <div className="btn-group btn-group-justified" role="group" aria-label="...">
          <div className="btn-group" role="group">
            <button type="button" className="btn btn-default nav-btn" onClick={this._handleNavClick} data-route="HOME">Home</button>
          </div>
          <div className="btn-group" role="group">
            <button type="button" className="btn btn-default nav-btn" onClick={this._handleNavClick} data-route="ALL_VENDORS">Browse</button>
          </div>
          <div className="btn-group" role="group">
            <button type="button" className="btn btn-default nav-btn" onClick={this._handleNavClick} data-route="REGISTER">Sign-up</button>
          </div>
          <div className="btn-group" role="group">
            <button type="button" className="btn btn-default nav-btn" onClick={this._handleNavClick} data-route="LOGIN">Login</button>
          </div>
        </div>
      </nav>
    )
  }
})

export const AuthNavbarComponent = React.createClass({

  _handleLogoutClick: function(){
		ACTIONS.logUserOut()
	},

  render: function(){

    return (
      <nav className="navbar navbar-default navbar-fixed-bottom">
        <div className="btn-group btn-group-justified" role="group" aria-label="...">
          <div className="btn-group" role="group">
            <button type="button" className="btn btn-default nav-btn" onClick={this._handleNavClick} data-route="HOME">Home</button>
          </div>
          <div className="btn-group" role="group">
            <button type="button" className="btn btn-default nav-btn" onClick={this._handleNavClick} data-route="VENDOR_PROFILE">Profile</button>
          </div>
          <div className="btn-group" role="group">
            <button type="button" className="btn btn-default nav-btn" onClick={this._handleNavClick} data-route="VENDOR_ACCOUNT">Account</button>
          </div>
          <div className="btn-group" role="group">
            <button type="button" className="btn btn-default nav-btn" onClick={this._handleLogoutClick} data-route="LOGOUT">Logout</button>
          </div>
        </div>
      </nav>
    )
  }
})
