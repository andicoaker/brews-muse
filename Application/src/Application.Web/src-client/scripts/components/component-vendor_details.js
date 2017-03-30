import React from 'react'

export const VendorDetailsComponent = React.createClass({
  render: function(){
    // console.log(this.props)
    return (
      <div className="media">
        <div className="media-left">
          <a href="">
            <img className="media-object" src={this.props.currentVendor.imageURL} alt="..."/>
          </a>
        </div>
        <div className="media-body">
          <h1 className="media-heading">{this.props.currentVendor.name}</h1>
          <p className="vendor-address font2">
            {this.props.currentVendor.address}&nbsp;   {this.props.currentVendor.city}, {this.props.currentVendor.state} {this.props.currentVendor.zipCode}
          </p>
          <p className="font2">Phone: {this.props.currentVendor.vendorPhone}</p>
          <p className="font2">Hours: {this.props.currentVendor.hours}</p>
          <p><a className="font2" href="">{this.props.currentVendor.vendorURL}</a></p>

          <p className="social-icons">
            <i className="fa fa-facebook" aria-hidden="true"></i>
            <i className="fa fa-twitter" aria-hidden="true"></i>
            <i className="fa fa-instagram" aria-hidden="true"></i>
          </p>
        </div>
      </div>
    )
  }
})
