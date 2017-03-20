import React from 'react'

export const RegisterComponent = React.createClass({

  render: function(){
    return (
    <form>
      <div className="form-group">
        <label className="control-label col-sm-2" for="email">Email:</label>
        <div className="col-sm-10">
          <input type="email" className="form-control" id="email" placeholder="Enter email"/>
        </div>
      </div>
      <div className="form-group">
        <label className="control-label col-sm-2" for="pwd">Password:</label>
        <div className="col-sm-10">
          <input type="password" className="form-control" id="pwd" placeholder="Enter password"/>
        </div>
      </div>
      <div className="form-group">
        <label className="control-label col-sm-2" for="pwd">Confirm Password:</label>
        <div className="col-sm-10">
          <input type="password" className="form-control" id="pwd" placeholder="Confirm password"/>
        </div>
      </div>
      <div className="form-group">
        <div className="col-sm-offset-2 col-sm-10">
          <div className="checkbox">
            <label><input type="checkbox"/> Are you a vendor?</label>
          </div>
        </div>
      </div>
      <div className="form-group">
        <div className="col-sm-offset-2 col-sm-10">
          <button type="submit" className="btn btn-default">Create Account</button>
        </div>
      </div>
    </form>
    )
  }
})
