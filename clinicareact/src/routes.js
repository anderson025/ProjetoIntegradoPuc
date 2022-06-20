import React from "react";
import {Routes, Route} from 'react-router-dom';
import { Funcionario } from "./views/Funcionario";
import { Home } from "./views/Home";
import { Paciente } from "./views/Paciente";

export default function MainRoutes() {

    return(
        <Routes>
            <Route path="/api/Funcionarios" element={ <Funcionario/>} />
            <Route path="/" element={ <Home />} />
            <Route path="/api/Pacientes" element={ <Paciente />} />
        </Routes>
    );

}
