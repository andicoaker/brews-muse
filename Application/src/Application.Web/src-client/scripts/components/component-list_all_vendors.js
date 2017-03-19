import React from 'react'

// **** Need to verify list component is set-up correctly ****

export const AllVendorsListComponent = React.createClass({

  render: function(){

    _makeShoutOutComponents: function(vendorsList){
   let arrayOfVendorsComponents = vendorsList.map(function(smod, i){
        return (
           <VendorListItem shoutData={smod} key={i}/>
        )
     }).reverse()

   return arrayOfVendorsComponents

})

export const VendorListItem = React.createClass({

  render: function(){

    return (

      <div className="media">
        <div className="media-left">
          <a href="#">
            <img className="media-object" src="Insert Vendor Logo src HERE" alt="..."</img>
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
