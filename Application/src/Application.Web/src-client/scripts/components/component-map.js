import React from 'react'
import {ACTIONS} from '../actions.js'
import GoogleMapReact from 'google-map-react'

export const MapComponent = React.createClass({

  getInitialState: function(){
    return{
          isClicked : false,
          vendorName : ""
        }

  },

  _createMapPins: function(locationsArray){
    let component = this
    let mapPinComponents= locationsArray.map(function(locationObj, i){
      // console.log(locationObj);
      // console.log(locationsArray);

      return (
        <MapPin
          key={Date.now()+i}
          isClicked={component.state.isClicked}
          lat={locationObj.lat}
          lng={locationObj.lng}
          vendorName={locationObj.name}
          handlePinHoverCB ={component._handlePinHoverCB}/>
      )
		})

		return mapPinComponents
	},


  _handlePinHoverCB: function(evtType, vendorName){
    console.log('firignnnn')
    // this.props.handlePinHoverCB(this.props.place)
    if(evtType){
      this.setState({
        isClicked : evtType,
        vendorName : vendorName
      })
    }else{
      this.setState({
        isClicked : evtType,
        vendorName : ""
      })
    }

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
          defaultZoom={14}
          defaultCenter={{lat: 32.784618, lng: -79.940918}}>
          {this._createMapPins(this.props.locationsData)}
        </GoogleMapReact>
        {this._showInfo()}
      </div>
    )
  },
})


const MapPin = React.createClass({

  getInitialState: function(){
    return { isHovered: false, classStyles: "map-pin" }
  },



  _togglePinHover: function (evt){
    console.log('hello? is it me you are listening for?', evt.type);
    //
    let toggleInfo
    if(evt.type === "mouseenter"){
      this.setState({
        isHovered: true,
        classStyles: "selected map-pin"

      })
    }else{
      this.setState({
        isHovered: false,
        classStyles: "map-pin"

      })
    }
    // console.log(toggleInfo)
    // this.props.handlePinHoverCB(toggleInfo, this.props.vendorName)

  },
  _renderName: function(){
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
			<div className={this.state.classStyles}
        onMouseEnter={this._togglePinHover}
        onMouseLeave={this._togglePinHover}>
        <i className="fa fa-map-marker" aria-hidden="true"></i>
        {this._renderName()}

			</div>
		)
	}
})
