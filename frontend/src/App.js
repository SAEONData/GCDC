import React, { Component } from 'react';
import AppContent from './components/AppContent'

import '@saeon/saeon-ux/dist/index.css'
import './App.scss'

class App extends Component {
  render() {
    return (
      <div>
        <AppContent />
      </div>
    );
  }
}

export default App;
