import Backbone from 'backbone'

export const VendorProfileModel = Backbone.Model.extend({
	urlRoot: '/api/vendorprofile',
	idAttribute: '_id'
})

export const VendorsCollection = Backbone.Collection.extend({
	model: VendorProfileModel,
	url: '/api/allvendors'
})
