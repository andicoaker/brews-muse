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
         <h1>Create Vendor Profile</h1>
          <div className="form-group">
            <input type="text" className="form-control" name="inputName" placeholder="Establishment Name"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" name="inputOwnerName" placeholder="Owner First and Last Names"/>
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
              <input type="number" className="form-control" name="inputZip" placeholder="ZIP"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" name="inputWebsite" placeholder="Website http://"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" name="inputImage" placeholder="image URL"/>
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
              <input type="text" className="form-control" name="inputBottle" placeholder="Beer Image URL"/>
          </div>

          <h2>Upcoming Live Music</h2>
          <div className="form-group">
              <input type="text" className="form-control" name="inputBand" placeholder="Band Name"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" name="inputGenre" placeholder="Genre"/>
          </div>
          <div className="form-group">
              <input type="number" className="form-control" name="inputCover" placeholder="Cover Charge"/>
          </div>
          <div className="form-group">
            <input type="text" className="form-control" name="inputShowTime" placeholder="Showtime"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" name="inputBandPic" placeholder="Band Image URL"/>
          </div>
        <hr/>
          <div className="form-group">
              <button type="submit" className="btn submit-button">Create Profile</button>
          </div>
      </form>
    )
  }
})
