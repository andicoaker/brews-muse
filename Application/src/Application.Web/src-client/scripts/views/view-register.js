import React from 'react'
import {HeaderComponent} from '../components/component-header.js'
import {RegisterComponent} from '../components/component-form_register.js'

import {ACTIONS} from '../actions.js'
import {STORE} from '../store.js'

export const RegisterView = React.createClass({

  render: function(){
    return (
      <div className="container-fluid">
        <HeaderComponent/>
        <RegisterComponent/>
      </div>
    )
  }
})
