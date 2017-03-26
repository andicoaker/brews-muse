import React from 'react'

export const VendorDetailsComponent = React.createClass({
  render: function(){
    return (

      <div className="media">
        <div className="media-left">
          <a href="">
            <img className="media-object" src={this.props.vendorData.imageURL} alt="..."/>
          </a>
        </div>
        <div className="media-body">
          <h4 className="media-heading">{this.props.vendorData.name}</h4>
          <p className="vendor-address">
            {this.props.vendorData.address}&nbsp; {this.props.vendorData.city}, {this.props.vendorData.state} {this.props.vendorData.zipCode}&nbsp;
          </p>

          <p><a href="">{this.props.vendorData.vendorURL}</a></p>
          <p>{this.props.vendorData.phone} {this.props.vendorData.hours}</p>

          <p className="social-icons">
            <i className="fa fa-facebook" aria-hidden="true"></i>
            <i className="fa fa-twitter" aria-hidden="true"></i>
            <i className="fa fa-instagram" aria-hidden="true"></i>
          </p>

        </div>
      </div>


      // <div className="row">
      //     <div className="thumbnail">
      //       <img src="..." alt="..."/>
      //       <div className="caption">
      //         <h3>Thumbnail label</h3>
      //         <p>...</p>
      //       </div>
      //     </div>
      // </div>

    )
  }
})
