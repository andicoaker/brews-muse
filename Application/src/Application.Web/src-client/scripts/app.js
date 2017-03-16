import Backbone from 'backbone';
import ReactDOM from 'react-dom'
import React from 'react'

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
		'???' : 'showHomeView'
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
