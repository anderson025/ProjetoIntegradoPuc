import React, { useEffect, useState } from "react";
import './styles.css';

import NovoFuncionario from "../NovoFuncionario";
import {FiXCircle} from 'react-icons/fi';
import api from "../../services/api";
import Home from "../Home";
import MenuAppBar from '../../components/MenuAppBar';
import {Link , useParams, useNavigate} from "react-router-dom";

import Box from '@mui/material/Box';
import { DataGrid } from '@mui/x-data-grid';
import { Button, Typography } from "@mui/material";
import AppBarComponent from "../../components/AppBarComponent";
import DrawerComponent from "../../components/DrawerComponent";
import DeleteIcon from '@mui/icons-material/Delete';
import AccessibilityNewIcon from '@mui/icons-material/AccessibilityNew';
import EditIcon from '@mui/icons-material/Edit';

const columns = [
  { 
    field: 'id',
     headerName: 'ID',
      width: 90 
  },
  
  { 
    field: 'idPaciente',
     headerName: 'Id Paciente',
      width: 90 
  },
  {
    field: 'NomePaciente',
    headerName: 'Nome Paciente',
    width: 150,
    editable: true,
  },
  { 
    field: 'idFuncionario',
     headerName: 'Id Funcionario',
      width: 90 
  },
  {
    field: 'NomeFuncionario',
    headerName: 'Nome Funcionario',
    width: 150,
    editable: true,
  }
 
];



export default function TodasAvaliacoes(){

    const [id, setId] = useState('');
    const [idFuncionario, setIdFuncionario] = useState('');
    const [idPaciente, setIdPaciente] = useState('');
    const [nomePaciente, setNomePaciente] = useState('');
    const [nomeFuncionario, setNomeFuncionario] = useState('');
    const [avaliacao, setAvaliacao] = useState([]);
    const navigate = useNavigate();

    const email = localStorage.getItem('email');
    const token = localStorage.getItem('token');
    const [idAgendamento, setIdAgendamento] = useState('');
    const [dataAgendamento, setDataAgendamento] = useState('');
    
    
    const rows =  avaliacao.map( avaliacoes => (

        {   
            id:avaliacoes.id,
            idPaciente: avaliacoes.idPaciente,
            NomePaciente: avaliacoes.nomePaciente,
            idFuncionario: avaliacoes.idFuncionario,
            NomeFuncionario: avaliacoes.nomeFuncionario
        }


    ))
   

    const authorization = {
        headers: {
            'Authorization' : `Bearer ${token}`
        }
    }

    useEffect ( () => {
        loadAvaliacao();
        loadPaciente();

        api.get('api/Avaliacao', authorization)
        .then(response => {setAvaliacao(response.data);
        },token)

    },[])

    async function editarAvaliacao(id){
        try {           
           
           if (idSelecionado === 0) {
                alert("Selecione uma Avaliação para Editar.");  
           }
           else{
                navigate(`/avaliacao/editar/${id}`);
           }
            
            
        } catch (error) {
            alert('Não foi possível editar a Avaliação' + error);
        }
    }

    var idSelecionado = 0;
    const onRowsSelectionHandler = (ids) => {
        
        if (idSelecionado !== 0) {
            idSelecionado = 0;
        }
        const selectedRowsData = ids.map((id) => rows.find((row) => row.id === id));        
        console.log(selectedRowsData);
        
        for (let index = 0; index < selectedRowsData.length; index++) {
            idSelecionado = selectedRowsData[index].id;

        }
        
        console.log(idSelecionado);
        
      };

      async function deletarFuncionario(id){

        var pendenteAvaliacao = 0;

        var nomeFunciorio = nomeFuncionario;

        const atualizaAgendamento = {
            idAgendamento,
            idFuncionario,
            nomeFunciorio,
            idPaciente,
            nomePaciente,
            dataAgendamento,            
            pendenteAvaliacao
        }

        try {
            if (window.confirm('Deseja deletar a avaliação id = ' + id + ' ?')) {

                await api.delete(`api/Avaliacao/${id}`, authorization);

                await api.put(`api/agendamento/${idAgendamento}`, atualizaAgendamento ,authorization);

                setAvaliacao(avaliacao.filter(avalia => avalia.id !== id));
            }
        } catch (error) {
            alert('Não foi possível excluir a Avaliação');
        }

      }

      async function loadPaciente(){
        try {
            const response = await api.get(`api/pacientes/${idPaciente}`, authorization);
            
            // setIdPaciente(response.data.id);
            // setNomePaciente(response.data.nome);
            // setIdade(response.data.idade);
            // setDataNasci(new Date(response.data.dataNascimento).toLocaleDateString("pt-br", opcao));

            //agendamento
            setIdAgendamento(response.data.agendamento.idAgendamento);
            setDataAgendamento(response.data.agendamento.dataAgendamento);

            console.log(response);
            

        } catch (error) {

          if(error.message.includes("401")){
            localStorage.clear();
            localStorage.setItem('token', '');                        
            navigate('/');
          }
          else{
            alert('Erro ao tentar recuperar o Pacientes' + error);
            navigate('/avaliacao');
          }
            
        }
    }

    async function loadAvaliacao(){
        try {

            const response = await api.get('api/avaliacao', authorization);
            
            setId(response.data.id);
            setNomePaciente(response.data.nomePaciente);
            setNomeFuncionario(response.data.nomeFuncionario);
            setIdPaciente(response.data.idPaciente);
            setIdFuncionario(response.data.idFuncionario);           

           

        } catch (error) {

            if(error.message.includes("401")){
                localStorage.clear();
                localStorage.setItem('token', '');                        
                navigate('/');
            }
            else{
                alert('Erro ao tentar recuperar o Avaliação' + error);                
                navigate('/avaliacao');
            }
            
        }
    }

    return(  
        
        
     
        <Box sx={{ display: 'flex' }}>
        
        
        {/* <AppBarComponent/>
        <DrawerComponent/> */}
         <MenuAppBar />
        
        <div className="center-datagrid-funcionarios"> 
        <Box sx={{ height: 400, width: '100%' }}>

            
            {/* <Button variant="contained" size="small" startIcon={<AccessibilityNewIcon />} color="success" onClick={() => navigate('/funcionario/novo/0')}>Novo</Button> {' '}    */}
            {rows.length === 0 ? <Button variant="contained" size="small" startIcon={<EditIcon />}  disabled >Editar</Button> : <Button variant="contained" size="small"  startIcon={<EditIcon />}  onClick={() => editarAvaliacao(idSelecionado)}>Editar</Button>}{' '} 
            <Button variant="contained" size="small" startIcon={<DeleteIcon />} color="error" onClick={() => deletarFuncionario(idSelecionado)}>Excluir</Button> {' '}   
            <h4>Todas Avaliações</h4>
            <DataGrid
           
            rows={rows}
            columns={columns}
            pageSize={5}
            rowsPerPageOptions={[5]}
            checkboxSelection            
            disableSelectionOnClick
            experimentalFeatures={{ newEditingApi: true }}
            onSelectionModelChange={(ids) => onRowsSelectionHandler(ids)
                
            }

            
        />

       
       
        {/* <Button variant="contained" color="success" onClick={() => editarFuncionario(funcionarios.id)}>Editar Funcionario</Button> */}
        </Box>
        </div>
       
        </Box>
        
           
   
    );
}