import React from 'react'
import {ACTIONS} from '../actions.js'

export const CreateVendorComponent = React.createClass({

   _vendorUpdateSubmit: function(evt){
     evt.preventDefault()
     let formEl = evt.target
     let beerToSave = {
       name: formEl.inputBeer.value,
       type: formEl.inputType.value,
       brewery: formEl.inputBrewery.value,
       alcoholContent: formEl.inputABV.value,
       imageURL: formEl.inputBottle.value

     }
     let bandToSave = {
       name: formEl.inputBand.value,
       genre: formEl.inputGenre.value,
       coverCharge: formEl.inputCover.value,
       showtime: formEl.inputShowTime.value,
       imageURL: formEl.inputBandPic.value
     }

     let objToSave = {
         name: formEl.inputName.value,
         ownerName: formEl.inputOwnerName.value,
         address: formEl.inputAddress.value,
         city: formEl.inputCity.value,
         state: formEl.inputState.value,
         zipCode: formEl.inputZip.value,
         vendorURL: formEl.inputWebsite.value,
         imageURL: formEl.inputImage.value,
         vendorPhone: formEl.inputPhone.value,
         hours: formEl.inputHours.value,
         beers: [beerToSave],
         bands: [bandToSave]
     }

    ACTIONS.setNewVendor(objToSave)
    ACTIONS.changeCurrentNav('ALL_VENDORS', 'allvendors')
    console.log(objToSave)
   },

  render: function(){
    return (
        <form className="form-inline" onSubmit={this._vendorUpdateSubmit}>
          <h1 className="account-header">Create Vendor Profile</h1>
          <div className="form-group account-form_inputs">
            <input type="text" className="form-control_large font2" name="inputName" placeholder="Establishment Name"/>
          </div>
          <div className="form-group account-form_inputs">
              <input type="text" className="form-control_large font2" name="inputOwnerName" placeholder="Owner First and Last Names"/>
          </div>

          <div className="form-group account-form_inputs">
              <input type="text" className="form-control_large font2" name="inputAddress" placeholder="Address"/>
          </div>
          <div className="form-group account-form_inputs">
              <input type="text" className="form-control_large font2" name="inputCity" placeholder="City"/>
          </div>
          <div className="form-group account-form_inputs">
            <input type="text" className="form-control_small font2" name="inputState" placeholder="ST"/>
          </div>
          <div className="form-group account-form_inputs">
              <input type="number" className="form-control_small font2" name="inputZip" placeholder="ZIP"/>
          </div>
          <div className="form-group account-form_inputs">
            <input type="text" className="form-control_large font2" name="inputPhone" placeholder="Phone"/>
          </div>

          <div className="form-group account-form_inputs">
            <input type="text" className="form-control_large font2" name="inputEmail" placeholder="Email"/>
          </div>
          <div className="form-group account-form_inputs">
              <input type="text" className="form-control_large font2" name="inputHours" placeholder="Hours"/>
          </div>

          <div className="form-group account-form_inputs">
              <input type="text" className="form-control_large font2" name="inputWebsite" placeholder="Website - http://"/>
          </div>
          <div className="form-group account-form_inputs">
              <input type="text" className="form-control_large font2" name="inputImage" placeholder="Vendor Logo URL"/>
          </div>

          <h1 className="account-header">Beers on Tap</h1>
          <div className="form-group account-form_inputs">
              <input type="text" className="form-control_large font2" name="inputBeer" placeholder="Beer Name"/>
          </div>
          <div className="form-group account-form_inputs">
              <input type="text" className="form-control_large font2" name="inputBrewery" placeholder="Brewery"/>
          </div>

          <div className="form-group account-form_inputs">
            <input type="text" className="form-control_small font2" name="inputType" placeholder="Type"/>
          </div>
          <div className="form-group account-form_inputs">
              <input type="text" className="form-control_small font2" name="inputABV" placeholder="ABV%"/>
          </div>
          <div className="form-group account-form_inputs">
              <input type="text" className="form-control_large font2" name="inputBottle" placeholder="Beer Image URL"/>
          </div>

          <h1 className="account-header">Upcoming Live Music</h1>
          <div className="form-group account-form_inputs">
              <input type="text" className="form-control_large font2" name="inputBand" placeholder="Band Name"/>
          </div>
          <div className="form-group account-form_inputs">
              <input type="text" className="form-control_small font2" name="inputGenre" placeholder="Genre"/>
          </div>
          <div className="form-group account-form_inputs">
              <input type="number" className="form-control_small font2" name="inputCover" placeholder="Cover Charge"/>
          </div>

          <div className="form-group account-form_inputs">
            <input type="text" className="form-control_large font2" name="inputShowTime" placeholder="Showtime"/>
          </div>
          <div className="form-group account-form_inputs">
              <input type="text" className="form-control_large font2" name="inputBandPic" placeholder="Band Image URL"/>
          </div>

          <div className="form-group account-form_inputs">
              <button type="submit" className="btn submit-button">Create Profile</button>
          </div>
        </form>
    )
  }
})
