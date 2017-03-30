import React from 'react'
import {ACTIONS} from '../actions.js'

export const HomeComponent = React.createClass({

  render: function(){

    return (
      <div className="container-fluid">
        <div className="jumbotron text-center">
          <div className="splash_text">
            <h1>BrewsMuse</h1>
            <p>Your Source for Great Beer and Live Music</p>
          </div>
        </div>

        <div className="container-fluid main-features">
          <div className="row browse_locations">
            <div className="media">
              <div className="media-left">
                <a href="#allvendors">
                  <i className="fa fa-map-marker fa-4x map-pin-home" aria-hidden="true"></i>
                </a>
              </div>
              <div className="media-body">
                <h1 className="media-heading">Browse Locations</h1>
                <p className="font2">Check out our map feature to see what nearby bars offer your fav draft beers and live music.</p>
              </div>
            </div>
          </div>
          <div className="row browse_brews">
            <div className="media feature-container">
              <div className="media-left">
                <a href="#allvendors">
                  <i className="fa fa-beer fa-4x" aria-hidden="true"></i>
                </a>
              </div>
              <div className="media-body">
                <h1 className="media-heading">Browse Brews</h1>
                <p className="font2">Craving a hoppy IPA or a nutty brown ale? Check out beers on tap in your area.</p>
              </div>
            </div>
          </div>
          <div className="row browse_music">
            <div className="media feature-container">
              <div className="media-left">
                <a href="#allvendors">
                  <i className="fa fa-music fa-4x" aria-hidden="true"></i>
                </a>
              </div>
              <div className="media-body">
                <h1 className="media-heading"><strong>Browse Live Music</strong></h1>
                <p className="font2">Want to listen to some great live music? Check out bands playing in your area.</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    )
  }
})
