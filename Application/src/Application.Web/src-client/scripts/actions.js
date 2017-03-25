import Backbone from 'backbone';
import React from 'react'
import ReactDom from 'react-dom'
import {STORE} from './store.js'
import {UserModel} from './models/model-user.js'

export const ACTIONS = {

  setView: function(viewName){
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

  logUserOut: function(){
    UserModel.logOut().then(function(){
      STORE.setStore('currentUser', {})
    })

  },

  setAPIData: function(results){
    // console.log(results, 'action results')
    STORE.setStore('allVendors', results)
  },

  routeTo: function(path){
    window.location.hash = path
  }

}
