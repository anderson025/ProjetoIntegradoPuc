import React from "react";
import {Routes, Route} from 'react-router-dom';
import { Agenda } from "./pages/Agenda";
import { Avaliacao } from "./pages/Avaliacao";
import { Evolucao } from "./pages/Evolucao";
import { Funcionario } from "./pages/Funcionario";
import { Home } from "./pages/Home/Home";
import { NovoFuncionario } from "./pages/NovoFuncionario";
import { EditarFuncionario } from "./pages/EditarFuncionario";
import { Paciente } from "./pages/Paciente";
import { Sessao } from "./pages/Sessao";

export default function MainRoutes() {

    return(
        <Routes>
            <Route path="/funcionarios" element={ <Funcionario/>} />
            <Route path="/" element={< Home/>} />
            <Route path="/pacientes" element={ <Paciente />} />
            <Route path="/agendamento" element={<Agenda />} />
            <Route path="/avaliacao" element={<Avaliacao />} />
            <Route path="/evolucao" element={<Evolucao />} />
            <Route path="/sessao" element={<Sessao />} />
            <Route path="/novoFuncionario" element={<NovoFuncionario />} />
            <Route path="/editarFuncionario" element={<EditarFuncionario />} />
        </Routes>
    );
}
