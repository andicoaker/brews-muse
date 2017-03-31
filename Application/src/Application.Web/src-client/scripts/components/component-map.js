import React from 'react'
import {ACTIONS} from '../actions.js'
import GoogleMapReact from 'google-map-react'

export const MapComponent = React.createClass({

  getInitialState: function(){
    return {
      vendorClicked: "",
		locationsData: this.props.locationsData
    }
  },

  _createMapPins: function(locationsArray = []){
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

  componentWillReceiveProps: function(nextProps){
	//   this.setState({
	// 		locationsData: nextProps.locationsData
	//   })
  }, 

  _handleAddClick: function(evt){
	  if (this.props.fromComponent !== 'form-update') return

	  if(evt.type === 'mousedown'){
			console.log(evt.type)
         this.setState({
				mouseDownTimestamp: Date.now()
			})
	  }

	  if(evt.type === 'mouseup'){
		  console.log(evt.type)
        this.setState({
				mouseDownTimestamp: null,
			   userWillDropPin: Date.now() - this.state.mouseDownTimestamp > 700 
		  })
	  }
	
	  if(evt.type === 'click' && this.state.userWillDropPin){
		 console.log(evt)
		 this.props.addUserPinToMap(evt)
		  
        this.setState({
  			   userWillDropPin: false,
				locationsData: [{lng: evt.lng, lat: evt.lat, vendorName: '', index: 0 }]
  		  })
  	  }
		
     
  },

  render: function(){
    let zoomVal = 15
    let centerCoords = {lat: 32.782618, lng: -79.935918}
    let mapClassName = "map-container"

    if (typeof this.props.customZoomVal !== 'undefined'){
      zoomVal = this.props.customZoomVal
    }

    if (typeof this.props.customCenterCoords !== 'undefined'){
      centerCoords = this.props.customCenterCoords
    }

    return (
      <div className={mapClassName} onMouseDown={this._handleAddClick} onMouseUp={this._handleAddClick}>
        <GoogleMapReact
          defaultZoom={zoomVal}
          defaultCenter={centerCoords}
		    onClick={(coords)=>{ this._handleAddClick( Object.assign(coords, {type: 'click'}) )  }}
			 >
          {this._createMapPins(this.state.locationsData)}
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
    } else{
      return
    }
  },

	render: function(){
		return (
			<div
        className={this.state.classStyles}
        onMouseEnter={this._togglePinHover}
        onClick={this._togglePinHover}>
        <i className="fa fa-map-marker fa-2x" aria-hidden="true"> {this._renderVendor()}</i>
			</div>
		)
	}
})
