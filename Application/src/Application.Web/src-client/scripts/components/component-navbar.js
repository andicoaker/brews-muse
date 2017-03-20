import React from 'react'

export const NavbarComponent = React.createClass({

  render: function(){

    return (

      <nav className="navbar navbar-default navbar-fixed-bottom">
        <div className="btn-group btn-group-justified" role="group" aria-label="...">
          <div className="btn-group" role="group">
            <button type="button" className="btn btn-default nav-btn">Browse</button>
          </div>
          <div className="btn-group" role="group">
            <button type="button" className="btn btn-default nav-btn">Sign-up</button>
          </div>
          <div className="btn-group" role="group">
            <button type="button" className="btn btn-default nav-btn">Login</button>
          </div>
        </div>
      </nav>

    )
  }
})
