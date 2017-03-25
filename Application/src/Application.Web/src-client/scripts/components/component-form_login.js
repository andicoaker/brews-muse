import React from 'react'
import {ACTIONS} from '../actions.js'

export const LoginComponent = React.createClass({

  _handleLogin: function(evt){
    let clickedRoute = evt.target.dataset.route
    let routeMapping = {
      "VENDOR_ACCOUNT" : 'vendoraccount',
    }
    ACTIONS.routeTo(routeMapping[clickedRoute])
  },

  render: function(){
    return (
    <form>
      <h1>Login</h1>
      <div className="form-group">
        <label htmlFor="exampleInputEmail1">Email:</label>
        <input type="text" className="form-control" id="exampleInputEmail1" placeholder="Enter email"/>
      </div>
      <div className="form-group">
          <label htmlFor="exampleInputPassword1">Password:</label>
          <input type="text" className="form-control" id="exampleInputPassword1" placeholder="Enter password"/>
        </div>
        <div className="form-group">
            <div className="checkbox">
              <label><input type="checkbox"/> Are you a vendor?</label>
            </div>
        </div>
        <div className="form-group">
            <button onClick={this._handleLogin} type="submit" className="btn btn-default" data-route="VENDOR_ACCOUNT">Login</button>
        </div>
    </form>
    )
  }
})
