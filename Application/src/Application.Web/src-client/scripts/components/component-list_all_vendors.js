import React from 'react'
import {ACTIONS} from '../actions.js'

export const VendorsListComponent = React.createClass({

  _makeVendorComponents: function(vendorsList){
    let arrayOfVendorsComponents = vendorsList.map(function(vmod, i){
      return (
        <VendorsListItem vendorData={vmod} key={i}/>
      )
    }).reverse()

    return arrayOfVendorsComponents
  },

  render: function(){
    console.log("vendors list component props: ", this.props)

    return(
      <div>
        {this._makeVendorComponents(this.props.allVendors)}
      </div>
    )
  }
})

export const VendorsListItem = React.createClass({

  render: function(){

    return (

        <div className="media">
          <div className="media-left">
            <a href="#vendorprofile">
              <img className="media-object" src={this.props.vendorData.imageURL} alt="..."/>
            </a>
          </div>
          <div className="media-body">
            <h4 className="media-heading">{this.props.vendorData.name}</h4>
            {this.props.vendorData.address}&nbsp; {this.props.vendorData.city}, {this.props.vendorData.state} {this.props.vendorData.zipCode}&nbsp;

            <p><a href="">{this.props.vendorData.vendorURL}</a></p>
          </div>
        </div>

    )
  }
})
