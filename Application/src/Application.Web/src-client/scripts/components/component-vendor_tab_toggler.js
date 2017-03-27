import React from 'react'

export const TabTogglerComponent = React.createClass({

  // _handleTabClick: function(){
  //
  //
  //
  // },

  render: function(){
    console.log(this.props)
    return (

      <ul className="nav nav-tabs nav-justified">
        <li role="presentation" className="active" ><a href="#">Beers on Tap</a></li>
        <li role="presentation" ><a href="#">Upcoming Live Music</a></li>
      </ul>

    )
  }
})
