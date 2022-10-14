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


export default function NovoFuncionario (){

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
const [usuario, setUsuario] = useState(''); 
const [senha, setSenha] = useState(''); 
const [enderecoId, setEnderecoId] = useState(''); 

const [sexo, setSexo] = useState(0);
const [profissao, setProfissao] = useState(0);
const {funcionarioId} = useParams();

const navigate = useNavigate();

  const sexoChange = (event) => {
    setSexo(event.target.value);
  };
    

    const sexoVet = [
        {
          value: '0',
          label: 'Masculino',
        },
        {
          value: '1',
          label: 'Feminino',
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

    useEffect(() =>{
        if (funcionarioId === '0') {
           return; 
        } else {
            loadFuncionario();
        }
    }, [])

    //Formatacao da data
    const opcao = {
      year:"numeric",
      month:"numeric",
      day:"numeric"
    }

    async function loadFuncionario(){
        try {
            const response = await api.get(`api/funcionarios/${funcionarioId}`, authorization);

            setId(response.data.id);
            setNome(response.data.nome);
            setIdade(response.data.idade);
            setDataNasci(new Date(response.data.dataNascimento).toLocaleDateString("pt-br", opcao));
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
            setUsuario(response.data.usuario);
            setSenha(response.data.senha);
            setEnderecoId(response.data.enderecoId);

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
        
        var nascimento = document.getElementById("id-data-nascimento").value;
        var [dia,mes,ano] = nascimento.split("/");   
            
        var dataNascimento = `${ano}-${mes}-${dia}T03:00:00.000Z`;       
        
        

        const data = {

            nome,
            dataNascimento,
            idade,            
            rg,
            cpf,
            sexo,
            situacao,
            telefone,
            celular,            
            profissao,
            convenio,
            carteiraConvenio,
            endereco:{
                rua,
                numero,
                bairro,
                cep,
                cidade,
                estado,
                uf
            },
            email,            
            usuario,
            senha

        }

        const dataAtualiza = {
          id,
          nome,
          dataNascimento,
          idade,            
          rg,
          cpf,
          sexo,
          situacao,
          telefone,
          celular,            
          profissao,
          convenio,
          carteiraConvenio,
          endereco:{
              rua,
              numero,
              bairro,
              cep,
              cidade,
              estado,
              uf
          },
          enderecoId,
          email,            
          usuario,
          senha

      }
       

        try {
            
            if (funcionarioId ==='0') {
                
                await api.post('/api/Funcionarios', data, authorization);
                alert('Funcionario cadastrado com sucesso!');
                navigate('/funcionarios');
            }
            else{
                                               
                await api.put(`api/Funcionarios/${id}`,dataAtualiza,authorization);
                alert('Funcionario atualizado com sucesso!');
                navigate('/funcionarios');
            }

        } catch (error) {

          if(error.message.includes("401")){
            localStorage.clear();
            localStorage.setItem('token', '');                        
            navigate('/');
          }
          else{
            alert('Erro ao gravar funcionario' + error);
          }
            
        }

        
    }

    return(


        <Box sx={{ display: 'flex' }}>
        <MenuAppBar />
        <div className="center-datagrid-funcionarios"> 
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
        <Link className="back-link" to="/funcionarios">
            <FiCornerDownLeft size="25" color="#17202a"/>
            Voltar
        </Link>
        <h5>{funcionarioId === '0'? 'Incluir Funcionario': 'Atualizar Funcionario'}</h5>               
       
        <TextField
          required
          id="id-nome"
          label="Nome:"
          placeholder="Nome completo"          
          variant="standard"
          name="nome"
          value={nome}
          onChange={e => setNome(e.target.value)}
        />
       
        <TextField
          required
          id="id-idade"
          label="Idade:"
          placeholder="Idade"          
          variant="standard"
          name="idade"
          value = {idade}
          onChange={e => setIdade(e.target.value)}
          
        />
        
        <TextField
          required
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
          id="id-rg"
          label="Identidade:"
          placeholder="16.522.333"          
          variant="standard"
          name="rg"
          value={rg}
          onChange={e => setRg(e.target.value)}
        />
        <TextField
          required
          id="id-cpf"
          label="CPF:"
          placeholder="999.999.999-99"          
          variant="standard"
          name="cpf"
          value={cpf}
          onChange={e => setCpf(e.target.value)}
        />
        <TextField          
          id="id-telefone"
          label="Telefone:"
          placeholder="3455-0055"          
          variant="standard"
          name="telefone"
          value={telefone}
          onChange={e => setTelefone(e.target.value)}
        />
        <TextField
          required
          id="id-celular"
          label="Celular:"
          placeholder="99855-5544"          
          variant="standard"
          name="celular"
          value={celular}
          onChange={e => setCelular(e.target.value)}
        />

        <TextField
          id="id-profissao"
          select
          label="Profissão"
          value={profissao}
          onChange={e => setProfissao(e.target.value)}
          helperText="Selecione a profissão"
          variant="standard"
         
        >
          {currencies.map((option) => (
            <MenuItem key={option.value} value={option.value} name="rg"
            //onChange={funcionarioChange}
            >
              {option.label}
            </MenuItem>
          ))}
        </TextField>

        <TextField
          id="id-sexo"
          select
          label="Sexo"
          value={sexo}
          onChange={sexoChange}
          helperText="Selecione o sexo"
          variant="standard"
        >
          {sexoVet.map((option) => (
            <MenuItem key={option.value} value={option.value} name="rg"
            //onChange={funcionarioChange}
            >
              {option.label} 
            </MenuItem>
          ))}

        </TextField>

        <TextField
          required
          id="id-email"
          label="Email:"
          placeholder="exemplo@exemplo.com"          
          variant="standard"
          name="email"
          value={email}
          onChange={e => setEmail(e.target.value)}
        />
        <FormGroup>
            <FormControlLabel control={<Checkbox defaultChecked />} label="Ativo" name="situacao"
          onChange={e => setSituacao(e.target.value)} 
          id= "id-situacao"/>            
        </FormGroup>     
            
        
      </div>
      <div>
      <br/><h5>Convênio</h5>
      <TextField
          required
          id="id-convenio"
          label="Convênio:"
          placeholder="Unimed"          
          variant="standard"
          name="convenio"
          value={convenio}
          onChange={e => setConvenio(e.target.value)}
        />
        <TextField
          required
          id="id-carteira-convenio"
          label="Número Convênio:"
          placeholder="1231456"          
          variant="standard"
          name="carteiraConvenio"
          value={carteiraConvenio}
          onChange={e => setCarteiraConvenio(e.target.value)}
        />
      </div>

      <div>
      <br/><h5>Endereço</h5>
          <TextField
          required
          id="id-rua"
          label="Rua:"
          placeholder="Rua exemplo"          
          variant="standard"
          name= "rua"
          value={rua}
          onChange={e => setRua(e.target.value)}
          
        />
        <TextField
          id="id-numero"
          label="Número:"  
          placeholder="Número"         
          variant="standard"
          name = "numero"
          value={numero}
          onChange={e => setNumero(e.target.value)}
        />

        <TextField
          required
          id="id-bairro"
          label="Bairro:"
          placeholder="Bairro"          
          variant="standard"
          name="bairro"
          value={bairro}
          onChange={e => setBairro(e.target.value)}
        />
        {/* <TextField
          required
          id="id-complemento"
          label="Complemento:"
          placeholder="Apto 302"          
          variant="standard"
          name="complemento"
          onChange={funcionarioChange}
        /> */}

        <TextField
          required
          id="id-cep"
          label="CEP:"
          placeholder="31812-280"          
          variant="standard"
          name="cep"
          value={cep}
          onChange={e => setCep(e.target.value)}
        />
         <TextField
          required
          id="id-cidade"
          label="Cidade:"
          placeholder="Belo Horizonte"          
          variant="standard"
          value={cidade}
          onChange={e => setCidade(e.target.value)}
        />

        <TextField
          required
          id="id-estado"
          label="Estado:"
          placeholder="Minas Gerais"          
          variant="standard"
          name="estado"
          value={estado}
          onChange={e => setEstado(e.target.value)}
        />

        <TextField
          required
          id="id-uf"
          label="UF:"
          placeholder="Brasil"          
          variant="standard"
          name="uf"
          value={uf}
          onChange={e => setUf(e.target.value)}
        />
      </div>

      <div>
      <br/><h5>Dados Login</h5>
      <TextField
          required
          id="id-usuario"
          label="Usuário:"
          placeholder="Novo usuário"          
          variant="standard"
          name="usuario"
          value={usuario}
          onChange={e => setUsuario(e.target.value)}
        />
        <TextField
          id="id-senha"
          label="Senha"
          type="password"
          autoComplete="current-password"
          variant="standard"
          name="senha"
          value={senha}
          onChange={e => setSenha(e.target.value)}
        />
      </div>

      <div>
        <Stack direction="row" spacing={2}>
            <Button variant="contained" type="submit">{funcionarioId === '0'? 'Incluir' : 'Atualizar'}</Button> 
            <Button variant="contained" color="error" onClick={() => navigate('/funcionarios')}>Cancelar</Button>           
            
        </Stack>
      </div>
        
    </Box>
    </div>
    </Box>
    )
}