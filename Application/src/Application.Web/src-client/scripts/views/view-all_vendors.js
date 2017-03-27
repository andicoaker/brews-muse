import React from 'react'
import $ from 'jquery';


import {MapComponent} from '../components/component-map.js'
import {AllVendorsComponent} from '../components/component-list_all_vendors.js'

import {ACTIONS} from '../actions.js'
import {STORE} from '../store.js'

export const AllVendorsView = React.createClass({

  componentWillMount: function (){

    ACTIONS.fetchVendors()
  },

  render: function(){
    // console.log(this.props.allVendors);
    if(this.props.allVendors.length < 1){
      return(
        <div></div>
      )
    }
    console.log(this.props)

		return (
			<div className="container-fluid">
        <MapComponent locationsData={this.props.allVendors}/>
        <AllVendorsComponent allVendors={this.props.allVendors}/>

			</div>
		)
	}
})
