import React from 'react'

export const VendorDetailsComponent = React.createClass({
  render: function(){
    console.log(this.props)
    return (

      <div className="media">
        <div className="media-left">
          <a href="">
            <img className="media-object" src={this.props.currentVendor.imageURL} alt="..."/>
          </a>
        </div>
        <div className="media-body">
          <h4 className="media-heading">{this.props.currentVendor.name}</h4>
          <p className="vendor-address">
            {this.props.currentVendor.address}&nbsp; {this.props.currentVendor.city}, {this.props.currentVendor.state} {this.props.currentVendor.zipCode}&nbsp;
          </p>

          <p><a href="">{this.props.currentVendor.vendorURL}</a></p>
          <p>{this.props.currentVendor.vendorPhone} {this.props.currentVendor.hours}</p>

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
