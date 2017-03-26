import React from 'react'
import {ACTIONS} from '../actions.js'

export const BandsComponent = React.createClass({

    _makeBandsList: function(beersList){
      let arrayOfBandsComponents = bandsList.map(function(band, i){
        return (
          <SingleBand bandData={vmod} key={i}/>
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
              <h4 className="media-heading">{this.props.bandData.name}</h4>
              {this.props.bandData.genre}&nbsp;
              {this.props.bandData.showTime}, {this.props.bandData.coverCharge}
            </div>
          </div>

      )
    }
  })
