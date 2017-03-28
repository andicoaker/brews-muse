import React from 'react'

export const HeaderComponent = React.createClass({

  render: function(){

    return (

        <div className="row">
          <div className="col-xs-3">
            <img src="../images/beer-icon.jpg" className="img-responsive logo"/>
          </div>
          <div className="col-xs-9">
            <h2 className="">Your Source for Great Beer & Live Music</h2>
          </div>
        </div>

    )
  }
})
