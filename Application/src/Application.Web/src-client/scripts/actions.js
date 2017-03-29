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
			ACTIONS.changeCurrentNav('ALL_VENDORS', 'allvendors')
		})
	},

  loginUser: function(user, password){
		UserModel.logIn(user, password).then(function(serverRes){
			STORE.setStore('currentUser', serverRes)
			ACTIONS.changeCurrentNav('VENDOR_ACCOUNT', 'vendoraccount')
		})
	},

  setNewVendor: function(vendorData){
    console.log("help me")
  //   $.getJSON('/api/vendors/').then(function(serverRes){
  //     ACTIONS.fetchSingleVendor(serverRes)
  //     STORE.setStore('allVendors', serverRes)
  //  })
    let vendorInstance = new VendorsCollection()
      //vendorInstance.set(vendorData)
      vendorInstance.create(vendorData).then(function(s){
        console.log(s)
      })


  },

  logUserOut: function(){
    UserModel.logOut().then(function(){
      STORE.setStore('currentUser', {})
    })

  },

  fetchVendors: function(results){
    // console.log(results, 'action results')
    $.getJSON('/api/vendors').then(function(serverRes){
      console.log("JSON data results:", serverRes);
      STORE.setStore('allVendors', serverRes)
      console.log(JSON.stringify(serverRes[0]), 'asdlfa;sdl')

    })
  },

  fetchSingleVendor: function(vendorId){
      let vendorMod = new VendorProfileModel()
      vendorMod.set({id: vendorId})
      vendorMod.fetch().then(function(serverRes){
        STORE.setStore('currentVendor', serverRes)
        console.log(serverRes);

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
