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
          {this.props.vendorData.address}&nbsp; {this.props.vendorData.city}, {this.props.vendorData.state} {this.props.vendorData.zipCode}&nbsp;

          <p><a href="">{this.props.vendorData.vendorURL}</a></p>
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
