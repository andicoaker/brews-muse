import React from 'react'
import {ACTIONS} from '../actions.js'
import GoogleMapReact from 'google-map-react'

export const MapComponent = React.createClass({

  // getInitialState: function(){
  //   return{
  //     locationsData : this.props.locationsData
  //   }
  //
  // },

  _createMapPins: function(locationsArray){
    let component = this
    let mapPinComponents= locationsArray.map(function(locationObj, i){
      // console.log(locationObj);
      // console.log(locationsArray);

      return (
        <MapPin key={Date.now()+i} lat={locationObj.lat} lng={locationObj.lng} vendorName={locationObj.name} handlePinHoverCB ={this._handlePinHoverCB}/>
      )
		})

		return mapPinComponents
	},

  // _handleMapClick: function(evt){
  //   console.log(evt);
  //   let locationsCopy = [...this.state.locationsData]
  //   locationsCopy.push({lt: evt.lat, lg: evt.lng})
  //
  //   this.setState({
  //     locationsData : locationsCopy
  //   })
  //
  // },

  _handlePinHoverCB: function(payload){
    console.log('POLO!', payload);
    this.props.handlePinHoverCB(this.props.place)

    this.setState()
  },

  render: function(){
    return (

      <div className="map-container">
        <GoogleMapReact defaultZoom={14} defaultCenter={{lat: 32.784618, lng: -79.940918}}>
          {this._createMapPins(this.props.locationsData)}
          <h3>
            Location Info: <mark></mark>
          </h3>
        </GoogleMapReact>
      </div>
    )
  },
})



const MapPin = React.createClass({

  getInitialState: function(){
    // pinStyle:
  },

  _togglePinHover: function (evt){
    console.log('hello? is it me you are listening for?', evt);

    // if(evt.type === 'mouseover')
    console.log('MARCO: ', thisprops.place);


  },



	render: function(){
		return (
			<div onMouseOver={this._togglePinHover} onMouseOut={this._togglePinHover}>
        <span>{this.props.vendorName}</span>
        <i className="fa fa-map-marker" aria-hidden="true"></i>
			</div>
		)
	}
})
