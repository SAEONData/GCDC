import React, { Component } from 'react';

class DownloadItem extends Component {
  render() {

    let { text, link, name } = this.props

    return (
      <div>
        <a href={"data:text/plain;charset=utf-8," + encodeURIComponent(link)} download={name}>
          {text}
        </a>        
      </div>
    );
  }
}

export default DownloadItem;