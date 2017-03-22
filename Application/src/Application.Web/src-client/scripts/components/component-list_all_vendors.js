import React from 'react'
import {ACTIONS} from '../actions.js'

export const VendorsListComponent = React.createClass({

  _makeVendorComponents: function(vendorsList){
    let arrayOfVendorsComponents = vendorsList.map(function(vmod, i){
      return (
        <VendorsListItem vendorData={vmod} key={i}/>
      )
    }).reverse()

    return arrayOfVendorsComponents
  },

  render: function(){
    console.log("vendors list component props: ", this.props)
    return(

      <div>
        {/*
        <div className="row">
          <div className="container-fluid col-xs-12 filter-menu">
            <div className="col-xs-6">
              Find brews or live music
            </div>
            <div className="col-xs-6">
              <button type="button" name="button">Filter Drop Down</button>
            </div>
          </div>
        </div>
        <div className="container-fluid col-xs-12 map-container">
          Map place-holder container
        </div> */}

        <div>
          {this._makeVendorComponents(this.props.allVendors)}
        </div>

      </div>
    )
  }
})

export const VendorsListItem = React.createClass({

  render: function(){

    return (

        <div className="media">
          <div className="media-left">
            <a href="#vendorprofile">
              <img className="media-object" src={this.props.vendorData.imageURL} alt="..."/>
            </a>
          </div>
          <div className="media-body">
            <h4 className="media-heading">{this.props.vendorData.name}</h4>
            {this.props.vendorData.address1}&nbsp;
            {this.props.vendorData.city}, {this.props.vendorData.state} {this.props.vendorData.zipCode}
            <a href="">{this.props.vendorData.vendorURL}</a>
          </div>
        </div>

    )
  }
})
