import { Box, TextField, Typography } from "@mui/material";
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
import CalendarMonthIcon from '@mui/icons-material/CalendarMonth';


const columns = [
    { 
        field: 'id',
        headerName: 'ID', 
        width: 90
    },
    {
        field: 'firstName',
        headerName: 'Nome',
        width: 150,
        editable: false,
    },
    
    {
        field: 'Idade',
        headerName: 'Idade',
        width: 150,
        editable: false,
    },

    {
        field: 'Cpf',
        headerName: 'Cpf',
        width: 150,
        editable: false,
    },
    
  
  ];


export default function BuscaPaciente(){

    const [nome, setNome] = useState('');
    const [paciente, setPaciente] = useState([]);

    const navigate = useNavigate();

    const email = localStorage.getItem('email');
    const token = localStorage.getItem('token');
    
    
    
    const rows =  paciente.map( pacientes => (
        {
            id:pacientes.id,
            firstName: pacientes.nome,
            Idade: pacientes.idade,
            Cpf: pacientes.cpf
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

    async function editaAgendamento(id){
        try {

            if (idSelecionado === 0) {
                alert("Selecione um Paciente para Agendar.");  
           }
           else{
                navigate(`/agenda/novo/${id}`);
           }

        } catch (error) {
            alert('Não foi possível realizar o agendamento' + error);
        }
    }
   
    
    return(

        <Box sx={{ display: 'flex' }}>
        
        
        {/* <AppBarComponent/>
        <DrawerComponent/> */}
         <MenuAppBar />
        
        <div className="center-datagrid-funcionarios"> 
            <div>
                <h4>Consulta Paciente</h4>
                <TextField
                        required
                        id="id-nome"
                        label="Nome paciente"
                        placeholder="Nome completo"          
                        variant="standard"
                        name="nome"
                        //value={nome}
                        //onChange={e => setNome(e.target.value)}
                        />
            </div>
        
                        

        <Box sx={{ height: 400, width: '100%' }}>
          
           <br/>
            <Button variant="contained" size="small" startIcon={<CalendarMonthIcon />} color="success" onClick={() => editaAgendamento(idSelecionado)}>Novo Agendamento</Button> {' '}   
            {/* {rows.length === 0 ? <Button variant="contained"  disabled >Editar Paciente</Button> : <Button variant="contained" onClick={() => editarPaciente(1)}>Editar Paciente</Button>} */}
        

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