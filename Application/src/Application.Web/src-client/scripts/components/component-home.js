import React from 'react'

export const HomeComponent = React.createClass({

  render: function(){

    return (

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
                Check out our map feature to see what nearby bars offer your fav draft beers and live music.
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
                Craving a hoppy IPA or a nutty brown ale? Check out beers on tap in your area.
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
                Want to listen to some great live music? Check out bands playing in your area.
              </div>
            </div>
          </div>
        </div>

    )
  }
})
