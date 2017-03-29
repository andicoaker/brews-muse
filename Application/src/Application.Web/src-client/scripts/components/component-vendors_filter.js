import React from 'react'

export const VendorsFilterComponent = React.createClass({

  render: function(){

    return (

      <div className="container-fluid vendors-filter">
        <row className="vendors-filter">
          <div className="btn-group btn-group_filter pull-right">
            <button type="button" className="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
              Filter <span className="caret"></span>
            </button>

          </div>
        </row>
      </div>

    )
  }
})

{/* <ul className="dropdown-menu">
  <li><a href="#">Action</a></li>
  <li><a href="#">Another action</a></li>
  <li><a href="#">Something else here</a></li>
  <li role="separator" className="divider"></li>
  <li><a href="#">Separated link</a></li>
</ul> */}
