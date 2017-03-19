import Backbone from 'backbone'
import {ACTIONS} from './actions.js'


  // formerly in the app.js file

export const AppRouter = Backbone.Router.extend({
	initialize: function(){
		Backbone.history.start()
	},

	routes: {
		'allvendors' : 'showAllVendorsView',
		'vendoraccount' : 'showVendorAccountView',
		'vendorprofile' : 'showVendorProfileView',
		'login' : 'showLoginView',
		'register' : 'showRegisterView',
		'' : 'showHomeView'
    '*nomatch' : 'show404'
	},

  showAllVendorsView: function(){
	  ACTIONS.setView("ALL_VENDORS")
  },

  showVendorAccountView: function(){
    ACTIONS.setView("VENDOR_ACCOUNT")
  },

  showVendorProfileView: function(){
    ACTIONS.setView("VENDOR_PROFILE")
  },

  showLoginView: function(){
    ACTIONS.setView("LOGIN")
  },

  showRegisterView: function(){
    ACTIONS.setView("REGISTER")
  },

  showHomeView: function(){
    ACTIONS.setView("HOME")
  },

  show404: function(){
    ACTIONS.setView("LOGIN")
  }

})
