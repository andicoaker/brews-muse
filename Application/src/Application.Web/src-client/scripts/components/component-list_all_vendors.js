import React from 'react'

// **** Need to verify list component below is set-up correctly ****


export const AllVendorsListComponent = React.createClass({
  _makeVendorComponents: function(vendorsList){
    let arrayOfVendorsComponents = vendorsList.map(function(smod, i){
      return (
        <VendorListItem vendorData={smod} key={i}/>
      )
    }).reverse()

    return arrayOfVendorsComponents
  },


  render: function(){

    return this._makeVendorComponents()

// do i even need makevendorcomponent?  or can i simply pass my vendorslist function through the render function above?
// in demo what does smod stand for - shout model? should i change to vmod for vendor model?

  }
})

export const VendorListItem = React.createClass({

  render: function(){

    return (

      <div className="media">
        <div className="media-left">
          <a href="#">
            <img className="media-object" src="Insert Vendor Logo src HERE" alt="..."/>
          </a>
        </div>
        <div className="media-body">
          <h4 className="media-heading">Insert Vendor Name HERE!</h4>
          Insert Vendor Address HERE!
          <a href="#">Insert Vendor Web Site HERE!</a>
        </div>
      </div>

    )
  }
})
