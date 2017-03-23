import React from 'react'
import {ACTIONS} from '../actions.js'
import GoogleMapReact from 'google-map-react'

export const MapComponent = React.createClass({

  _createMapPins: function(locationsArray){
		let mapPinComponents= locationsArray.map(function(locationObj, i){
      // console.log(locationObj);
      console.log(locationsArray);

      return (
        <MapPin key={Date.now()+i} lat={locationObj.lat} lng={locationObj.lng} vendorName={locationObj.name} />
      )
		})

		return mapPinComponents
	},

  render: function(){
    return (

      <div className="map-container">
        <GoogleMapReact defaultZoom={14} defaultCenter={{lat: 32.784618, lng: -79.940918}}>
          {this._createMapPins(this.props.locationsData)}
        </GoogleMapReact>

      </div>
    )
  },
})

const MapPin = React.createClass({

	render: function(){
		return (
			<div>
        <span>{this.props.vendorName}</span>
        <i className="fa fa-map-marker" aria-hidden="true"></i>
			</div>
		)
	}
})
