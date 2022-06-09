import './App.css';
import React, {useState, useEffect} from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import {Modal, ModalBody, ModalFooter, ModalHeader} from 'reactstrap';
import { Form } from 'reactstrap';

const baseUrl ="https://localhost:44365/Funcionarios";

function App() {

  
  const [user, setData] = useState([]);

  const funcionarioGet = () =>{
    axios.get(baseUrl)
    .then(response => {
      setData(response.data)
    }).catch(error=> {
      console.log(error);
    })
  }

  useEffect(()=>{
    funcionarioGet();
  })

  return (
    <div className="App">
      <br/>
      <h3>Cadastro de funcionarios</h3>      
      <header>
             
      </header>
      <table className='table table-bordered'>
        <thead>
          <tr>
            <th>Id</th>
            <th>Nome</th>
          </tr>
        </thead>    
       
                  
          
      <tbody>     

      {user.map(funcionario =>(
        <tr key={funcionario.id}>
          <td>{funcionario.id}</td>
        </tr>
      ))}
        
        
        
      </tbody>
      </table>
    </div>
  );
}


export default App;
