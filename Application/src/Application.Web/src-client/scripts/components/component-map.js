import React from 'react'
import {ACTIONS} from '../actions.js'
import GoogleMapReact from 'google-map-react'

export const MapComponent = React.createClass({

  getInitialState: function(){
    return {
      vendorClicked: ""
    }
  },

  _createMapPins: function(locationsArray){
    let component = this
    let mapPinComponents = locationsArray.map(function(locationObj, i){
      let clicked = false
      if(component.state.vendorClicked === i){
        clicked = true
      }
      return (
        <MapPin
          key={Date.now()+i}
          index={i}
          isClicked={clicked}
          lat={locationObj.lat}
          lng={locationObj.lng}
          vendorName={locationObj.name}
          showInfoCB ={component._handlePinHoverCB}
        />
      )
		})
		return mapPinComponents
	},


  _handlePinHoverCB: function(vendorId){
      this.setState({
        vendorClicked : vendorId
      })


  },

  _showInfo: function(){
    if(this.state.isClicked){
      return (
        <h1>{this.state.vendorName}</h1>
      )

    }else{
      return
    }
  },

  render: function(){
    return (

      <div className="map-container">
        <GoogleMapReact
          defaultZoom={15}
          defaultCenter={{lat: 32.782618, lng: -79.935918}}>
          {this._createMapPins(this.props.locationsData)}
        </GoogleMapReact>
        {this._showInfo()}
      </div>
    )
  },
})


const MapPin = React.createClass({

  getInitialState: function(){
    return { isHovered: this.props.isClicked, classStyles: "map-pin" }
  },

  _togglePinHover: function (evt){
    this.props.showInfoCB(this.props.index)
    console.log('hello? is it me you are listening for?', evt.type);
    //
    let toggleInfo
    if(this.state.isHovered){
      this.setState({
        classStyles: "selected map-pin"

      })
    }else{
      this.setState({
        classStyles: "map-pin"

      })
    }

  },
  _renderVendor: function(){
    if(this.state.isHovered){
      return (
        <span>{this.props.vendorName}</span>
      )

    }
    else{
      return
    }
  },

	render: function(){
		return (
			<div
        className={this.state.classStyles}
        onMouseEnter={this._togglePinHover}
        onClick={this._togglePinHover}>
        {this._renderVendor()}

        <i className="fa fa-map-marker fa-2x" aria-hidden="true"></i>
			</div>
		)
	}
})
