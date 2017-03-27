import Backbone from 'backbone'

export const VendorProfileModel = Backbone.Model.extend({
	urlRoot: '/api/vendors',
	idAttribute: 'id'
})

export const VendorsCollection = Backbone.Collection.extend({
	model: VendorProfileModel,
	url: '/api/vendors'
})
