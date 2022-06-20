import React, {useState, useEffect} from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import axios from 'axios';
import {Container, Modal, ModalBody, ModalFooter, ModalHeader, Navbar} from 'reactstrap';
import './App.css';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import Header from './components/Header.js';
import { Footer } from './components/Footer';
import { FuncionarioService } from './api/FuncionarioService';
import { Funcionario } from './views/Funcionario';
import { BrowserRouter as Router } from "react-router-dom";
import Routes from "./routes";

function App() {  

  return (   
    <Router>
      <div className="App">  
      
        <Header />     
        <Routes />
      </div>
    </Router>
  );
}


export default App;
