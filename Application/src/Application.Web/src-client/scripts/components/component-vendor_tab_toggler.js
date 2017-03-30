import React from 'react'

export const TabTogglerComponent = React.createClass({

  _handleTabClick: function(evt){
    console.log(evt.currentTarget.dataset.tabname)
    this.props.handleViewChange(evt.currentTarget.dataset.tabname)
  },

  render: function(){
    let tabStyles ={
      beerStyles: "tab tab-active",
      bandStyles: "tab"
    }
    console.log(this.props.selectedTab)
    if(this.props.selectedTab === "bands"){
      tabStyles ={
        beerStyles: "tab",
        bandStyles: "tab tab-active"
      }
    }
    // console.log(this.props)
    return (
      <ul className="nav nav-tabs nav-justified">
        <li role="presentation" data-tabName="beers" className={tabStyles.beerStyles} onClick={this._handleTabClick}>
          {/* <a  name="beers" className="tab-label" >Beers on Tap</a> */}

        <p name="beers">Beers on Tap</p>
        </li>
        <li role="presentation" data-tabName="bands" className={tabStyles.bandStyles} onClick={this._handleTabClick}>
        <p name="bands">Upcoming Live Music</p>
        </li>
      </ul>
    )
  }
})
