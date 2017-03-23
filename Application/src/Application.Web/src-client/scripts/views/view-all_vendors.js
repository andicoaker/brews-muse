import React from 'react'

import {MapComponent} from '../components/component-map.js'
import {VendorsListComponent} from '../components/component-list_all_vendors.js'

import {ACTIONS} from '../actions.js'
import {STORE} from '../store.js'

export const AllVendorsView = React.createClass({

  render: function(){
    console.log(this.props.allVendors);
    console.log(this.props.locationsData);
    if(this.props.allVendors.length < 1){
      return(
        <div></div>
      )
    }
    console.log(this.props)

		return (
			<div className="container-fluid">
        <MapComponent locationsData={this.props.allVendors}/>
        <VendorsListComponent allVendors={this.props.allVendors}/>

			</div>
		)
	}
})
