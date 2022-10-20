import React from "react";
import {Routes, Route} from 'react-router-dom';
import Agenda from "./pages/Agenda";
import Avaliacao from "./pages/Avaliacao";
import BuscaPaciente from "./pages/BuscaPaciente";
import Funcionarios from "./pages/Funcionarios";
import Home from "./pages/Home";
import SignInSide from "./pages/Login";
import NovaAvaliacao from "./pages/NovaAvaliacao";
import NovoAgendamento from "./pages/NovoAgendamento";

import NovoFuncionario from "./pages/NovoFuncionario";
import NovoPaciente from "./pages/NovoPaciente";
import Pacientes from "./pages/Pacientes";
import TodasAvaliacoes from "./pages/TodasAvaliacoes";


export default function MainRoutes() {

    return(
    
        <Routes>
            <Route path="/" element={< SignInSide/>} />
            <Route path="/funcionarios" element={ <Funcionarios/>} />
            <Route path="/funcionario/novo/:funcionarioId" element={<NovoFuncionario />} />
            <Route path="/home" element={ <Home/>} />
            <Route path="/pacientes" element={ <Pacientes />} />
            <Route path="/paciente/novo/:pacienteId" element={<NovoPaciente />} />
            <Route path="/agenda" element={<Agenda />} />
            <Route path="/agenda/novo/:pacienteId" element={<NovoAgendamento />} />
            <Route path="/avaliacao" element={<Avaliacao />} />
            <Route path="/avaliacao/novo/:avaliacaoId, idselecionado" element={<NovaAvaliacao />} />
            <Route path="/avaliacao/editar/:avaliacaoId" element={<NovaAvaliacao />} />
            <Route path="/avaliacao/todasAvaliacoes" element={<TodasAvaliacoes />} />
            <Route path="/agenda/buscaPaciente" element={<BuscaPaciente />} />
            
            {/* <Route path="/funcionarios" element={ <Funcionario/>} />
            <Route path="/" element={< Home/>} />
            <Route path="/pacientes" element={ <Paciente />} />
            <Route path="/agendamento" element={<Agenda />} />
            <Route path="/avaliacao" element={<Avaliacao />} />
            <Route path="/evolucao" element={<Evolucao />} />
            <Route path="/sessao" element={<Sessao />} />
            <Route path="/novoFuncionario" element={<NovoFuncionario />} />
            <Route path="/editarFuncionario" element={<EditarFuncionario />} /> */}
        </Routes>
    );
}