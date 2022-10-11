import React from 'react';

import './Global.css';
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import MainRoutes from './routes';
import Home from './pages/Home';
import SignInSide from './pages/Login';
import { emphasize } from '@mui/material';
import MenuAppBar from './components/MenuAppBar';

export default function App() {
  
  return (
    <Router>

      {/* <SignInSide/> */}
      {/* {url_atual !== 'http://localhost:3000/'? <MenuAppBar></MenuAppBar> : <SignInSide></SignInSide> } */}
      {/* {email === null? <Routes><Route path="/" element={< SignInSide/>} /></Routes> : <Home />} */}
      {/* <Routes>
        <Route path="/" element={< SignInSide/>} />
        
      </Routes> */}
       {/* <Home /> */}
      <MainRoutes/>
      
    </Router>
  );
}


