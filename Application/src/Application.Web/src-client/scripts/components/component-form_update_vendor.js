import React from 'react'
import {ACTIONS} from '../actions.js'

export const UpdateVendorComponent = React.createClass({

   _vendorUpdateSubmit: function(evt){
     evt.preventDefault()
     let formEl = evt.target
     let objToSave = {
       name: formEl.inputName.value,
      //  ownerName: formEl.inputOwner.value,
      //  address: formEl.inputAddress.value,
      //  city: formEl.inputCity.value,
      //  state: formEl.inputState.value,
      //  zipCode: formEl.inputZip.value,
      //  hours: formEl.inputHours.value,
      //  vendorURL: formEl.inputWebsite.value,
      //  vendorPhone: formEl.inputPhone.value,
      //  imageURL: formEl.inputImage.value
     }

     //console.log(objToSave)
     ACTIONS.setView('ALL_VENDORS', 'allvendors')
     ACTIONS.updateVendor(objToSave)
   },

  render: function(){
    return (
      <form className="form-inline" onSubmit={this._vendorUpdateSubmit}>
         <h1>Update Account</h1>
          <div className="form-group">
            <input type="text" className="form-control" name="inputName" placeholder="Name"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" name="inputOwner" placeholder="Company"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" name="inputHours" placeholder="Hours"/>
          </div>
          <div className="form-group">
            <input type="text" className="form-control" name="inputEmail" placeholder="Email"/>
          </div>
          <div className="form-group">
            <input type="text" className="form-control" name="inputPhone" placeholder="Phone"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" name="inputAddress" placeholder="Address"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" name="inputCity" placeholder="City"/>
          </div>
          <div className="form-group">
            <input type="text" className="form-control" name="inputState" placeholder="ST"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" name="inputZip" placeholder="ZIP"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" name="inputWebsite" placeholder="Website http://"/>
          </div>
          <h2>Beers on Tap</h2>
          <div className="form-group">
              <input type="text" className="form-control" name="inputBeer" placeholder="Beer Name"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" name="inputBrewery" placeholder="Brewery"/>
          </div>
          <div className="form-group">
            <input type="text" className="form-control" name="inputType" placeholder="Type"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" name="inputABV" placeholder="ABV%"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" name="inputImage" placeholder="image URL"/>
          </div>
          <h2>Upcoming Live Music</h2>
          <div className="form-group">
              <input type="text" className="form-control" name="inputBand" placeholder="Band Name"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" name="inputGenre" placeholder="Genre"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" name="inputCover" placeholder="Cover Charge"/>
          </div>
          <div className="form-group">
            <input type="text" className="form-control" name="inputDate" placeholder="Date"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" name="inputTime" placeholder="Time"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" name="inputImage" placeholder="image URL"/>
          </div>
        <hr/>
          <div className="form-group">
              <button type="submit" className="btn submit-button">Update Account</button>
          </div>
      </form>
    )
  }
})
