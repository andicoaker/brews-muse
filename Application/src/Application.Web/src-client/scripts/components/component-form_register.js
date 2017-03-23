import React from 'react'
import {ACTIONS} from '../actions.js'

export const RegisterComponent = React.createClass({

  _handleSubmit: function(evt){
    let clickedRoute = evt.target.dataset.route
    let routeMapping = {
      "ALL_VENDORS" : 'allvendors'
    }
    ACTIONS.routeTo(routeMapping[clickedRoute])
    console.log("we clickin boi")
  },

  render: function(){
    return (
    <form>
       <h1>Register</h1>
        <div className="form-group">
          <label htmlFor="exampleInputEmail1">Email:</label>
          <input type="text" className="form-control" id="exampleInputEmail1" placeholder="Enter email"/>
        </div>
        <div className="form-group">
          <label htmlFor="exampleInputPassword1">Password:</label>
          <input type="text" className="form-control" id="exampleInputPassword1" placeholder="Enter password"/>
        </div>
        <div className="form-group">
            <label htmlFor="exampleInputPasswordConfirm1">Confirm password:</label>
            <input type="text" className="form-control" id="exampleInputPasswordConfirm1" placeholder="Confirm password"/>
        </div>
        <div className="form-group">
            <div className="checkbox">
              <label><input type="checkbox"/> Are you a vendor?</label>
            </div>
        </div>
        <div className="form-group">
            <button onClick={this._handleSubmit} type="submit" className="btn btn-default">Sign Up</button>
        </div>
    </form>
    )
  }
})
