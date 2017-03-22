import React from 'react'
import {ACTIONS} from '../actions.js'
import GoogleMapReact from 'google-map-react'

export const MapComponent = React.createClass({

  render: function(){
    return (

      <div className="map-container">
        <GoogleMapReact defaultZoom={14} defaultCenter={{lat: 32.784618, lng: -79.940918}} />
      </div>

    )
  }
})
