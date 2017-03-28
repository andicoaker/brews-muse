import React from 'react'
import {ACTIONS} from '../actions.js'

export const BandsComponent = React.createClass({

    _makeBandsList: function(bandsList){
      let arrayOfBandsComponents = bandsList.map(function(band, i){
        return (
          <SingleBand bandData={band} key={i}/>
        )
      }).reverse()

      return arrayOfBandsComponents
    },

    render: function(){
      console.log("bands list component props: ", this.props)

      return(
        <div>
          {this._makeBandsList(this.props.allBands)}
        </div>
      )
    }
  })

  export const SingleBand = React.createClass({

    render: function(){

      return (

          <div className="media">
            <div className="media-left">
              <a href="">
                <img className="media-object" src={this.props.bandData.imageURL} alt="..."/>
              </a>
            </div>
            <div className="media-body">
              <h1 className="media-heading">{this.props.bandData.name}</h1>
              <p>Show Time: {this.props.bandData.showtime}</p>
              <p>Genre: {this.props.bandData.genre}&nbsp;
               Cover Charge: ${this.props.bandData.coverCharge}</p>
            </div>
          </div>

      )
    }
  })
