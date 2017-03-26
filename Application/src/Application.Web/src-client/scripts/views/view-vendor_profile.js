import React from 'react'
import {VendorDetailsComponent} from '../components/component-vendor_details.js'
import {MapComponent} from '../components/component-map.js'
import {BeersComponent} from '../components/component-list_beers.js'
import {BandsComponent} from '../components/component-list_bands.js'


import {ACTIONS} from '../actions.js'
import {STORE} from '../store.js'

export const VendorProfileView = React.createClass({

  componentWillMount: function(){
    console.log(this.props.routeParams.vendorId);
    let theVendorId = this.props.routeParams.vendorId
    ACTIONS.fetchSingleVendor(theVendorId)


  },

  _renderSelectedTabList: function(selectedTab){

  },

  render: function(){


		return (
			<div className="container">
          <VendorDetailsComponent/>

          {/* create TabToggler component (that updates store's currentVendorToggleTab thru firing an action... onClick() ) */}

			</div>
		)
	}
})
