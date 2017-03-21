import React from 'react'

import {MapComponent} from '../components/component-map.js'
import {AllVendorsListComponent} from '../components/component-list_all_vendors.js'

import {ACTIONS} from '../actions.js'
import {STORE} from '../store.js'

export const AllVendorsView = React.createClass({

  render: function(){

		return (
			<div className="container-fluid">
          <MapComponent/>
          <AllVendorsListComponent/>
			</div>
		)
	}
})
