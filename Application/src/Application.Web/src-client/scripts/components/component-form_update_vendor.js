import React from 'react'

export const UpdateVendorComponent = React.createClass({
  render: function(){
    return (
      <form>
        <div className="form-group">
          <label className="control-label col-sm-2" for="email">Email:</label>
          <div className="col-sm-10">
            <input type="email" className="form-control" id="email" placeholder="Enter email"/>
          </div>
        </div>
      </form>
    )
  }
})
