import React, { Component } from 'react';
import './App.css';
import Header from './components/Header.js';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import Dashboard from './Dashboard.js';
import './css/bootstrap-grid.css';
import './css/bootstrap.css';
import DoughnutExample from './components/test.js';



class App extends Component {
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
      <Router>
      
        <Header></Header>

        <Route exact={true} path="/dashboard" render={() => (
          <Dashboard></Dashboard>
          
        )} />       
        
        </Router>
      </div>
    );
  }
}

export default App;