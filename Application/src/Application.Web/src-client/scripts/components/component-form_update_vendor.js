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
          <div className="form-group">
              <button type="submit" className="btn btn-default">Login</button>
          </div>
      </form>
    )
  }
})
