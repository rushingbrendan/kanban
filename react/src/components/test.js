import React, { Component } from 'react';
import {Line} from 'react-chartjs-2';
import axios from 'axios';

class DoughnutExample extends Component {
  state = {
    data: {
        labels: ['Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps','Foglamps'
        ],
        datasets: [{
            data: [300, 50, 100],
            backgroundColor: [
            '#FF6384',
            '#36A2EB',
            '#FFCE56'
            ],
            hoverBackgroundColor: [
            '#FF6384',
            '#36A2EB',
            '#FFCE56'
            ]
        }]
    },
    currentFogLampCount: 0,
  }

  componentDidMount() {
    this.timer = setInterval(
      () => this.increment(),
      500
    )
  }

  componentWillUnmount() {
    clearInterval(this.timer)
  }

  increment() {

    var currentFogLampCount = 0;


    axios.get(`http://localhost:3001/users/foglamps`)
    .then(res => {
      //const persons = res.data;
      this.currentFogLampCount = res.data.fogLampCount;

     // alert(res.data.fogLampCount);
      //alert(currentFogLampCount);
      
      //this.setState({ rawData: persons });
      //this.setState({fogLampCount: this.state.rawData.fogLampCount});        

      //alert(this.state.rawData.fogLampCount);
          
    })

    if ((this.currentFogLampCount !== undefined) && (this.currentFogLampCount !== 0)){

    let datacopy = Object.assign({}, this.state.data)
    //datacopy.datasets[0].data[0] = datacopy.datasets[0].data[0] + this.currentFogLampCount;
    datacopy.datasets[0].data.push(this.currentFogLampCount);
    datacopy.labels.push(this.currentFogLampCount);
    //alert(this.currentFogLampCount);
    console.log(datacopy.datasets[0].data)
    this.setState({data: datacopy})

    }
    
  }

  render(){
    return(
      <div>
      <Line data = {this.state.data} />
      </div>
    )
  }
}

export default DoughnutExample;