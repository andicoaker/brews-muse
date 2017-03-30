import React from 'react'
import {HeaderComponent} from '../components/component-header.js'
import {LoginComponent} from '../components/component-form_login.js'

import {ACTIONS} from '../actions.js'
import {STORE} from '../store.js'

export const LoginView = React.createClass({
  render: function(){
    return (
      <div className="">
        <HeaderComponent/>
        <LoginComponent/>
      </div>
    )
  }
})
