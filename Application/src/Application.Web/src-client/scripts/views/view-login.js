import React from 'react'
import {LoginComponent} from '../components/component-form_register.js'


export const RegisterView = React.createClass({
  console.log(RegisterView)
  render: function(){
    return (
      <div className="login-container">
        <LoginComponent/>
      </div>
    )
  }
})
