import { Box, Button } from "@mui/material";
import React, { useEffect, useState } from "react";
import MenuAppBar from "../../components/MenuAppBar";
import "./styles.css";
import api from "../../services/api";
import { DataGrid } from '@mui/x-data-grid';
import {useNavigate} from "react-router-dom";
import CalendarMonthIcon from '@mui/icons-material/CalendarMonth';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';

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
export default function Agenda(){
    
    const [nome, setNome] = useState('');
    const [agendamento, setAgendamento] = useState([]);
    const navigate = useNavigate();

    const email = localStorage.getItem('email');
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
        api.get('api/Agendamento', authorization)
        .then(response => {setAgendamento(response.data);
        },token)
    },[])

    async function editarAgendamento(id){
        try {
           
            if (idSelecionado === 0) {
                alert("Selecione um Agendamento para Editar.");  
            }
            else{
                navigate(`/agenda/novo/${id}`);
            } 
        } catch (error) {
            alert('Não foi possível editar o agendamento' + error);
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
        
      };

      async function deletarAgendamento(id){
        try {
            if (id === 0) {
                alert('Selecione um Agendamento para excluir.')
            }
            else if (window.confirm('Deseja deletar o agendamento ' + idSelecionado + ' ?')) {
                await api.delete(`api/Agendamento/${id}`, authorization);

                setAgendamento(agendamento.filter(agenda => agenda.id !== id));
                navigate('/agenda');
            }
        } catch (error) {
            alert('Não foi possível excluir o Agendamento');
        }

        

      }



    return(

        <Box sx={{ display: 'flex' }}>
        
        
        {/* <AppBarComponent/>
        <DrawerComponent/> */}
         <MenuAppBar />
        
        <div className="center-datagrid-funcionarios"> 
        <Box sx={{ height: 400, width: '100%' }}>
          
            <Button variant="contained" size="small" startIcon={<CalendarMonthIcon />} color="success" onClick={() => navigate('/agenda/buscaPaciente')}>Novo</Button> {' '}   
            {rows.length === 0 ? <Button variant="contained" size="small" startIcon={<EditIcon />} disabled >Editar</Button> : <Button variant="contained" size="small" startIcon={<EditIcon />} onClick={() => editarAgendamento(idPaciente)}>Editar</Button>} {' '}  
            <Button variant="contained" size="small" startIcon={<DeleteIcon />} color="error" onClick={() => deletarAgendamento(idSelecionado)}>Excluir</Button> {' '}   
            <h4>Agendamentos</h4>
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