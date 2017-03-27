import React from 'react'
import {VendorDetailsComponent} from '../components/component-vendor_details.js'
import {MapComponent} from '../components/component-map.js'
import {TabTogglerComponent} from '../components/component-vendor_tab_toggler'
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
    // if statement - if selected tab === beers retrn beers list
    // else - render bands list

  },

  render: function(){
    // console.log(this.props)
    if(this.props.currentVendor.name === undefined){
      return(
        <div></div>
      )
    }
		return (
			<div className="container-fluid">
          <VendorDetailsComponent {...this.props}/>
          <TabTogglerComponent/>
          <BeersComponent/>
          <BandsComponent/>

			</div>
		)
	}
})
        /* create TabToggler component (that updates store's currentVendorToggleTab thru firing an action... onClick() ) */
