import { Alert, Box, Button, Link, MenuItem, Stack, TextField } from "@mui/material";
import React, {useEffect, useState} from "react";
import MenuAppBar from "../../components/MenuAppBar";
import "./styles.css";
import {FiCornerDownLeft} from 'react-icons/fi';
import {useNavigate} from "react-router-dom";
import Pacientes from "../Pacientes";
import api from "../../services/api";
import {useParams} from "react-router-dom";
import { AndroidOutlined } from "@mui/icons-material";

export default function NovoAgendamento(){  

const [pendenteAvaliacao, setPendenteAvaliacao] = useState(0);
const [dataAgendamento, setDataAgendamento] = useState('');
const [idFuncionario , setIdFuncionario] = useState(null);    
const [id , setId] = useState(null);
const [nome, setNome] = useState('');
const [idade, setIdade] = useState('');
const [dataNasci, setDataNasci] = useState('');   
const [rg, setRg] = useState(''); 
const [cpf, setCpf] = useState('');
const [telefone, setTelefone] = useState('');
const [celular, setCelular] = useState(''); 
const [email, setEmail] = useState(''); 
const [situacao, setSituacao] = useState(true); 
const [convenio, setConvenio] = useState(''); 
const [carteiraConvenio, setCarteiraConvenio] = useState(''); 
const [rua, setRua] = useState(''); 
const [numero, setNumero] = useState(''); 
const [bairro, setBairro] = useState(''); 
const [cep, setCep] = useState(''); 
const [cidade, setCidade] = useState(''); 
const [estado, setEstado] = useState(''); 
const [uf, setUf] = useState(''); 
//const [enderecoId, setEnderecoId] = useState(''); 


const [sexo, setSexo] = useState(0);
const [profissao, setProfissao] = useState(0);
const {pacienteId} = useParams();
//const {funcionarioId} = useParams();

const navigate = useNavigate();
//Data
const opcao = {
    year:"numeric",
    month:"numeric",
    day:"numeric"
}




//funcionario
const [funcionario, setFuncionario] = useState([]);
const [idFunc , setIdFunc] = useState(null);
const [nomeFunc, setNomeFunc] = useState('');
const [comboFunc, setComboFunc] = useState(1);

// const dataAgendada = '';
// var agenda = ''
// var dataFull = ''
// const [full, ano,dia,mes] = '';

const agendaChange = (event) =>{

    var agenda = document.getElementById("id-data-agendamento").value;
    var [dia,mes,ano] = agenda.split("/");
    //var dataFull = new Date(agenda).toISOString();
    // //const regex =  /^([0-9]{4})-(0[1-9]|1[0-2])-(0[1-9]|2[0-9]|3[0-1])/
    // const regex =  /^([0-9]{4})-(0[1-9]|2[0-9]|3[0-1])-(0[1-9]|1[0-2])/
    // [full, ano,dia,mes] = regex.exec(dataFull);
        
    const dataAgendada = `${ano}-${mes}-${dia}T03:00:00.000Z`;
    setDataAgendamento(dataAgendada);
    
    
}


  const funcChange = (event) => {
    setComboFunc(event.target.value);    
    
  };    

    // var funcionarioVet = funcionario.map(funcionarios =>(
    //     [
    //     {
    //         value: funcionarios.id,
    //         label: funcionarios.nome
    //     }
        
    //   ]

    // ));
        
        
      const currencies = [
        {
          value: '0',
          label: 'Fisioterapeuta',
        },
        {
          value: '1',
          label: 'Recepcionista',
        },
        
      ];

      const token = localStorage.getItem('token');   
     
  
      const authorization = {
          headers: {
              'Authorization' : `Bearer ${token}`
          }
      }

    useEffect(() =>{
        
        if (pacienteId === '0') {
           return; 
        } else {
            
            
            loadPaciente();
            loadFuncionario();            
            
            api.get('api/Funcionarios', authorization)
            .then(response => {setFuncionario(response.data);
            },token)
        }
    }, [])    

    async function loadPaciente(){
        try {         
            
            const response = await api.get(`api/pacientes/${pacienteId}`, authorization);

            setId(response.data.id);
            setNome(response.data.nome);
            setIdade(response.data.idade);
            setDataNasci(response.data.dataNasci);
            setRg(response.data.rg);
            setCpf(response.data.cpf);
            setSexo(response.data.sexo);
            setProfissao(response.data.profissao);            
            setTelefone(response.data.telefone);
            setCelular(response.data.celular);
            setEmail(response.data.email);
            setSituacao(response.data.situacao);
            setConvenio(response.data.convenio);
            setCarteiraConvenio(response.data.carteiraConvenio);
            setRua(response.data.endereco.rua);
            setNumero(response.data.endereco.numero);
            setBairro(response.data.endereco.bairro);
            setCep(response.data.endereco.cep);
            setCidade(response.data.endereco.cidade);
            setEstado(response.data.endereco.estado);
            setUf(response.data.endereco.uf);
            
            //setEnderecoId(response.data.enderecoId);

            

        } catch (error) {
            alert('Erro ao tentar recuperar o Pacientes' + error);
            navigate('/agenda');
        }
    }
    async function loadFuncionario(){
        try {
            const response = await api.get(`api/funcionarios`, authorization);

            setFuncionario(response.data);          
            

        } catch (error) {

          if(error.message.includes("401")){
            localStorage.clear();
            localStorage.setItem('token', '');                        
            navigate('/');
          }
          else{
            alert('Erro ao tentar recuperar o Funcionario' + error);
            navigate('/funcionarios');
          }
            
        }
    }   
    

    async function saveOrUpdate(event){

        event.preventDefault(); 
        
        var select = document.getElementById("id-fisio").textContent;                      
        var nomeFunciorio = select;               
        var idFuncionario = comboFunc;
        var idPaciente = id;
        var NomePaciente = nome;     
       
        const data = {
            idPaciente,
            idFuncionario,
            dataAgendamento,
            nomeFunciorio,
            NomePaciente,
            pendenteAvaliacao           

        }
       

        try {
           
            await api.post('/api/agendamento', data, authorization);            
            // if (pacienteId ==='0') {
                
            //     await api.post('/api/agendamento', data, authorization);
            // }
            // else{
            //     data.id = id;
                                
            //     await api.put(`api/agendamento/${id}`,data,authorization);
            // }

        } catch (error) {
           
            alert(error.response.data);
        }

        navigate('/agenda');
    }

    

   
        


    return(

        <Box sx={{ display: 'flex' }}>        
        <MenuAppBar/>
            <div className="center-datagrid"> 
                <Box
                    component="form"
                    sx={{
                        '& .MuiTextField-root': { m: 1, width: '25ch' },
                    }}
                    noValidate
                    autoComplete="off"
                    onSubmit={saveOrUpdate}
                >      
            
                    <div>
                        {/* <Link className="back-link" to="/Home">
                            <FiCornerDownLeft size="25" color="#17202a"/>
                            Voltar
                        </Link> */}
                        {/* <h5>{funcionarioId === '0'? 'Incluir Funcionario': 'Atualizar Funcionario'}</h5>                */}
                        <h5>Agendamento</h5>                           

                            <TextField
                            disabled
                            id="id-nome"
                            label="Nome paciente"
                            placeholder="Nome completo"          
                            variant="standard"
                            name="nome"
                            value={nome}
                            onChange={e => setNome(e.target.value)}
                            
                            />
                            {/* <TextField
                            required
                            id="id-funcionario"
                            label="Fisioterapeuta"
                            placeholder="Funcionario"          
                            variant="standard"
                            name="funcionario"
                            //value={nome}
                            onChange={e => setIdFuncionario(e.target.value)}
                            /> */}

                            <TextField
                            id="id-fisio"
                            select
                            label="Fisioterapeuta"
                            value={comboFunc}
                            onChange={funcChange}
                            helperText="Selecione o funcionario"
                            variant="standard"
                            >
                            {funcionario.map((funcionarios) => (
                                <MenuItem key={funcionarios.id} value={funcionarios.id} name="fisio"
                                
                                >
                                {funcionarios.nome} 
                                </MenuItem>
                            ))}

                            </TextField>

                            <TextField
                            required
                            id="id-data-agendamento"
                            label="Data Agendamento:"
                            placeholder="DD/MM/YYYY"          
                            variant="standard"
                            name="dataAgendamento"
                            //value = {dataAgendamento}
                            onChange={agendaChange}
                            />
                    </div>

                    <div>
                        <Stack direction="row" spacing={2}>
                            <Button variant="contained" type="submit">Agendar</Button> 
                            <Button variant="contained" color="error" onClick={() => navigate('/agenda/buscaPaciente')}>Cancelar</Button>           
                            
                        </Stack>        
                    </div>            
                </Box>
                       
            </div>
        </Box>
        
    )
}