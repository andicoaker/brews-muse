import React from 'react'
import {LoginComponent} from '../components/component-form_login.js'


export const LoginView = React.createClass({
  render: function(){
    return (
      <div className="login-container">
        <LoginComponent/>
      </div>
    )
  }
})
