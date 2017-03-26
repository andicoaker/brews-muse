import React from 'react'
import {VendorDetailsComponent} from '../components/component-vendor_details.js'
import {MapComponent} from '../components/component-map.js'
import {BeersComponent} from '../components/component-list_beers.js'
import {BandsComponent} from '../components/component-list_bands.js'


import {ACTIONS} from '../actions.js'
import {STORE} from '../store.js'

export const VendorProfileView = React.createClass({

  render: function(){

    // Do we need a beer/band tab component? Or can that be coded in the view?? What's best way to set this up?  If statement upon the click event - if xx-tab is clicked then render xx-view?

		return (
			<div className="container">
          <VendorDetailsComponent/>
          <BeersComponent/>
          <BandsComponent/>
			</div>
		)
	}
})
