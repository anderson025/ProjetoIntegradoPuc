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
const [nome, setNome] = useState('');
const [idade, setIdade] = useState('');
const [dataNasci, setDataNasci] = useState('');   
// const [rg, setRg] = useState(''); 
// const [cpf, setCpf] = useState('');
// const [telefone, setTelefone] = useState('');
// const [celular, setCelular] = useState(''); 
// const [email, setEmail] = useState(''); 
// const [situacao, setSituacao] = useState(true); 
// const [convenio, setConvenio] = useState(''); 
// const [carteiraConvenio, setCarteiraConvenio] = useState(''); 
// const [rua, setRua] = useState(''); 
// const [numero, setNumero] = useState(''); 
// const [bairro, setBairro] = useState(''); 
// const [cep, setCep] = useState(''); 
// const [cidade, setCidade] = useState(''); 
// const [estado, setEstado] = useState(''); 
// const [uf, setUf] = useState(''); 
//const [enderecoId, setEnderecoId] = useState(''); 

// const [sexo, setSexo] = useState(0);


const [dorme, setDorme] = useState(true);
const [fuma, setFuma] = useState(true);
const [lesao, setLesao] = useState(true);
const [cirurgia, setCirurgia] = useState(true);
const [atividade, setAtividade] = useState(true);
const [mdominante, setMdominante] = useState(true);
const [profissao, setProfissao] = useState(0);
const {avaliacaoId} = useParams();

const [dataAvaliacao, setDataAvaliacao] = useState('');
const [nameMedico, setNomeMedico] = useState('');
const [crm, setCrm] = useState('');
const [peso, setPeso] = useState('');
const [altura, setAltura] = useState('');
const [diagnostico, setDiagnostico] = useState('');
const [hma, setHma] = useState('');
const [comorbidades, setComorbidades] = useState('');
const [medicacaoEmUso, setMedicacaoEmUso] = useState('');
const [medicacaoRelacionadaLesao, setMedicacaoRelacionadaLesao] = useState('');
const [avaliacaoPostural, setAvaliacaoPostural] = useState('');
const [membrosAtivos, setMembrosAtivos] = useState('');
const [membrosPassivo, setMembrosPassivo] = useState('');
const [testeEspeciais, setTestesEspeciais] = useState('');
const [testeFuncionais, setTesteFuncionais] = useState('');
const [outrasObs, setOutrasObs] = useState('');
const [condutaCurtoPrazo, setCondutaCurtoPrazo] = useState('');
const [condutaMedioPrazo, setCondutaMedioPrazo] = useState('');
const [condutaLongoPrazo, setCondutaLongoPrazo] = useState('');

const [idAgendamento, setIdAgendamento] = useState('');
const [comboFunc, setComboFunc] = useState(1);

const [dataAgendamento, setDataAgendamento] = useState('');

const navigate = useNavigate();

const agendamentoChange = (event) =>{

    var agenda = document.getElementById("id-data-avaliacao").value;
    var dataFull = new Date(agenda).toISOString();
    //const regex =  /^([0-9]{4})-(0[1-9]|1[0-2])-(0[1-9]|2[0-9]|3[0-1])/
    const regex =  /^([0-9]{4})-(0[1-9]|2[0-9]|3[0-1])-(0[1-9]|1[0-2])/
    const [full, ano,dia,mes] = regex.exec(dataFull);
        
    const dataAgendada = `${ano}-${mes}-${dia}T03:00:00.000Z`;
    setDataAvaliacao(dataAgendada);
    
    
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
    setLesao(event.target.value);
  };

  const cirurgiaChange = (event) => {
    setCirurgia(event.target.value);
  };

  const atividadeChange = (event) => {
    setAtividade(event.target.value);
  };

    var funcionarioVet = [
        {
            value: '1',
            label: "Fisioterapeuta 1"
        },
        {
            value: '2',
            label: "Fisioterapeuta 2"
        }
    ];
    

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

      //Formatacao da data
     const opcao = {
        year:"numeric",
        month:"numeric",
        day:"numeric"
    }

    useEffect(() =>{
        if (avaliacaoId === '0') {
           return; 
        } else {
            loadPaciente();
        }
    }, [])

    async function loadPaciente(){
        try {
            const response = await api.get(`api/pacientes/${avaliacaoId}`, authorization);
            
            setId(response.data.id);
            setNome(response.data.nome);
            setIdade(response.data.idade);
            setDataNasci(new Date(response.data.dataNascimento).toLocaleDateString("pt-br", opcao));

            //agendamento
            setIdAgendamento(response.data.agendamento.idAgendamento);
            setDataAgendamento(response.data.agendamento.dataAgendamento);
            

        } catch (error) {
            alert('Erro ao tentar recuperar o Pacientes' + error);
            navigate('/avaliacao');
        }
    }
    

    async function saveOrUpdate(event){

        event.preventDefault();  
        
        var select = document.getElementById("id-fisio").textContent;      
        var nomeFuncionario = select;
        var nomeFunciorio = select;  
        var idFuncionario = comboFunc;
        var idPaciente = id;
        var pendenteAvaliacao = 1;
        var nomePaciente = nome;
        
        const atualizaAgendamento = {
            idAgendamento,
            idFuncionario,
            nomeFunciorio,
            idPaciente,
            nomePaciente,
            dataAgendamento,            
            pendenteAvaliacao
        }

        // const medico = {
        //     nameMedico,
        //     crm 
        // }

        const data = {

            idFuncionario,
            nomeFuncionario,
            idPaciente,     
            nome,
            dataAvaliacao, 
            nameMedico,
            crm,            
            peso,
            altura,
            diagnostico,
            hma,
            comorbidades,
            medicacaoEmUso,
            medicacaoRelacionadaLesao,
            dorme,
            fuma,
            //remover observação fuma
            mdominante,
            lesao,
            //remover do banco a descrição da lesao
            cirurgia,
            //remover obs cirurgia
            atividade,
            //remover obs atividade fisica
            avaliacaoPostural,
            membrosAtivos,
            membrosPassivo,
            testeEspeciais,
            testeFuncionais,
            outrasObs,
            condutaCurtoPrazo,
            condutaMedioPrazo,
            condutaLongoPrazo            
                     
           

        }

       

        try {

           // await api.post('/api/medico', medico, authorization);
            await api.post('/api/avaliacao', data, authorization);
            
           
            await api.put(`api/agendamento/${idAgendamento}`, atualizaAgendamento ,authorization);
            // if (avaliacaoId ==='0') {
                
            //     await api.post('/api/avaliacao', data, authorization);
            // }
            // else{
            //     data.id = id;                               
            //     await api.put(`api/avaliacao/${id}`,data,authorization);
            // }
            alert('Agendamento incluido com sucesso!')

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
          value={nome}
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
        <TextField
          required
          id="id-data-avaliacao"
          label="Data Avaliacao:"
          placeholder="DD/MM/YYYY"          
          variant="standard"
          name="dataAvaliacao"
          //value = {dataNasci}
          onChange={agendamentoChange}
        />
        <TextField
          required
          id="nome-medico"
          label="Médico:"
          placeholder="Dr Jose da silva"                 
          variant="standard"
          name="medico"
        //   value={rg}
          onChange={e => setNomeMedico(e.target.value)}
        />
        <TextField
          required
          id="id-registro-medico"
          label="Registro Médico:"
          placeholder="CRM - 9999"          
          variant="standard"
          name="registro"
        //   value={registro}
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
            {funcionarioVet.map((option) => (
            <MenuItem key={option.value} value={option.value} name="fisio"
                                
            >
             {option.label} 
            </MenuItem>
         ))}

        </TextField>
        <TextField
          
          id="id-peso"
          label="Peso:"
          placeholder="Ex: 90"          
          variant="standard"
          name="peso"
        //   value={celular}
          onChange={e => setPeso(e.target.value)}
        />
        <TextField
          
          id="id-altura"
          label="Altura:"
          placeholder="Ex: 1,70"          
          variant="standard"
          name="altura"
        //   value={celular}
          onChange={e => setAltura(e.target.value)}
        />

        <TextField
          required
          id="id-diagnostico"
          label="Diagnostico:"
                  
          variant="standard"
          name="diagnostico"
        //   value={email}
          onChange={e => setDiagnostico(e.target.value)}
        />

        <TextField
          required
          id="id-hma"
          label="HMA:"                  
          variant="standard"
          name="HMA"
        //   value={email}
          onChange={e => setHma(e.target.value)}
        />
        <TextField
          required
          id="id-comorbidades"
          label="Comorbidades:"                  
          variant="standard"
          name="comorbidades"
        //   value={email}
          onChange={e => setComorbidades(e.target.value)}
        />
        <TextField
          required
          id="id-medicacoes"
          label="Medicações em Uso:"                  
          variant="standard"
          name="medicacoes"
        //   value={email}
          onChange={e => setMedicacaoEmUso(e.target.value)}
        />
        <TextField
          required
          id="id-medicacoes-lesao"
          label="Medicações relacionada Lesão:"                  
          variant="standard"
          name="medicoes-lesao"
        //   value={email}
          onChange={e => setMedicacaoRelacionadaLesao(e.target.value)}
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
            value={mdominante}
            onChange={dominanteChange}
            helperText="Esquerdo ou direito"
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
            id="id-lesao"
            select
            label="Histórico Lesão?"
            value={lesao}
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
        //   value={avalicaoPostural}
          onChange={e => setAvaliacaoPostural(e.target.value)}
        />
        
        <TextField
          required
          id="id-membros-ativos"
          label="Membros Ativos:"
          placeholder="Membros Ativos"          
          variant="standard"
          name="membros-ativos"
        //   value={carteiraConvenio}
          onChange={e => setMembrosAtivos(e.target.value)}
        />

        <TextField
          required
          id="id-membros-passivo"
          label="Membros Passivos:"
          placeholder="Membros Passivos"          
          variant="standard"
          name="membros-passivos"
        //   value={carteiraConvenio}
          onChange={e => setMembrosPassivo(e.target.value)}
        />

        <TextField
          required
          id="id-testes-especiais"
          label="Testes especiais:"
          placeholder="Testes especiais"          
          variant="standard"
          name="testes-especiais"
        //   value={carteiraConvenio}
          onChange={e => setTestesEspeciais(e.target.value)}
        />

        <TextField
          required
          id="id-testes-funcionais"
          label="Testes Funcionais:"
          placeholder="Testes funcionais"          
          variant="standard"
          name="testes-funcionais"
        //   value={carteiraConvenio}
          onChange={e => setTesteFuncionais(e.target.value)}
        />
        <TextField
          required
          id="id-outras-observações"
          label="Outras Observações:"
          placeholder="Outras Observações"          
          variant="standard"
          name="outras-observações"
        //   value={carteiraConvenio}
          onChange={e => setOutrasObs(e.target.value)}
        />
        
         <TextField
          required
          id="id-conduta-curto"
          label="Conduta de Curto Prazo:"
          placeholder="Conduta curto prazo"          
          variant="standard"
          name="conduta-curto"
        //   value={carteiraConvenio}
          onChange={e => setCondutaCurtoPrazo(e.target.value)}
        />
        <TextField
          required
          id="id-conduta-medio"
          label="Conduta de Médio Prazo:"
          placeholder="Conduta médio prazo"          
          variant="standard"
          name="conduta-medio"
        //   value={carteiraConvenio}
          onChange={e => setCondutaMedioPrazo(e.target.value)}
        />
        <TextField
          required
          id="id-conduta-longo"
          label="Conduta de Longo Prazo:"
          placeholder="Conduta Longo prazo"          
          variant="standard"
          name="conduta-longo"
        //   value={carteiraConvenio}
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