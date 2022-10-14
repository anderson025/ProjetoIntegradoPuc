import { Box, Typography } from "@mui/material";
import React, { useEffect, useState } from "react";
import MenuAppBar from "../../components/MenuAppBar";
import "./styles.css";
import {Link , useParams, useNavigate} from "react-router-dom";

import './styles.css';

import NovoFuncionario from "../NovoFuncionario";
import {FiXCircle} from 'react-icons/fi';
import api from "../../services/api";
import Home from "../Home";


import { DataGrid } from '@mui/x-data-grid';
import { Button } from "@mui/material";
import AppBarComponent from "../../components/AppBarComponent";
import DrawerComponent from "../../components/DrawerComponent";

import DeleteIcon from '@mui/icons-material/Delete';
import AccessibilityNewIcon from '@mui/icons-material/AccessibilityNew';
import EditIcon from '@mui/icons-material/Edit';



const columns = [
    { field: 'id', headerName: 'ID', width: 90 },
    {
      field: 'nomePaciente',
      headerName: 'Nome',
      width: 150,
      editable: true,
    },
    {
      field: 'cpf',
      headerName: 'CPF',
      width: 150,
      editable: true,
    },
  
  ];


export default function Pacientes(){

    const [nome, setNome] = useState('');
    const [paciente, setPaciente] = useState([]);
    const navigate = useNavigate();

    const email = localStorage.getItem('email');
    const token = localStorage.getItem('token');
    
    
    
    const rows =  paciente.map( pacientes => (
        {
            id:pacientes.id,
            nomePaciente: pacientes.nome,
            cpf: pacientes.cpf
        }
    ))
   

    const authorization = {
        headers: {
            'Authorization' : `Bearer ${token}`
        }
    }

    useEffect ( () => {
        api.get('api/Pacientes', authorization)
        .then(response => {setPaciente(response.data);
        },token)
    },[])
    
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
    async function editarPaciente(id){
        try {

            if (idSelecionado === 0) {
                alert("Selecione um Paciente para Editar.");  
           }
           else{
            navigate(`/paciente/novo/${id}`);
           }

        } catch (error) {
            alert('Não foi possível editar o paciente' + error);
        }
    }

    async function deletarPaciente(id){
        try {
            if (id === 0) {
                alert('Selecione um paciente pra excluir.');
            }
            else if (window.confirm('Deseja deletar o paciente id = ' + id + ' ?')) {

                await api.delete(`api/pacientes/${id}`, authorization);

                setPaciente(paciente.filter(pacient => pacient.id !== id));
            }
        } catch (error) {
            alert('Não foi possível excluir o funcionario');
        }

      }
    
    return(

        <Box sx={{ display: 'flex' }}>
        
        
        {/* <AppBarComponent/>
        <DrawerComponent/> */}
         <MenuAppBar />
        
        <div className="center-datagrid-funcionarios"> 
        <Box sx={{ height: 400, width: '100%' }}>
          
           
            <Button variant="contained" size="small" startIcon={<AccessibilityNewIcon />} color="success" onClick={() => navigate('/paciente/novo/0')}>Novo</Button> {' '}   
            {rows.length === 0 ? <Button variant="contained" size="small" startIcon={<EditIcon />} disabled >Editar</Button> : <Button variant="contained" size="small" startIcon={<EditIcon />} onClick={() => editarPaciente(idSelecionado)}>Editar</Button>}{' '}    
            <Button variant="contained" size="small" startIcon={<DeleteIcon />} color="error" onClick={() => deletarPaciente(idSelecionado)}>Excluir</Button> {' '}   
            <h4>Cadastrado Paciente</h4> 
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
       
       
        </Box>
        </div>
       
        </Box>
        
    )
}