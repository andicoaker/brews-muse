import React from 'react';
import {AppRouter} from './router.js';
import {STORE} from './store.js';
import {ACTIONS} from './actions.js';

import {HeaderComponent} from './components/component-header.js'
import {AnonNavbarComponent, AuthNavbarComponent} from './components/component-navbar.js'

import {HomeView} from './views/view-home.js'
import {AllVendorsView} from './views/view-all_vendors.js'
import {RegisterView} from './views/view-register.js'
import {LoginView} from './views/view-login.js'
import {VendorAccountView} from './views/view-vendor_account.js'
import {VendorProfileView} from './views/view-vendor_profile.js'


export const ViewController = React.createClass({

   getInitialState: function(){

     let storeObject = STORE.getStoreData()
     return storeObject

   },

   componentWillMount: function(){
     let viewContComponent = this

      STORE.onStoreChange(function(){
        let newStoreState = STORE.getStoreData()
        viewContComponent.setState(newStoreState)
      })

      let router = new AppRouter()
      // ACTIONS.fetchloggedInUser()
      // *** add above line in later once user login action is created ***
	 },

  _getNavbar: function(currentUser){
    let theNavbar = <AnonNavbarComponent/>

    if(typeof currentUser.email !== 'undefined'){
     theNavbar = <AuthNavbarComponent/>
    }
    return theNavbar
  },

  _getComponent(currentView){
    return componentToRender
  },

  render: function(){
    let currentView = this.state.currentView
    let componentToRender

    switch(currentView){
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
          componentToRender = <h1 className="">Nothing found!</h1>
  	}

    return (
			<div className="container-fluid">
        <HeaderComponent/>
				{componentToRender}
        {this._getNavbar(this.state.currentUser)}
			</div>
		)

  }
})
