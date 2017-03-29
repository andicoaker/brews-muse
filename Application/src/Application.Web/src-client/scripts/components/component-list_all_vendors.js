import React from 'react'
import {ACTIONS} from '../actions.js'

export const AllVendorsComponent = React.createClass({

  _makeVendorComponents: function(vendorsList){
    let arrayOfVendorsComponents = vendorsList.map(function(vmod, i){
      return (
        <SingleVendor vendorData={vmod} key={i}/>
      )
    }).reverse()

    return arrayOfVendorsComponents
  },

  render: function(){
    console.log("vendors list component props: ", this.props)

    return(
      <div>
        {this._makeVendorComponents(this.props.allVendors)}
      </div>
    )
  }
})

export const SingleVendor = React.createClass({
  _handleVendorClick: function(evt){
    console.log(evt.currentTarget);
    let clickedVendorId = evt.currentTarget.dataset.vendor_id
    console.log(clickedVendorId);

    ACTIONS.routeTo(`vendorprofile/${clickedVendorId}`)
  },


  render: function(){

    return (

        <div className="media" onClick={this._handleVendorClick} data-vendor_id={this.props.vendorData.id}>
          <div className="media-left">
              <img className="media-object" src={this.props.vendorData.imageURL} alt="..."/>
          </div>
          <div className="media-body">
            <h2 className="media-heading">{this.props.vendorData.name}</h2>
            <p className="font2">
              {this.props.vendorData.address}&nbsp; {this.props.vendorData.city}, {this.props.vendorData.state} {this.props.vendorData.zipCode}
            </p>
            <p><a className="font2" href="">{this.props.vendorData.vendorURL}</a></p>
          </div>
        </div>

    )
  }
})
