import Backbone from 'backbone'
import ReactDOM from 'react-dom'
import React from 'react'

import {ViewController} from './view-controller.js'

if(window.location.hostname === 'localhost'){
    let headEl = document.querySelector('head')
    let linkEl = document.querySelector('link[href="./css/styles.css"]')
    headEl.removeChild(linkEl)
}



const AppRouter = Backbone.Router.extend({
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
	},

	showAllVendorsView: function(){
		ReactDOM.render(<ViewController fromRoute={"ALL_VENDORS"}/>, document.querySelector('#app-container'))
	},

	showVendorAccountView: function(){
		ReactDOM.render(<ViewController fromRoute={"VENDOR_ACCOUNT"}/>, document.querySelector('#app-container'))
	},

	showVendorProfileView: function(){
		ReactDOM.render(<ViewController fromRoute={"VENDOR_PROFILE"}/>, document.querySelector('#app-container'))
	},

	showLoginView: function(){
		ReactDOM.render(<ViewController fromRoute={"LOGIN"}/>,
		document.querySelector('#app-container'))
	},

	showRegisterView: function(){
		ReactDOM.render(<ViewController fromRoute={"REGISTER"}/>,
		document.querySelector('#app-container'))
	},

	showHomeView: function(){
		ReactDOM.render(<ViewController fromRoute={"HOME"}/>,
		document.querySelector('#app-container'))
	}

})

new AppRouter()


//
// ReactDOM.render(<SomeComponent/>, document.querySelector('#app-container'))
