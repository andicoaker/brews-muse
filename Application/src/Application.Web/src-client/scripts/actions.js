import Backbone from 'backbone';
import $ from 'jquery'
import React from 'react'
import ReactDom from 'react-dom'
import {STORE} from './store.js'
import {UserModel} from './models/model-user.js'
import {VendorProfileModel, VendorsCollection} from './models/model-vendor_profile.js'

export const ACTIONS = {

  setView: function(viewName, routeParamsObj){

    if (typeof routeParamsObj === 'object'){
      STORE.setStore('routeParams', routeParamsObj)

    }

    STORE.setStore('currentView', viewName)
  },

  changeCurrentNav: function(selectedAppRoute, urlRoute){
		STORE.setStore('currentView', selectedAppRoute)
		window.location.hash = urlRoute
	},

  registerNewUser: function(newUserInfoObj){
		UserModel.register(newUserInfoObj).then(function(serverRes){
        ACTIONS.routeTo('allvendors')
		})
	},

  loginUser: function(user, password){
		UserModel.logIn(user, password).then(function(serverRes){
			STORE.setStore('currentUser', serverRes)
              ACTIONS.routeTo('vendoraccount')
		})
	},

  setNewVendor: function(vendorData){
    let vendorInstance = new VendorProfileModel()
      vendorInstance.set(vendorData)
      vendorInstance.save().then(function(s){
        ACTIONS.routeTo('allvendors')
      })
  },

  logUserOut: function(){
    UserModel.logOut().then(function(){
      STORE.setStore('currentUser', {})
    })

  },

  fetchVendors: function(results){
    $.getJSON('/api/vendors').then(function(serverRes){
      STORE.setStore('allVendors', serverRes)
    })
  },

  fetchSingleVendor: function(vendorId){
      let vendorMod = new VendorProfileModel()
      vendorMod.set({id: vendorId})
      vendorMod.fetch().then(function(serverRes){
        STORE.setStore('currentVendor', serverRes)
      })
  },
  //
  // toggleVendorTab: function(){
  //
  //   STORE.setStore(serverRes)
  //   console.log(serverRes);
  //
  // },

  routeTo: function(path){
    window.location.hash = path
  }

}
