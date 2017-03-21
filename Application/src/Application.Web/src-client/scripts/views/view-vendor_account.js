import React from 'react'
import {UpdateVendorComponent} from '../components/component-form_update_vendor.js'

import {ACTIONS} from '../actions.js'
import {STORE} from '../store.js'

export const VendorAccountView = React.createClass({

  render: function(){
    return (
      <div className="vendor-container">
        <UpdateVendorComponent/>
      </div>
    )
  }
})
