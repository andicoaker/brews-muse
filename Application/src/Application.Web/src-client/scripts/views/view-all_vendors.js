import React from 'react'
import {HeaderComponent} from '../components/component-header.js'
import {MapComponent} from '../components/component-map.js'
import {AllVendorsListComponent} from '../components/component-list_all_vendors.js'
import {NavbarComponent} from '../components/component-navbar.js'


import {ACTIONS} from '../actions.js'
import {STORE} from '../store.js'

export const AllVendorsView = React.createClass({

  render: function(){

		return (
			<div className="container">
          <HeaderComponent/>
          <MapComponent/>
          <AllVendorsListComponent/>
          <NavbarComponent/>
			</div>
		)
	}
})
