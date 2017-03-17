import React from 'react';
import {Navbar} from './components/component-navbar.js';
import {STORE} from './store.js';
import {ACTIONS} from './actions.js';

import {HomeView} from './views/view-home.js'
import {AllVendorsView} from './views/view-all_vendors.js'
import {RegisterView} from './views/view-register.js'
import {LoginView} from './views/view-login.js'
import {VendorAccountView} from './views/view-vendor_account.js'
import {VendorProfileView} from './views/view-vendor_profile.js'

export const ViewController = React.createClass({

   getInitialState: function(){
     ACTIONS.changeCurrentNav(this.props.fromRoute, window.location.hash)
     let storeObject = STORE.getStoreData()
     return storeObject
   },

   componentDidMount: function(){
	 	let component = this;

	    STORE.onStoreChange(function(){
	 		console.log("YAY CHANGED STATE!")

	 		let newStoreObj = STORE.getStoreData()
	 		component.setState(newStoreObj)
	 	})
	 	ACTIONS.fetchCurrentUser()
	 },

  render: function(){

    let componentToRender

    switch(this.state.currentNavRoute){
  			case "LOGIN":
  				componentToRender = <LoginView {...this.state}/>
  				break;
  			case "REGISTER":
  				componentToRender = <RegisterView {...this.state}/>
  				break;
   			case "ALL_VENDORS":
  				componentToRender = <AllVendorsView {...this.state}/>
  				break;
        case "VENDOR_ACCOUNT":
  				componentToRender = <VendorAccountView {...this.state}/>
  				break;
        case "VENDOR_PROFILE":
  				componentToRender = <VendorProfileView {...this.state}/>
  				break;
        case "HOME":
  				componentToRender = <HomeView {...this.state}/>
  				break;
   			default:
  	}

    return (
			<div>

				{componentToRender}
			</div>
		)

  }
})
