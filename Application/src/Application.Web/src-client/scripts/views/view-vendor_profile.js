import React from 'react'
import {HeaderComponent} from '../components/component-header.js'
import {VendorDetailsComponent} from '../components/component-vendor_details.js'
import {MapComponent} from '../components/component-map.js'
import {BeersListComponent} from '../components/component-list_beers.js'
import {BandsListComponent} from '../components/component-list_bands.js'
import {NavbarComponent} from '../components/component-navbar.js'


import {ACTIONS} from '../actions.js'
import {STORE} from '../store.js'

export const VendorProfileView = React.createClass({

  render: function(){

    // Do we need a beer/band tab component? Or can that be coded in the view?? What's best way to set this up?

		return (
			<div className="container">
          <HeaderComponent/>
          <VendorDetailsComponent/>
          <MapComponent/>
          <BeersListComponent/>
          <BandsListComponent/>
          <NavbarComponent/>
			</div>
		)
	}
})
