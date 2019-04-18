import React, { Component } from 'react';
import axios from 'axios';

import './App.css';
import ChartData from './components/ChartData.js';
import Chart from './components/chart.js';



class Dashboard extends Component {
  constructor(){
    super();
    this.state = {
      data: null,
      chartData:{},
      fogLampsOrdered: 120000,
      fogLampsPending: 500000,
      fogLampsCompleted: 48000,
      defectedFogLamps: 150,
      ordersCompleted: 50,
      fogLampCount: 0,
      rawData: [],   
      updateGraph: false,



    }
  }

  componentWillMount(){
    this.getChartData();



  }

  componentDidMount() {

    // fetch('https://secure.toronto.ca/cc_sr_v1/data/swm_waste_wizard_APR?limit=1000')
    // //fetch('/users/foglamps')
    
    // //Complete promise to receive body text as JSON object
    // .then(res => res.json())

    // //Add JSON object to rawData array in state
    // .then(rawData => this.setState({rawData}));




};


componentDidUpdate() {
  if (this.state.updateGraph === true){
   this.setState({
     updateGraph: false
   });

    // Create a new array based on current state:
    //var currentCompletedGraph = [...this.state.chartData.datasets[0].data];

    // Add item to it
    //currentCompletedGraph.push(this.state.rawData.fogLampCount);

    //this.setState({currentCompletedGraph});
if ((this.state.fogLampCount !== 0) && (this.state.fogLampCount !== undefined)) {
    //this.state.chartData.datasets[0].data.push(this.state.rawData.fogLampCount);
    alert(this.state.fogLampCount);
   
    let datacopy = Object.assign({}, this.state.chartData)
    //datacopy.datasets[0].data[0] = datacopy.datasets[0].data[0] + this.currentFogLampCount;
    datacopy.datasets[0].data.push(this.state.fogLampCount);
    //datacopy.datasets[0].labels.push(this.state.fogLampCount);
    
    //alert(this.currentFogLampCount);
    //console.log(datacopy.datasets[0].data)
    this.setState({chartData: datacopy})

}



  }
}


  refreshData(){
    //alert("here");


    axios.get(`http://localhost:3001/users/foglamps`)
    .then(res => {
      const persons = res.data;
      this.setState({ rawData: persons });
      this.setState({fogLampCount: this.state.rawData.fogLampCount});        

      //alert(this.state.rawData.fogLampCount);
      
      //this.state.chartData.datasets[0].data.push(this.state.rawData.fogLampCount);
    })

    this.setState({      
      updateGraph: true

    });  

    //alert(this.state.chartData.datasets[1].data);

    



  }



  getChartData(){
    // Ajax calls here

    this.setState({
      chartData:{
        labels: ['0',],
        datasets:[
          {
            label:'Fog Lamps Completed',
            data: [0,],
            backgroundColor:[
              //'#FFE710',
              'rgba(71, 203, 67, 1)',

            ]
          },
          
        ]
      }
    });
  }



  render() {
    return (
          <div className="container">
          <br></br>
          <h1>Dashboard</h1>
            <h3>{Date()}</h3>
          <br></br>
          <div className="form-row">
            <div className="col-3">
                <div className="card border-left-primary shadow h-100 py-2">
                    <div className="card-body">
                        <div className="row no-gutters align-items-center">
                            <div className="col mr-2">
                                <div className="text-xs font-weight-bold text-primary text-uppercase mb-1">Fog Lamps Ordered</div>
                                <div className="h5 mb-0 font-weight-bold text-gray-800">{this.state.fogLampsOrdered}</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className="col-3">
                <div className="card border-left-primary shadow h-100 py-2">
                    <div className="card-body">
                        <div className="row no-gutters align-items-center">
                            <div className="col mr-2">
                                <div className="text-xs font-weight-bold text-primary text-uppercase mb-1">Fog Lamps Completed</div>
                                <div className="h5 mb-0 font-weight-bold text-gray-800">{this.state.fogLampCount}</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className="col-3">
                <div className="card border-left-primary shadow h-100 py-2">
                    <div className="card-body">
                        <div className="row no-gutters align-items-center">
                            <div className="col mr-2">
                                <div className="text-xs font-weight-bold text-primary text-uppercase mb-1">Fog Lamps Pending</div>
                                <div className="h5 mb-0 font-weight-bold text-gray-800">{this.state.fogLampsPending}</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className="col-3">
                <div className="card border-left-primary shadow h-100 py-2">
                    <div className="card-body">
                        <div className="row no-gutters align-items-center">
                            <div className="col mr-2">
                                <div className="text-xs font-weight-bold text-danger text-uppercase mb-1">Defective Fog Lamps</div>
                                <div className="h5 mb-0 font-weight-bold text-gray-800">{this.state.defectedFogLamps}</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <button className="btn btn-primary" onClick={(e) => this.refreshData()}>Refresh</button>
        <br></br>
        <div className="form-row">
          <div className="col-12">
            <Chart key={this.state.fogLampCount} chartData={this.state.chartData} chartTitle="Fog Lamps Built" legendPosition="bottom"  redraw={true}/>
          </div>        
        </div>
            <div className="form-row">          
              <div className="col-6">
              <Chart chartData={this.state.chartData} chartTitle="Workstation #1" legendPosition="bottom"/>
              </div>
              <div className="col-6">
              <Chart chartData={this.state.chartData} chartTitle="Workstation #2" legendPosition="bottom"/>
              </div>                 
            </div>          
            <div className="form-row">          
              <div className="col-6">
              <Chart chartData={this.state.chartData} chartTitle="Workstation #3" legendPosition="bottom"/>
              </div>
              <div className="col-6">
              <Chart chartData={this.state.chartData} chartTitle="Workstation #4" legendPosition="bottom"/>
              </div>                 
            </div>

            
  <table className="table table-sm">
  <thead>
    <tr>
      <th scope="col">Order ID</th>
      <th scope="col">Order Amount</th>
      <th scope="col">Amount Completed</th>
      <th scope="col">Completed</th>
    </tr>
  </thead>
  <tbody>

  </tbody>  
</table>

          </div>          
        );
    }
       
}

export default Dashboard;