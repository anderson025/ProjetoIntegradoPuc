import { Box, Button } from "@mui/material";
import React, { useEffect, useState } from "react";
import MenuAppBar from "../../components/MenuAppBar";
import "./styles.css";

import { DataGrid } from '@mui/x-data-grid';
import './styles.css';


import api from "../../services/api";
import Home from "../Home";
import {Link , useParams, useNavigate } from "react-router-dom";

import DeleteIcon from '@mui/icons-material/Delete';
import AccessibilityNewIcon from '@mui/icons-material/AccessibilityNew';
import EditIcon from '@mui/icons-material/Edit';



const columns = [
    { field: 'id', headerName: 'ID', width: 90 },
    {
      field: 'idFuncionario',
      headerName: 'Fisioterapeuta',
      width: 150,
      editable: true,
    },
    {
        field: 'NomeFunciorio',
        headerName: 'Nome Fisioterapeuta',
        width: 150,
        editable: true,
    },
    {
      field: 'Paciente',
      headerName: 'Paciente',
      width: 150,
      editable: true,
    },
    {
        field: 'nomePaciente',
        headerName: 'Nome Paciente',
        width: 150,
        editable: true,
      },
    {
        field: 'Data',
        headerName: 'Data',
        width: 150,
        editable: true,
      }

  ];


export default function Avaliacao(){
    const [nome, setNome] = useState('');
    const [agendamento, setAgenda] = useState([]);
    const navigate = useNavigate();

    
    const token = localStorage.getItem('token');   
    
    
    //Formatacao da data
    const opcao = {
        year:"numeric",
        month:"numeric",
        day:"numeric"
    }    
    
    const rows =  agendamento.map(agendamentos => (
        {
            id:agendamentos.idAgendamento,
            idFuncionario: agendamentos.idFuncionario,
            NomeFunciorio: agendamentos.nomeFunciorio,
            Paciente: agendamentos.idPaciente,
            nomePaciente: agendamentos.nomePaciente,
            Data: new Date(agendamentos.dataAgendamento).toLocaleDateString("pt-br", opcao)
        }
    ))
   

    const authorization = {
        headers: {
            'Authorization' : `Bearer ${token}`
        }
    }

    useEffect ( () => {
        api.get('api/Agendamento/BuscaTodosPendenteAgendamentos', authorization)
        .then(response => {setAgenda(response.data);
        },token)
    },[])

    async function editarAvaliacao(id){
        try {           
            if (idSelecionado === 0) {
                alert("Selecione um agendamento para prosseguir.");  
           }
           else{
            navigate(`/avaliacao/novo/${id}`);
           }

        } catch (error) {
            alert('Não foi possível editar o Avaliacao' + error);
        }
    }

    var idSelecionado = 0;
    var idPaciente = 0;
    const onRowsSelectionHandler = (ids) => {

        
        if (idSelecionado !== 0) {
            idSelecionado = 0;
        }   
     
        const selectedRowsData = ids.map((id) => rows.find((row) => row.id === id));        
        console.log(selectedRowsData);
        
        for (let index = 0; index < selectedRowsData.length; index++) {
            idSelecionado = selectedRowsData[index].id;
            idPaciente = selectedRowsData[index].Paciente;
        }
        
        console.log(idSelecionado);
        console.log(idPaciente);
        
      };
    return(

        <Box sx={{ display: 'flex' }}>
        
        
        {/* <AppBarComponent/>
        <DrawerComponent/> */}
         <MenuAppBar />
        
        <div className="center-datagrid-funcionarios"> 
        <Box sx={{ height: 400, width: '100%' }}>
          
            <Button variant="contained" size="small" startIcon={<AccessibilityNewIcon />} color="success" onClick={() => editarAvaliacao(idPaciente)}>Nova</Button> {' '}   
            {/* {rows.length === 0 ? <Button variant="contained"  disabled >Editar Avaliacao</Button> : <Button variant="contained" onClick={() => editarAvaliacao(1)}>Editar Avaliacao</Button>} */}
            <Button variant="contained" size="small" onClick={() => navigate('/avaliacao/todasAvaliacoes')}>Todas Avaliações</Button> {' '}   
            <h4>Agendamentos pendentes</h4>
            <DataGrid
           
           rows={rows}
           columns={columns}
           pageSize={5}
           rowsPerPageOptions={[5]}
           checkboxSelection
           disableSelectionOnClick
           experimentalFeatures={{ newEditingApi: true }}
           onSelectionModelChange={(ids) => onRowsSelectionHandler(ids)}
       />

       
       
        {/* <Button variant="contained" color="success" onClick={() => editarFuncionario(funcionarios.id)}>Editar Funcionario</Button> */}
        </Box>
        </div>
       
        </Box>
        
    )
}