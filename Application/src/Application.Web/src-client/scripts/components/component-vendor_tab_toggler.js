import React from 'react'

export const TabTogglerComponent = React.createClass({

  _handleTabClick: function(evt){
    console.log('adsfasdf', evt.target.name, 'event target nammee')
    this.props.handleViewChange(evt.target.name)
  },

  render: function(){
    console.log(this.props)
    return (

      <ul className="nav nav-tabs nav-justified">
        <li role="presentation" name="beers" className="tab active" onClick={this._handleTabClick}>
          <a  name="beers" className="tab-label" >Beers on Tap</a>
        </li>
        <li role="presentation" name="bands" className="tab" onClick={this._handleTabClick}>
          <a  name="bands" className="tab-label" >Upcoming Live Music</a>
        </li>
      </ul>

    )
  }
})
