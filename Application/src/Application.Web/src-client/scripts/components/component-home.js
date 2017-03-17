import React from 'react'

export const HomeComponent = React.createclassName({

  render: function(){

    return (

      <div id="container-fluid">
        <div className="row">
          <div className="col-xs-6">
            <img src="https://files.slack.com/files-pri/T090FQ5AP-F4HPHLVQR/8ccf8be9-d5bd-462b-b0a3-00a3ad73e340.png" className="img-responsive logo"</img>
          </div>
          <div className="col-xs-6">
            <h1 className="">Your Source for Great Beer & Live Music</h1>
          </div>
        </div>

        <div className="container-fluid main-features">
          <div className="row browse_locations">
            <div className="media">
              <div className="media-left">
                <a href="#">
                  <i className="fa fa-map-marker fa-4x" aria-hidden="true"></i>
                </a>
              </div>
              <div className="media-body">
                <h1 className="media-heading"><strong>Browse Locations</strong></h1>
                Check out our map feature to see what bars are in your area.
              </div>
            </div>
          </div>
          <div className="row browse_brews">
            <div className="media feature-container">
              <div className="media-left">
                <a href="#">
                  <i className="fa fa-beer fa-4x" aria-hidden="true"></i>
                </a>
              </div>
              <div className="media-body">
                <h1 className="media-heading"><strong>Browse Brews</strong></h1>
                Craving a hoppy IPA or a nutty brown ale? Check out what type of beers are in your area.
              </div>
            </div>
          </div>
          <div className="row browse_music">
            <div className="media feature-container">
              <div className="media-left">
                <a href="#">
                  <i className="fa fa-music fa-4x" aria-hidden="true"></i>
                </a>
              </div>
              <div className="media-body">
                <h1 className="media-heading"><strong>Browse Live Music</strong></h1>
                Want to listen to some great live music? Check out what type of bands are playing in your area.
              </div>
            </div>
          </div>
        </div>

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
      </div>

    )
  }
})
