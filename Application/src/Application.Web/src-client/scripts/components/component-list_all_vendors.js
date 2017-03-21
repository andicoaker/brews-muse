import React from 'react'
import {ACTIONS} from '../actions.js'

// **** Need to verify if list component below is set-up correctly ****


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
    console.log(this.props)
    return(
      <div>
        {this._makeVendorComponents(this.props.allVendors)}
      </div>

    )

// do i even need makevendorcomponent?  or can i simply pass my vendorslist function through the render function above?

  }
})

export const VendorsListItem = React.createClass({

  render: function(){

    return (

      <div className="media">
        <div className="media-left">
          <a href="#">
            <img className="media-object" src={this.props.vendor.ImageURL} alt="..."/>
          </a>
        </div>
        <div className="media-body">
          <h4 className="media-heading">{this.props.vendor.vendorName}</h4>
          {this.props.vendor.Address1}
          {this.props.vendor.City}, {this.props.vendor.State} {this.props.vendor.ZipCode}
          <a href="">{this.props.vendor.VendorURL}</a>
        </div>
      </div>

    )
  }
})
