import React from 'react'
import {RegisterComponent} from '../components/component-form_register.js'


export const RegisterView = React.createClass({

  render: function(){
    return (
      <div className="register-container">
        <RegisterComponent/>
      </div>
    )
  }
})
