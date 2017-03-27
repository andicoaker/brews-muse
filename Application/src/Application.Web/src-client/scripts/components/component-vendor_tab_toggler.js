import React from 'react'

export const TabTogglerComponent = React.createClass({

  _handleTabClick: function(evt){
    ACTIONS.toggleVendorTab()

  },

  render: function(){
    console.log(this.props)
    return (

      <ul className="nav nav-tabs nav-justified">
        <li role="presentation" className="active" onClick={this._handleTabClick}><a href="#">Beers on Tap</a></li>
        <li role="presentation" className=" " onClick={this_handleTabClick}><a href="#">Upcoming Live Music</a></li>
      </ul>

    )
  }
})
