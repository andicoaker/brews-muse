import React from 'react'
import {HeaderComponent} from '../components/component-header.js'
import {HomeComponent} from '../components/component-home.js'
import {NavbarComponent} from '../components/component-navbar.js'


import {ACTIONS} from '../actions.js'
import {STORE} from '../store.js'

export const WelcomeView = React.createClass({

  render: function(){

		return (
			<div className="container">
          <HomeComponent/>
			</div>
		)
	}
})
