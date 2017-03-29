import React from 'react'
import {ACTIONS} from '../actions.js'

export const BeersComponent = React.createClass({

  _makeBeersList: function(beersList){
    let arrayOfBeersComponents = beersList.map(function(beer, i){
      return (
        <SingleBeer beerData={beer} key={i}/>
      )
    }).reverse()

    return arrayOfBeersComponents
  },

  render: function(){
    // console.log("beers list component props: ", this.props)

    return(
      <div>
        {this._makeBeersList(this.props.allBeers)}
      </div>
    )
  }
})

export const SingleBeer = React.createClass({

  render: function(){

    return (

        <div className="media">
          <div className="media-left">
            <a href="">
              <img className="media-object" src={this.props.beerData.imageURL} alt="..."/>
            </a>
          </div>
          <div className="media-body">
            <h2 className="media-heading">{this.props.beerData.name}</h2>
            <p className="font2">Brewery: {this.props.beerData.brewery}</p>
            <p className="font2">Style: {this.props.beerData.type}&nbsp; ABV: {this.props.beerData.alcoholContent}%</p>
          </div>
        </div>

    )
  }
})
