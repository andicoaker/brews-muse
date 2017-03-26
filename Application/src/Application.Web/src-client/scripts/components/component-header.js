import React from 'react'

export const HeaderComponent = React.createClass({

  render: function(){

    return (

        <div className="row">
          <div className="col-xs-6">
            <img src="./images/brewsmuse2.png" className="img-responsive logo"/>
          </div>
          <div className="col-xs-6">
            <h1 className="">Your Source for Great Beer & Live Music</h1>
          </div>
        </div>

    )
  }
})
