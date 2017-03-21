import Backbone from 'backbone';
import React from 'react'
import ReactDom from 'react-dom'
import {STORE} from './store.js'
import {UserModel} from './models/model-user.js'

export const ACTIONS = {

  setView: function(viewName){
    STORE.setStore('currentView', viewName)
  },

  logUserOut: function(){
    UserModel.logOut().then(function(){
      STORE.setStore('currentUser', {})
    })

  },

  routeTo: function(path){
    window.location.hash = path
  }

}
