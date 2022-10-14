import React, {useEffect, useState} from "react";
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import MenuItem from '@mui/material/MenuItem';
import Button from '@mui/material/Button';
import Stack from '@mui/material/Stack';
import FormGroup from '@mui/material/FormGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import {Link , useParams, useNavigate} from "react-router-dom";
import {FiCornerDownLeft} from 'react-icons/fi';
import api from "../../services/api";
import MenuAppBar from "../../components/MenuAppBar";
import "../NovaAvaliacao/styles.css";

export default function NovaAvaliacao (){

const [id , setId] = useState(null);
const [idFuncionario, setIdFuncionario] = useState('');
const [nomeFuncionario, setNomeFuncionario] = useState('');
const [idPaciente, setIdPaciente] = useState('');
const [nomePaciente, setNomePaciente] = useState('');
const [nome, setNome] = useState('');
const [idade, setIdade] = useState('');
const [dataNasci, setDataNasci] = useState(''); 



const [dorme, setDorme] = useState(true);
const [fuma, setFuma] = useState(true);
const [historicoLesao, setHistoricoLesao] = useState(true);
const [cirurgia, setCirurgia] = useState(true);
const [atividade, setAtividade] = useState(true);
const [membroDominante, setMdominante] = useState(1);
const [profissao, setProfissao] = useState(0);
const {avaliacaoId} = useParams();


const [dataAvaliacao, setDataAvaliacao] = useState('');
const [nomeMedico, setNomeMedico] = useState('');
const [registroMedico, setCrm] = useState('');
const [peso, setPeso] = useState(null);
const [altura, setAltura] = useState(null);
const [diagnostico, setDiagnostico] = useState('');
const [hma, setHma] = useState('');
const [comobirdades, setComobirdades] = useState('');
const [medicacaoEmUso, setMedicacaoEmUso] = useState('');
const [medicacaoLesao, setMedicacaoLesao] = useState('');
const [avaliacaoPostural, setAvaliacaoPostural] = useState('');
const [membrosAtivos, setMembrosAtivos] = useState('');
const [membrosPassivos, setMembrosPassivos] = useState('');
const [testesEspeciais, setTestesEspeciais] = useState('');
const [testesFuncionais, setTesteFuncionais] = useState('');
const [outrasObservacoes, setOutrasObservacoes] = useState('');
const [condutaCurtoPrazo, setCondutaCurtoPrazo] = useState('');
const [condutaMedioPrazo, setCondutaMedioPrazo] = useState('');
const [condutaLongoPrazo, setCondutaLongoPrazo] = useState('');

const [idAgendamento, setIdAgendamento] = useState('');
const [comboFunc, setComboFunc] = useState(1);

const [dataAgendamento, setDataAgendamento] = useState('');

const navigate = useNavigate();

const[funcionario, setFuncionario] = useState([]);

const agendaChange = (event) =>{

  var agenda = document.getElementById("id-data-avaliacao").value;
  var [dia,mes,ano] = agenda.split("/");
  //var dataFull = new Date(agenda).toISOString();
  // //const regex =  /^([0-9]{4})-(0[1-9]|1[0-2])-(0[1-9]|2[0-9]|3[0-1])/
  // const regex =  /^([0-9]{4})-(0[1-9]|2[0-9]|3[0-1])-(0[1-9]|1[0-2])/
  // [full, ano,dia,mes] = regex.exec(dataFull);
      
  const dataAgendada = `${ano}-${mes}-${dia}T03:00:00.000Z`;
  setDataAvaliacao(dataAgendada);// 73 260  335
  
  
}

const funcChange = (event) => {
    setComboFunc(event.target.value);
           
  };

  const dormeChange = (event) => {
    setDorme(event.target.value);
  };
  const fumaChange = (event) => {
    setFuma(event.target.value);
  };

  const dominanteChange = (event) => {
    setMdominante(event.target.value);
  };
  const lesaoChange = (event) => {
    setHistoricoLesao(event.target.value);
  };

  const cirurgiaChange = (event) => {
    setCirurgia(event.target.value);
  };

  const atividadeChange = (event) => {
    setAtividade(event.target.value);
  };

   
    

    const dormeVet = [
        {
          value: true,
          label: 'Sim',
        },
        {
          value: false,
          label: 'Não',
        },
        
      ];
      const fumaVet = [
        {
          value: true,
          label: 'Sim',
        },
        {
          value: false,
          label: 'Não',
        },
        
      ];

      const lesaoVet = [
        {
          value: true,
          label: 'Sim',
        },
        {
          value: false,
          label: 'Não',
        },
        
      ];

      const cirurgiaVet = [
        {
          value: true,
          label: 'Sim',
        },
        {
          value: false,
          label: 'Não',
        },
        
      ];

      const atividadeVet = [
        {
          value: true,
          label: 'Sim',
        },
        {
          value: false,
          label: 'Não',
        },
        
      ];

      const dominateVet = [
        {
          value: 0,
          label: 'Esquerdo',
        },
        {
          value: 1,
          label: 'Direito',
        },
        
      ];      

      const token = localStorage.getItem('token');   
     
  
      const authorization = {
          headers: {
              'Authorization' : `Bearer ${token}`
          }
      }

      //Formatacao da data
     const opcao = {
        year:"numeric",
        month:"numeric",
        day:"numeric"
    }
    var url_atual =''
    useEffect(() =>{
        if (avaliacaoId === '0') {
           return; 
        } else {
          url_atual = window.location.href;
          if (url_atual === `http://localhost:3000/avaliacao/editar/${avaliacaoId}`) {
            loadAvaliacao();
          }
          else{
            loadPaciente();            
          }

          api.get('api/Funcionarios', authorization)
            .then(response => {setFuncionario(response.data);
            },token)
          
        }
    }, [])

    async function loadPaciente(){
        try {
            const response = await api.get(`api/pacientes/${avaliacaoId}`, authorization);
            
            setIdPaciente(response.data.id);
            setNomePaciente(response.data.nome);
            setIdade(response.data.idade);
            setDataNasci(new Date(response.data.dataNascimento).toLocaleDateString("pt-br", opcao));

            //agendamento
            setIdAgendamento(response.data.agendamento.idAgendamento);
            setDataAgendamento(response.data.agendamento.dataAgendamento);
            

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
          const response = await api.get(`api/avaliacao/${avaliacaoId}`, authorization);
          
          setId(response.data.id);          
          setNomeFuncionario(response.data.nomeFuncionario);
          setIdFuncionario(response.data.idFuncionario);
          setIdPaciente(response.data.idPaciente);          
          setNomePaciente(response.data.nomePaciente);
          setIdade(response.data.idade);
          setDataNasci(new Date(response.data.dataNascimento).toLocaleDateString("pt-br", opcao));
          setDataAvaliacao(new Date(response.data.dataAvaliacao).toLocaleDateString("pt-br", opcao));
          setNomeMedico(response.data.nomeMedico);
          setCrm(response.data.registroMedico);
          //setComboFunc
          setDiagnostico(response.data.diagnostico);
          setAltura(response.data.altura);
          setPeso(response.data.peso);
          setHma(response.data.hma);
          setComobirdades(response.data.comobirdades);
          setMedicacaoEmUso(response.data.medicacaoEmUso);
          setMedicacaoLesao(response.data.medicacaoLesao);
          setDorme(response.data.dormeBem);
          setFuma(response.data.fuma);
          setMdominante(response.data.membroDominante);
          setHistoricoLesao(response.data.historicoLesao);
          setCirurgia(response.data.cirurgia);
          setAtividade(response.data.praticaAtividadeFisica);
          setAvaliacaoPostural(response.data.avaliacaoPostural);
          setMembrosAtivos(response.data.membrosAtivos);
          setMembrosPassivos(response.data.membrosPassivos);
          setTesteFuncionais(response.data.testesFuncionais)
          setTestesEspeciais(response.data.testesEspeciais);
          setOutrasObservacoes(response.data.outrasObservacoes);
          setCondutaCurtoPrazo(response.data.condutaCurtoPrazo);
          setCondutaMedioPrazo(response.data.condutaMedioPrazo);
          setCondutaLongoPrazo(response.data.condutaLongoPrazo);
          

          
          

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
    

    async function saveOrUpdate(event){

        event.preventDefault();  
        
        var select = document.getElementById("id-fisio").textContent;      
        var nomeFuncionario = select;
        var nomeFunciorio = select;  
        var idFuncionario = comboFunc;
        //var idPaciente = id;
        var pendenteAvaliacao = 1;
        //var nomePaciente = nome;
        


        
        
        const atualizaAgendamento = {
            idAgendamento,
            idFuncionario,
            nomeFunciorio,
            idPaciente,
            nomePaciente,
            dataAgendamento,            
            pendenteAvaliacao
        }

        var agenda = document.getElementById("id-data-avaliacao").value;
        var [dia,mes,ano] = agenda.split("/");
        //var dataFull = new Date(agenda).toISOString();
        // //const regex =  /^([0-9]{4})-(0[1-9]|1[0-2])-(0[1-9]|2[0-9]|3[0-1])/
        // const regex =  /^([0-9]{4})-(0[1-9]|2[0-9]|3[0-1])-(0[1-9]|1[0-2])/
        // [full, ano,dia,mes] = regex.exec(dataFull);
            
        var dataAvaliacao = `${ano}-${mes}-${dia}T03:00:00.000Z`;       
        

        const data = {

            idFuncionario,
            nomeFuncionario,
            idPaciente,     
            nomePaciente,
            dataAvaliacao, 
            nomeMedico,
            registroMedico,            
            peso,
            altura,
            diagnostico,
            hma,
            comobirdades,
            medicacaoEmUso,
            medicacaoLesao,
            dorme,
            fuma,            
            membroDominante,
            historicoLesao,            
            cirurgia,           
            atividade,            
            avaliacaoPostural,
            membrosAtivos,
            membrosPassivos,
            testesEspeciais,
            testesFuncionais,
            outrasObservacoes,
            condutaCurtoPrazo,
            condutaMedioPrazo,
            condutaLongoPrazo            
                     
           

        }

        console.log(data);
        
        try {

          url_atual = window.location.href;
          

          if (url_atual === `http://localhost:3000/avaliacao/editar/${avaliacaoId}`) {
            
            data.id = id;
            await api.put(`api/avaliacao/${avaliacaoId}`, data ,authorization);
            alert('Agendamento Atualizado com sucesso!')
          }
          else{            
            
            await api.post('/api/avaliacao', data, authorization);          
            
            await api.put(`api/agendamento/${idAgendamento}`, atualizaAgendamento ,authorization);
            alert('Agendamento incluido com sucesso!')
          }        
            

        } catch (error) {
            alert('Erro ao gravar Avaliacao' + error);
        }

        navigate('/avaliacao');
    }


    return(

        <Box sx={{ display: 'flex' }}>
        <MenuAppBar />
        <div className="center-datagrid-novaAvaliacao"> 
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
        <Link className="back-link" to="/avaliacao">
            <FiCornerDownLeft size="25" color="#17202a"/>
            Voltar
        </Link>
        <h4>Avaliacao</h4>
        {/* <h5>{avaliacaoId === '0'? 'Incluir Paciente': 'Atualizar Paciente'}</h5>                */}
        
                
        <TextField
          disabled
          id="id-nome"
          label="Nome:"
          placeholder="Nome completo"          
          variant="standard"
          name="nome"
          value={nomePaciente}
          onChange={e => setNome(e.target.value)}
        />
       
        <TextField
          disabled
          id="id-idade"
          label="Idade:"
          placeholder="Idade"          
          variant="standard"
          name="idade"
          value = {idade}
          onChange={e => setIdade(e.target.value)}
          
        />
        
        <TextField
          disabled
          id="id-data-nascimento"
          label="Data Nascimento:"
          placeholder="DD/MM/YYYY"          
          variant="standard"
          name="dataNascimento"
          value = {dataNasci}
          onChange={e => setDataNasci(e.target.value)}
        />
        {url_atual === `http://localhost:3000/avaliacao/editar/${avaliacaoId}`?
        <TextField
          disabled
          id="id-data-avaliacao"
          label="Data Avaliacao:"
          placeholder="DD/MM/YYYY"          
          variant="standard"
          name="dataAvaliacao"
          value = {dataAvaliacao}
          onChange={agendaChange}
        />
        :
        <TextField
        required
        id="id-data-avaliacao"
        label="Data Avaliacao:"
        placeholder="DD/MM/YYYY"          
        variant="standard"
        name="dataAvaliacao"
        //value = {dataAvaliacao}
        onChange={e =>setDataAvaliacao(e.target.value)}
        />
        }
        <TextField
          required
          id="nome-medico"
          label="Médico:"
          placeholder="Dr Jose da silva"                 
          variant="standard"
          name="medico"
          value={nomeMedico}
          onChange={e => setNomeMedico(e.target.value)}
        />
        <TextField
          required
          id="id-registro-medico"
          label="Registro Médico:"
          placeholder="CRM - 9999"          
          variant="standard"
          name="registro"
          value={registroMedico}
          onChange={e => setCrm(e.target.value)}
        />
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
          
          id="id-peso"
          label="Peso:"
          placeholder="Ex: 90"          
          variant="standard"
          name="peso"
          value={peso}
          onChange={e => setPeso(e.target.value)}
        />
        <TextField
          
          id="id-altura"
          label="Altura:"
          placeholder="Ex: 1,70"          
          variant="standard"
          name="altura"
          value={altura}
          onChange={e => setAltura(e.target.value)}
        />

        <TextField
          required
          id="id-diagnostico"
          label="Diagnostico:"
                  
          variant="standard"
          name="diagnostico"
          value={diagnostico}
          onChange={e => setDiagnostico(e.target.value)}
        />

        <TextField
          required
          id="id-hma"
          label="HMA:"                  
          variant="standard"
          name="HMA"
          value={hma}
          onChange={e => setHma(e.target.value)}
        />
        <TextField
          required
          id="id-comorbidades"
          label="Comorbidades:"                  
          variant="standard"
          name="comorbidades"
          value={comobirdades}
          onChange={e => setComobirdades(e.target.value)}
        />
        <TextField
          required
          id="id-medicacoes"
          label="Medicações em Uso:"                  
          variant="standard"
          name="medicacoes"
          value={medicacaoEmUso}
          onChange={e => setMedicacaoEmUso(e.target.value)}
        />
        <TextField
          required
          id="id-medicacoes-lesao"
          label="Medicações relacionada Lesão:"                  
          variant="standard"
          name="medicoes-lesao"
          value={medicacaoLesao}
          onChange={e => setMedicacaoLesao(e.target.value)}
        />
        <div>
            <TextField
            id="id-dorme"
            select
            label="Dorme Bem?"
            value={dorme}
            onChange={dormeChange}
            helperText="Sim ou não"
            variant="standard"
            >
            {dormeVet.map((option) => (
                <MenuItem key={option.value} value={option.value} name="dorme"
                //onChange={funcionarioChange}
                >
                {option.label} 
                </MenuItem>
            ))}

            </TextField>

            <TextField
            id="id-fuma"
            select
            label="Fuma?"
            value={fuma}
            onChange={fumaChange}
            helperText="Sim ou não"
            variant="standard"
            >
            {fumaVet.map((option) => (
                <MenuItem key={option.value} value={option.value} name="fuma"
                //onChange={funcionarioChange}
                >
                {option.label} 
                </MenuItem>
            ))}

            </TextField>

            <TextField
            id="id-dominante"
            select
            label="Membro Dominante?"
            value={membroDominante}
            onChange={dominanteChange}
            helperText="Esquerdo ou direito"
            variant="standard"
            >
            {dominateVet.map((option) => (
                <MenuItem key={option.value} value={option.value} name="fuma"
                //onChange={funcionarioChange}
                >
                {option.label} 
                </MenuItem>
            ))}

            </TextField>

            <TextField
            id="id-lesao"
            select
            label="Histórico Lesão?"
            value={historicoLesao}
            onChange={lesaoChange}
            helperText="Sim ou não"
            variant="standard"
            >
            {lesaoVet.map((option) => (
                <MenuItem key={option.value} value={option.value} name="lesao"
                //onChange={funcionarioChange}
                >
                {option.label} 
                </MenuItem>
            ))}

            </TextField>

            <TextField
            id="id-cirurgia"
            select
            label="Cirurgia?"
            value={cirurgia}
            onChange={cirurgiaChange}
            helperText="Sim ou não"
            variant="standard"
            >
            {cirurgiaVet.map((option) => (
                <MenuItem key={option.value} value={option.value} name="cirurgia"
                //onChange={funcionarioChange}
                >
                {option.label} 
                </MenuItem>
            ))}

            </TextField>

            <TextField
            id="id-atividade-fisica"
            select
            label="Pratica Atividade física?"
            value={atividade}
            onChange={atividadeChange}
            helperText="Sim ou não"
            variant="standard"
            >
            {atividadeVet.map((option) => (
                <MenuItem key={option.value} value={option.value} name="atividade"
                //onChange={funcionarioChange}
                >
                {option.label} 
                </MenuItem>
            ))}

            </TextField>
            
        </div>
        {/* <FormGroup>
            <FormControlLabel control={<Checkbox defaultChecked />} label="Ativo" name="situacao"
          onChange={e => setSituacao(e.target.value)} 
          id= "id-situacao"/>            
        </FormGroup>      */}
            
        
      </div>
      <div>
      <br/><h5>Complementos</h5>
      <TextField
          required
          id="id-avaliacao-postural"
          label="Avaliação Postural:"
          placeholder="Avaliação da postura"          
          variant="standard"
          name="avaliacao-postural"
          value={avaliacaoPostural}
          onChange={e => setAvaliacaoPostural(e.target.value)}
        />
        
        <TextField
          required
          id="id-membros-ativos"
          label="Membros Ativos:"
          placeholder="Membros Ativos"          
          variant="standard"
          name="membros-ativos"
          value={membrosAtivos}
          onChange={e => setMembrosAtivos(e.target.value)}
        />

        <TextField
          required
          id="id-membros-passivo"
          label="Membros Passivos:"
          placeholder="Membros Passivos"          
          variant="standard"
          name="membros-passivos"
          value={membrosPassivos}
          onChange={e => setMembrosPassivos(e.target.value)}
        />

        <TextField
          required
          id="id-testes-especiais"
          label="Testes especiais:"
          placeholder="Testes especiais"          
          variant="standard"
          name="testes-especiais"
          value={testesEspeciais}
          onChange={e => setTestesEspeciais(e.target.value)}
        />

        <TextField
          required
          id="id-testes-funcionais"
          label="Testes Funcionais:"
          placeholder="Testes funcionais"          
          variant="standard"
          name="testes-funcionais"
          value={testesFuncionais}
          onChange={e => setTesteFuncionais(e.target.value)}
        />
        <TextField
          required
          id="id-outras-observações"
          label="Outras Observações:"
          placeholder="Outras Observações"          
          variant="standard"
          name="outras-observações"
          value={outrasObservacoes}
          onChange={e => setOutrasObservacoes(e.target.value)}
        />
        
         <TextField
          required
          id="id-conduta-curto"
          label="Conduta de Curto Prazo:"
          placeholder="Conduta curto prazo"          
          variant="standard"
          name="conduta-curto"
          value={condutaCurtoPrazo}
          onChange={e => setCondutaCurtoPrazo(e.target.value)}
        />
        <TextField
          required
          id="id-conduta-medio"
          label="Conduta de Médio Prazo:"
          placeholder="Conduta médio prazo"          
          variant="standard"
          name="conduta-medio"
          value={condutaMedioPrazo}
          onChange={e => setCondutaMedioPrazo(e.target.value)}
        />
        <TextField
          required
          id="id-conduta-longo"
          label="Conduta de Longo Prazo:"
          placeholder="Conduta Longo prazo"          
          variant="standard"
          name="conduta-longo"
          value={condutaLongoPrazo}
          onChange={e => setCondutaLongoPrazo(e.target.value)}
        />
      </div>      
      <div>
        <Stack direction="row" spacing={2}>
            <Button variant="contained" type="submit">Incluir</Button> 
            <Button variant="contained" color="error" onClick={() => navigate('/avaliacao')}>Cancelar</Button>           
            
        </Stack>
      </div>
        
    </Box>
    </div>
    </Box>
    )
}