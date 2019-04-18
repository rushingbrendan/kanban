import React, { Component } from 'react';
import '../App.css';
import '../css/Header.css';


class Header extends Component {
  constructor(){
    super();
    this.state = {

    }
  }

  componentWillMount(){

  }



  render() {
    return (
      
<div>
<nav className="navbar navbar-expand-lg navbar-custom">
  <a className="navbar-brand" href="#">Fog Lamp Company</a>
  <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
    <span className="navbar-toggler-icon"></span>
  </button>
  <div className="collapse navbar-collapse" id="navbarNav">
    <ul className="navbar-nav">
      <li className="nav-item active">
        <a className="nav-link" href="/dashboard">Dashboard <span className="sr-only"></span></a>
      </li>
    </ul>
  </div>
</nav>
</div>
    );
  }
}

export default Header;