import React, { Component } from 'react';
import { Layout, Header, Navbar, Sidebar, Footer } from '@saeon/saeon-ux'
import { HashRouter as Router, Switch, Route } from 'react-router-dom'
import Home from './Home';
import Downloads from './Downloads/Downloads';
import Contact from './Contact';

//Config
import headerConfig from '../config/headerConfig'
import navbarConfig from '../config/navbarConfig'
import sidebarConfig from '../config/sidebarConfig'
import footerConfig from '../config/footerConfig'

class AppContent extends Component {

  constructor(props, context) {
    super(props, context);

    this.state = {
      sidebarOpen: false
    }
  }


  render() {

    let { sidebarOpen } = this.state

    let header = <Header config={headerConfig} />
    let navbar = <Navbar config={navbarConfig} toggleSidebar={() => this.setState({ sidebarOpen: true })} />
    let sidebar = (
      <Sidebar
        isOpen={sidebarOpen}
        config={sidebarConfig}
        toggleSidebar={(state) => {
          this.setState({ sidebarOpen: state })
        }}
      />
    )
    let footer = <Footer config={footerConfig} />

    return (
      <Router>

        <Layout
          header={header}
          navbar={navbar}
          sidebar={sidebar}
          footer={footer}
        >
          <Switch >
            <Route path="/" component={Home} exact />
            <Route path="/contact" component={Contact} exact />
            <Route path="/downloads" component={Downloads} exact />
          </Switch>
        </Layout>

      </Router>


    );
  }
}

export default AppContent;