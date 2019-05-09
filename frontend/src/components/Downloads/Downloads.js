import React, { Component } from 'react';
import DownloadItem from './DownloadItem';

import testData from '../../data/test-data.txt'

class Downloads extends Component {
  render() {
    return (
      <div>
        <h1>Downloads</h1>
        <DownloadItem text="Test Download 1" link={testData} name="test-data.txt" />
        <DownloadItem text="Test Download 2" link={testData} name="test-data.txt" />
        <DownloadItem text="Test Download 3" link={testData} name="test-data.txt" />
        <br/>
      </div>
    );
  }
}

export default Downloads;