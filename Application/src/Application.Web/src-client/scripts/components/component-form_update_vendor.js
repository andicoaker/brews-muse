import React from 'react'

export const UpdateVendorComponent = React.createClass({
  render: function(){
    return (
      <form>
         <h1>Update Account</h1>
          <div className="form-group">
            <input type="text" className="form-control" id="inputFirstName" placeholder="First Name"/>
          </div>
          <div className="form-group">
            <input type="text" className="form-control" id="inputLastName" placeholder="Last Name"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" id="inputCompany" placeholder="Company"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" id="inputHours" placeholder="Hours"/>
          </div>
          <div className="form-group">
            <input type="text" className="form-control" id="inputEmail" placeholder="Email"/>
          </div>
          <div className="form-group">
            <input type="text" className="form-control" id="inputPhone" placeholder="Phone"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" id="inputAddress" placeholder="Address"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" id="inputCity" placeholder="City"/>
          </div>
          <div className="form-group">
            <input type="text" className="form-control" id="inputState" placeholder="ST"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" id="inputZip" placeholder="ZIP"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" id="inputWebsite" placeholder="Website http://"/>
          </div>
          <h2>Beers on Tap</h2>
          <div className="form-group">
              <input type="text" className="form-control" id="inputBeer" placeholder="Beer Name"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" id="inputBrewery" placeholder="Brewery"/>
          </div>
          <div className="form-group">
            <input type="text" className="form-control" id="inputType" placeholder="Type"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" id="inputABV" placeholder="ABV%"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" id="inputImage" placeholder="image URL"/>
          </div>
          <h2>Upcoming Live Music</h2>
          <div className="form-group">
              <input type="text" className="form-control" id="inputBand" placeholder="Band Name"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" id="inputGenre" placeholder="Genre"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" id="inputCover" placeholder="Cover Charge"/>
          </div>
          <div className="form-group">
            <input type="text" className="form-control" id="inputDate" placeholder="Date"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" id="inputTime" placeholder="Time"/>
          </div>
          <div className="form-group">
              <input type="text" className="form-control" id="inputImage" placeholder="image URL"/>
          </div>
          <div className="form-group">
              <button type="submit" className="btn btn-default">Update Account</button>
          </div>
      </form>
    )
  }
})
