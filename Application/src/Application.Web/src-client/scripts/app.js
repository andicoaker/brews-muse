import Backbone from 'backbone'
import ReactDOM from 'react-dom'
import React from 'react'

import {ViewController} from './view-controller.js'


if(window.location.hostname === 'localhost' && window.location.port === '5000'){
    let headEl = document.querySelector('head')
    let linkEl = document.querySelector('link[href="./css/styles.css"]')
    headEl.removeChild(linkEl)
}

ReactDOM.render(<ViewController/>, document.querySelector('#app-container'))
