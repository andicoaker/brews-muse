import React from 'react'
import {RegisterComponent} from '../components/component-form_register.js'

import {ACTIONS} from '../actions.js'
import {STORE} from '../store.js'

export const RegisterView = React.createClass({

  render: function(){
    return (
      <div className="register-container">
        <RegisterComponent/>
      </div>
    )
  }
})
