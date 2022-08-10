import { Box, Button, Stack, TextField } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";
import { FuncionarioService } from "../api/FuncionarioService";

export const Agenda = () => {
   
    const [data, setData] = useState([]);
    const [pacienteSelecionado, setPacienteSelecionado] = useState();


    const agendamentoGet = async()=>{
        await FuncionarioService.getFuncionarios()
        .then(response => {
          setData(response.data);
        }).catch(error=>{
          console.log(error);
        })
      }

      const pacienteSelecionadoGet = async()=>{
        await FuncionarioService.getFuncionarios()
        .then(response => {
          setData(response.data);
        }).catch(error=>{
          console.log(error);
        })
      }

      useEffect(()=>{
        agendamentoGet();
      })
      
    return(
         <div>
             <h4>Agendamento</h4>
             <table className="table table-bordered">      
               

        <thead>
        <div>            
            <Box
                component="form"
                sx={{
                    '& .MuiTextField-root': { m: 1, width: '25ch' },
                }}
                noValidate
                autoComplete="off"
            >      
                <h5>Busca Pacientes</h5>
                <div>             
            
                    <TextField
                    required
                    id="id-nome"
                    label="Nome:"
                    placeholder="Nome completo"          
                    variant="standard"
                    name="nome"
                    //   onChange={funcionarioChange}
                    />
                </div>
                <div>
                    <Stack direction="row" spacing={2} >
                        <Button variant="contained" > Pesquisar</Button>                                    
                        
                    </Stack>
                </div>
            </Box>
        </div><br/>

          <tr>
            <th>Id</th>
            <th>Nome</th>
            <th>CPF</th>
            <th>Rg</th>
            <th>Agendamento</th>
          </tr>
        </thead>
        <tbody>

        

          {data.map(agendamento => (
            <tr key={agendamento.id}>
              <td>{agendamento.id}</td>
              <td>{agendamento.nome}</td>   
              <td>{agendamento.cpf}</td>
              <td>{agendamento.rg}</td>            
              <td>
                <button className="btn btn-primary"> Incluir </button>{" "}
                <button className="btn btn-danger"> Cancelar </button>
              </td>
            </tr>

          ))}

        </tbody>
        </table>
         </div>
     )
 };
 