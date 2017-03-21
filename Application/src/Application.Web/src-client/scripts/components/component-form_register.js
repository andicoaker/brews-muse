import React from 'react'

export const RegisterComponent = React.createClass({


  render: function(){
    return (
    <form>
       <h1>Register</h1>
        <div className="form-group">
          <label htmlFor="exampleInputEmail1">Email:</label>
          <input type="email" className="form-control" id="exampleInputEmail1" placeholder="Enter email"/>
        </div>
        <div className="form-group">
          <label htmlFor="exampleInputPassword1">Password:</label>
          <input type="email" className="form-control" id="exampleInputPassword1" placeholder="Enter password"/>
        </div>
        <div className="form-group">
            <label htmlFor="exampleInputPassword1">Password:</label>
            <input type="email" className="form-control" id="exampleInputPassword1" placeholder="Enter password"/>
        </div><div className="form-group">
            <label htmlFor="exampleInputPasswordConfirm1">Confirm password:</label>
            <input type="email" className="form-control" id="exampleInputPasswordConfirm1" placeholder="Confirm password"/>
        </div>
        <div className="form-group">
            <div className="checkbox">
              <label><input type="checkbox"/> Are you a vendor?</label>
            </div>
        </div>
        <div className="form-group">
            <button type="submit" className="btn btn-default">Login</button>
        </div>
    </form>
    )
  }
})
