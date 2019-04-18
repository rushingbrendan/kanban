import React, { Component } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router';


import './App.css';
import ChartData from './components/ChartData.js';
import Chart from './components/chart.js';
import { library } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTimes } from '@fortawesome/free-solid-svg-icons';
import { faCheckCircle} from '@fortawesome/free-solid-svg-icons';

library.add(faTimes);
library.add(faCheckCircle);



class Dashboard extends Component {
  constructor(){
    super();
    this.state = {
      fogLampHistory: [],
      chartData:{},
      fogLampsOrdered: 0,
      fogLampsPending: 0,
      fogLampsCompleted: 0,
      defectiveFogLamps: 0,
      goodFogLamps: 0,
      ordersCompleted: 0,
      fogLampCount: 0,
      fogLampsRequired: 0,
      yield: 0,
      rawData: [],  
      orderInfo: [],
      rawDataFail: [],   
      updateGraph: false,
      updateGraphDefect: false,
      renderGraph: false,
      ordersReceived: false,
      timerCount: 0,
      redirect: false,



    }


  }


  componentWillMount(){
    //this.getChartData();



  }


  updateOrders(){

    axios.get(`http://localhost:3001/users/getorders`)
    .then(res => {
      const persons = res.data;
      this.setState({ orderInfo: persons.fogLampCount }); 
      this.setState({ ordersReceived: true }); 
            
    })
  }

  updateGraph(){

    axios.get(`http://localhost:3001/users/builtfoglamps`)
    .then(res => {
      const persons = res.data;
      this.setState({ rawData: persons });          
    })   
  }



  componentDidMount() {

  this.updateGraph();

  this.timer = setInterval(
    () => this.increment(),
    5000
  )

}

componentWillUnmount() {
  clearInterval(this.timer);


}

increment() {
  this.updateChartData();

  var currentCount = this.state.timerCount;
  currentCount += 1;

  this.setState({
    timerCount: currentCount
  })


  if (currentCount === 10){

    this.setState({
      renderGraph: false
    })

    this.setState({
      renderGraph: true,
      timerCount: 0
    })


  }

  
}


componentDidUpdate() {
}

updateOrderVariables(){
  var fogLampsOrdered = 0;
  var fogLampsRequired = 0;  
  
  for (var i = 0; i < this.state.orderInfo[0].length; i++){

    fogLampsOrdered += this.state.orderInfo[0][i].quantity;
    fogLampsRequired += this.state.orderInfo[0][i].quantityBuilt;
    
  }

  fogLampsRequired = fogLampsOrdered - fogLampsRequired;

  this.setState({
    fogLampsRequired: fogLampsRequired,
    fogLampsOrdered: fogLampsOrdered
  })

  

}

refreshData(){
  
  this.updateChartData();
}

  updateChartData(){

    

  let currentData = [];
  let defectData = [];
  let currentLabels = [];

  var fogLampGoodCount = 0;
  var fogLampBadCount = 0;
  var currentYield = 0;


    try{

    currentData[0] = this.state.rawData.fogLampCount[0][0].fogLampCount12;
    currentData[1] = this.state.rawData.fogLampCount[1][0].fogLampCount11;
    currentData[2] = this.state.rawData.fogLampCount[2][0].fogLampCount10;
    currentData[3] = this.state.rawData.fogLampCount[3][0].fogLampCount9;
    currentData[4] = this.state.rawData.fogLampCount[4][0].fogLampCount8;
    currentData[5] = this.state.rawData.fogLampCount[5][0].fogLampCount7;
    currentData[6] = this.state.rawData.fogLampCount[6][0].fogLampCount6;
    currentData[7] = this.state.rawData.fogLampCount[7][0].fogLampCount5;
    currentData[8] = this.state.rawData.fogLampCount[8][0].fogLampCount4;
    currentData[9] = this.state.rawData.fogLampCount[9][0].fogLampCount3;
    currentData[10] = this.state.rawData.fogLampCount[10][0].fogLampCount2;
    currentData[11] = this.state.rawData.fogLampCount[11][0].fogLampCount1;
    

    defectData[0] = this.state.rawData.fogLampCount[12][0].fogLampBad12;
    defectData[1] = this.state.rawData.fogLampCount[13][0].fogLampBad11;
    defectData[2] = this.state.rawData.fogLampCount[14][0].fogLampBad10;
    defectData[3] = this.state.rawData.fogLampCount[15][0].fogLampBad9;
    defectData[4] = this.state.rawData.fogLampCount[16][0].fogLampBad8;
    defectData[5] = this.state.rawData.fogLampCount[17][0].fogLampBad7;
    defectData[6] = this.state.rawData.fogLampCount[18][0].fogLampBad6;
    defectData[7] = this.state.rawData.fogLampCount[19][0].fogLampBad5;
    defectData[8] = this.state.rawData.fogLampCount[20][0].fogLampBad4;
    defectData[9] = this.state.rawData.fogLampCount[21][0].fogLampBad3;
    defectData[10] = this.state.rawData.fogLampCount[22][0].fogLampBad2;
    defectData[11] = this.state.rawData.fogLampCount[23][0].fogLampBad1;
    
    

    currentLabels[0] = "-11 hrs";
    currentLabels[1] = "-10 hrs";
    currentLabels[2] = "-9 hrs";
    currentLabels[3] = "-8 hrs";
    currentLabels[4] = "-7 hrs";
    currentLabels[5] = "-6 hrs";
    currentLabels[6] = "-5 hrs";
    currentLabels[7] = "-4 hrs";
    currentLabels[8] = "-3 hrs";
    currentLabels[9] = "-2 hrs";
    currentLabels[10] = "-1 hrs";
    currentLabels[11] = "current";

    for (var i = 0; i < currentData.length; i ++){      
      fogLampGoodCount += currentData[i];
      fogLampBadCount  += defectData[i]; 
    }

    currentYield = (fogLampGoodCount - fogLampBadCount) / (fogLampGoodCount + fogLampBadCount);
    currentYield *= 100;
    

    this.setState({
      defectiveFogLamps: fogLampBadCount,
      goodFogLamps: fogLampGoodCount,
      yield: currentYield
    }) 


    this.setState({
      chartData:{
        labels: currentLabels,
        datasets:[        
          {
            label:'Fog Lamps Defected',
            data: defectData,
            backgroundColor:[
              //'#FFE710',
              'rgba(207, 0, 15, 1)',

            ]
          },
          {
            label:'Fog Lamps Completed',
            data: currentData,
            backgroundColor:[
              //'#FFE710',
              'rgba(71, 203, 67, 1)',

            ]
          }
          
        ]
      }
    });

    this.setState({
      renderGraph: true,
    });

    //this.updateFogLamps();  
    this.updateOrders();

    this.updateOrderVariables();

    this.updateGraph();

  
    }catch(error){
      console.log(error);
    }

  

}

renderCompletedIcon(inputCompletion){


  if (inputCompletion === true){

    return(
      <FontAwesomeIcon size="2x" icon="check-circle" color="#008000"/>

      )
  }
  else{
    return(
      <FontAwesomeIcon size="2x" icon="times" color="#ff6961"/>

    ) 
  }

}

renderOrderDetails(){

  try{
    if (this.state.ordersReceived === true){

      return(
        
        this.state.orderInfo[0].map(currentOrder =>
          <tr key={currentOrder.PK_orderLine_id}>
          <th >{currentOrder.PK_orderLine_id}</th>
          <th >{currentOrder.timeRequested}</th>
          <th >{currentOrder.quantity}</th>
          <th >{currentOrder.quantityBuilt}</th>
          <th >{this.renderCompletedIcon(currentOrder.complete)}</th>
        </tr>
          ))
      
    }    
  }catch(error){
    console.log(error);
  }
  
}


renderChart(){

  if (this.state.renderGraph === true){
    return(
      <div className="form-row">
      <div className="col-12">
        <Chart key={this.state.fogLampCount} chartData={this.state.chartData} chartTitle="Fog Lamps Built" legendPosition="bottom" />
      </div>        
    </div>
    )
  }
}


  render() {

    return (
          <div className="container">
          <br></br>
          <h1>Dashboard</h1>
            <h3>{Date()}</h3>
          <br></br>
          <div className="form-row">
            <div className="col-2">
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
            <div className="col-2">
                <div className="card border-left-primary shadow h-100 py-2">
                    <div className="card-body">
                        <div className="row no-gutters align-items-center">
                            <div className="col mr-2">
                                <div className="text-xs font-weight-bold text-primary text-uppercase mb-1">Fog Lamps Required</div>
                                <div className="h5 mb-0 font-weight-bold text-gray-800">{this.state.fogLampsRequired}</div>
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
                                <div className="h5 mb-0 font-weight-bold text-gray-800">{this.state.goodFogLamps}</div>
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
                                <div className="h5 mb-0 font-weight-bold text-gray-800">{this.state.defectiveFogLamps}</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className="col-2">
                <div className="card border-left-primary shadow h-100 py-2">
                    <div className="card-body">
                        <div className="row no-gutters align-items-center">
                            <div className="col mr-2">
                                <div className="text-xs font-weight-bold text-primary text-uppercase mb-1">Yield</div>
                                <div className="h5 mb-0 font-weight-bold text-gray-800">{this.state.yield}%</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <br></br>

{this.renderChart()}
<br></br>
            
  <table className="table table-sm">
  <thead>
    <tr>
      <th scope="col">Order ID</th>
      <th scope="col">Date Requested</th>
      <th scope="col">Order Amount</th>
      <th scope="col">Amount Completed</th>
      <th scope="col">Completed</th>
    </tr>
  </thead>
  <tbody>
{this.renderOrderDetails()}  

  </tbody>  
</table>



          </div>          
        );
    }
       
}

export default Dashboard;