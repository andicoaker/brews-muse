import React from 'react'

export const HeaderComponent = React.createClass({

  render: function(){

    return (

        <div className="row">
          <div className="col-xs-6">
            <img src="https://files.slack.com/files-pri/T090FQ5AP-F4HPHLVQR/8ccf8be9-d5bd-462b-b0a3-00a3ad73e340.png" className="img-responsive logo"/>
          </div>
          <div className="col-xs-6">
            <h1 className="">Your Source for Great Beer & Live Music</h1>
          </div>
        </div>

    )
  }
})
