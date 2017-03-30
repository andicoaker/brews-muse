import React from 'react'
import {HeaderComponent} from '../components/component-header.js'
import {VendorDetailsComponent} from '../components/component-vendor_details.js'
import {MapComponent} from '../components/component-map.js'
import {TabTogglerComponent} from '../components/component-vendor_tab_toggler'
import {BeersComponent} from '../components/component-list_beers.js'
import {BandsComponent} from '../components/component-list_bands.js'


import {ACTIONS} from '../actions.js'
import {STORE} from '../store.js'

export const VendorProfileView = React.createClass({

  getInitialState: function(){
    return{
      viewToRender: 'beers'
    }
  },

  componentWillMount: function(){
    console.log(this.props.routeParams.vendorId);
    let theVendorId = this.props.routeParams.vendorId
    ACTIONS.fetchSingleVendor(theVendorId)
  },

  _renderSelectedTab: function(selectedTab, theRoute){
    // if statement - if selected tab === beers return beers list
    // else - return bands list
    if (this.state.viewToRender === "beers") {
      return <BeersComponent allBeers={this.props.currentVendor.beers}/>
    }else if(this.state.viewToRender === "bands") {
      return <BandsComponent allBands={this.props.currentVendor.bands}/>
    }
  },

  _changeDetails: function(payload){
    this.setState({viewToRender: payload})
  },

  render: function(){
    console.log(this.props)
    if(this.props.currentVendor.name === undefined){
      return(
        <div></div>
      )
    }

    let currentVendor = this.props.currentVendor
    let vendorLatLng = {
      lat : currentVendor.lat,
      lng : currentVendor.lng
    }

		return (
			<div className="container-fluid">
          <HeaderComponent/>
          <VendorDetailsComponent {...this.props}/>
          <MapComponent
            customZoomVal={18}
            customCenterCoords={vendorLatLng}
            locationsData={[currentVendor]}/>
          <TabTogglerComponent
             selectedTab={this.state.viewToRender}
             handleViewChange={this._changeDetails}/>
          {this._renderSelectedTab()}
			</div>
		)
	}
})
        /* create TabToggler component (that updates store's currentVendorToggleTab thru firing an action... onClick() ) */
