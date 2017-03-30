import React from 'react'

export const HeaderComponent = React.createClass({

  render: function(){

    return (

        <div className="row header-container">
          <div className="col-xs-2">
            <img src="https://image.flaticon.com/icons/svg/121/121901.svg" className="img-responsive logo"/>
          </div>
          <div className="col-xs-10">
            <h1 className="BrewsMuse">BrewsMuse</h1>
          </div>

        </div>
    )
  }
})
//
// <div className="col-xs-2">
//   <i className="fa fa-cog fa-3x float-right" aria-hidden="true"></i>
// </div>

{/* <div className='col-xs-2'>
  <i className="fa fa-bars fa-2x" aria-hidden="true"></i>
</div> */}

      {/* // <h3 className="">Your Source for Great Beer & Live Music</h3> */}
