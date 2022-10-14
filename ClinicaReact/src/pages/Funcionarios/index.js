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
  { field: 'id', headerName: 'ID', width: 90 },
  {
    field: 'nomeFuncionario',
    headerName: 'Nome',
    width: 150,
    editable: true,
  },
  {
    field: 'cpf',
    headerName: 'CPF',
    width: 150,
    editable: true,
  }

];


export default function Funcionarios(){

    const [nome, setNome] = useState('');
    const [funcionario, setFuncionario] = useState([]);
    const navigate = useNavigate();

    const email = localStorage.getItem('email');
    const token = localStorage.getItem('token');
    
    
    
    const rows =  funcionario.map( funcionarios => (
        {
            id:funcionarios.id,
            nomeFuncionario: funcionarios.nome, 
            cpf: funcionarios.cpf
        }
    ))
   

    const authorization = {
        headers: {
            'Authorization' : `Bearer ${token}`
        }
    }

    useEffect ( () => {
        api.get('api/Funcionarios', authorization)
        .then(response => {setFuncionario(response.data);
        },token)
    },[])

    async function editarFuncionario(id){
        try {           
           
           if (idSelecionado === 0) {
                alert("Selecione um Funcionario para Editar.");  
           }
           else{
                navigate(`/funcionario/novo/${id}`);
           }
            
            
        } catch (error) {
            alert('Não foi possível editar o funcionário' + error);
        }
    }

    var idSelecionado = 0;
    var nomeFuncionario ='';
    const onRowsSelectionHandler = (ids) => {
        
        if (idSelecionado !== 0) {
            idSelecionado = 0;
        }
        const selectedRowsData = ids.map((id) => rows.find((row) => row.id === id));        
        console.log(selectedRowsData);
        
        for (let index = 0; index < selectedRowsData.length; index++) {
            idSelecionado = selectedRowsData[index].id;
            nomeFuncionario = selectedRowsData[index].firstName;

        }
        
        console.log(idSelecionado);
        
      };

      async function deletarFuncionario(id){
        try {
            if (id === 0) {
                alert('Selecione um funcionado para excluir.')
            }
            else if (window.confirm('Deseja deletar o funcionario ' + nomeFuncionario + ' ?')) {
                await api.delete(`api/Funcionarios/${id}`, authorization);

                setFuncionario(funcionario.filter(func => func.id !== id));
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

            
            <Button variant="contained" size="small" startIcon={<AccessibilityNewIcon />} color="success" onClick={() => navigate('/funcionario/novo/0')}>Novo</Button> {' '}   
            {rows.length === 0 ? <Button variant="contained" size="small" startIcon={<EditIcon />}  disabled >Editar</Button> : <Button variant="contained" size="small"  startIcon={<EditIcon />}  onClick={() => editarFuncionario(idSelecionado)}>Editar</Button>}{' '} 
            <Button variant="contained" size="small" startIcon={<DeleteIcon />} color="error" onClick={() => deletarFuncionario(idSelecionado)}>Excluir</Button> {' '}   
            <h4>Cadastrado Funcionario</h4>    
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