import React from 'react'
import {ACTIONS} from '../actions.js'
import GoogleMapReact from 'google-map-react'

export const MapComponent = React.createClass({

  _createMapPins: function(locationsArray){
		let mapPinComponents= locationsArray.map(function(locationObj, i){
			return <MapPin key={Date.now()+i} lat={locationObj.latitude} lng={locationObj.longitude} location={locationObj.name} />
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
          <i class="fa fa-map-marker" aria-hidden="true"></i>
  				<span>{this.props.location}</span>
  			</div>
  		)
  	}
})
