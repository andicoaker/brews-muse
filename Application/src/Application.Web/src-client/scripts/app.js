import Backbone from 'backbone';
import ReactDOM from 'react-dom'
import React from 'react'

 const AppRouter = Backbone.Router.extend({
 	initialize: function(){
 		Backbone.history.start()
 	},

 	***** ASK if routes below are set-up correctly *****

 	routes: {
 		'api/???' : 'showAllVendorsView',
 		'api/???' : 'showVendorAccountView',
 		'/api/???' : 'showVendorProfileView',
 		'/api/accounts/login' : 'showLoginView',
 		'/api/accounts/register' : 'showRegisterView',
 		'???' : 'showHomeView'
 	},

 	showAllVendorsView: function(){
 		ReactDOM.render(<h1>All Vendors - List/Map</h1>, document.querySelector('#app-container'))
 	},

 	showVendorAccountView: function(){
 		ReactDOM.render(<h1>Vendor Account</h1>, document.querySelector('#app-container'))
 	},

 	showVendorProfileView: function(){
 		ReactDOM.render(<h1>Vendor Profile Page</h1>, document.querySelector('#app-container'))
 	},

 	showLoginView: function(){
 		ReactDOM.render(<h1>Login</h1>, document.querySelector('#app-container'))
 	},

 	showRegisterView: function(){
 		ReactDOM.render(<h1>Register</h1>, document.querySelector('#app-container'))
 	},

 	showHomeView: function(){
 		ReactDOM.render(<h1>Welcome</h1>, document.querySelector('#app-container'))
 	},

 })

 new AppRouter()


const SomeComponent = React.createClass({
	render: function(){
		return (
			<div>
				<h1>Whoaohowhoa</h1>
				<p><small>
					you make my hair so soft and i know you will never make me cry.
				</small></p>
			</div>
		)
	}
})

ReactDOM.render(<SomeComponent/>, document.querySelector('#app-container'))
