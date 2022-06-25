import React from "react";
import {Routes, Route} from 'react-router-dom';
import { Agenda } from "./pages/Agenda";
import { Avaliacao } from "./pages/Avaliacao";
import { Evolucao } from "./pages/Evolucao";
import { Funcionario } from "./pages/Funcionario";
import { Home } from "./pages/Home";
import { Paciente } from "./pages/Paciente";
import { Sessao } from "./pages/Sessao";

export default function MainRoutes() {

    return(
        <Routes>
            <Route path="/api/Funcionarios" element={ <Funcionario/>} />
            <Route path="/" element={ <Home />} />
            <Route path="/api/Pacientes" element={ <Paciente />} />
            <Route path="/api/Agenda" element={<Agenda />} />
            <Route path="/api/Avaliacao" element={<Avaliacao />} />
            <Route path="/api/Evolucao" element={<Evolucao />} />
            <Route path="/api/Sessao" element={<Sessao />} />
        </Routes>
    );

}
