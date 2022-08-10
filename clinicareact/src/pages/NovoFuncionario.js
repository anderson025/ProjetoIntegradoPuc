import * as React from 'react';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import MenuItem from '@mui/material/MenuItem';
import Button from '@mui/material/Button';
import Stack from '@mui/material/Stack';
import { useNavigate } from 'react-router-dom';
import FormGroup from '@mui/material/FormGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import axios from 'axios';

import { useState } from 'react';
import { Alert } from '@mui/material';

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
const BASE_URL = 'https://localhost:44365/api/funcionarios';
export const NovoFuncionario = () => {

const [currency, setCurrency] = React.useState('0');
const [data, setData] = useState([]);

  const handleChange = (event) => {
    setCurrency(event.target.value);
  };

  const [sexo, setSexo] = React.useState('0');

  const sexoChange = (event) => {
    setSexo(event.target.value);
  };
      
const navigate = useNavigate();

// var enderecoNovo = {
//     rua: '',
//         numero: '',
//         bairro: '',
//         cep: '',
//         cidade: '',
//         estado: '',
//         uf: ''
// }
var funcionario = {
    
    "nome": null,
    "dataNascimento": null,
    "idade": null,
    "rg":null,
    "cpf":null,
    "sexo": null,
    "situacao": true,
    "telefone": null,
    "celular": null,
    "profissao": null,
    "convenio": null,
    "carteiraConvenio": null,
    "endereco": {
      "rua": null,
      "numero": null,
      "bairro": null,
      "cep": null,
      "cidade": null,
      "estado": null,
      "uf": null
    },
   
    "email": null,
    "usuario": null,
    "senha":null
}


function onSave() {
    funcionario.nome =document.getElementById("id-nome").value;
    funcionario.dataNascimento = "2022-08-01T23:29:40.719Z";
    funcionario.idade = document.getElementById("id-idade").value;
    funcionario.rg = document.getElementById("id-rg").value;
    funcionario.cpf = document.getElementById("id-cpf").value;
    funcionario.sexo = document.getElementById("id-sexo").value;
    funcionario.situacao = document.getElementById("id-situacao").value;
    funcionario.telefone = document.getElementById("id-telefone").value;
    funcionario.celular = document.getElementById("id-celular").value;
    funcionario.profissao = document.getElementById("id-profissao").value;
    funcionario.convenio = document.getElementById("id-convenio").value;
    funcionario.carteiraConvenio = document.getElementById("id-carteira-convenio").value;
    funcionario.endereco.rua = document.getElementById("id-rua").value;
    funcionario.endereco.numero = document.getElementById("id-numero").value;
    funcionario.endereco.bairro = document.getElementById("id-bairro").value;
    funcionario.endereco.cep = document.getElementById("id-cep").value;
    funcionario.endereco.cidade = document.getElementById("id-cidade").value;
    funcionario.endereco.estado = document.getElementById("id-estado").value;
    funcionario.endereco.uf = document.getElementById("id-uf").value;
    funcionario.email = document.getElementById("id-email").value;
    funcionario.usuario = document.getElementById("id-usuario").value;
    funcionario.senha = document.getElementById("id-senha").value;
    console.log(funcionario);
}

const [enderecoSelecionado, setEnderecoSelecionado] = useState({
    
    rua: '',
    numero: '',
    bairro: '',
    cep: '',
    cidade: '',
    estado: '',
    uf: ''
})


const [funcionarioSelecionado, setFuncionarioSelecionado] = useState({
    
    nome: '',
    dataNascimento:'',
    idade: '',
    rg: '',
    cpf: '',
    sexo: 0,
    situacao: true,
    telefone: '',
    celular: '',
    profissao: 0,
    convenio: '',    
    carteiraConvenio:'', 
    endereco:{
        rua: '',
        numero: '',
        bairro: '',
        cep: '',
        cidade: '',
        estado: '',
        uf: ''
    },          
    email: '',
    usuario: '',
    senha:''
})

const funcionarioChange = (e) =>{

    let nome = e.target.name;
    let valor = e.target.value;
    setFuncionarioSelecionado({
        ...funcionarioSelecionado,[nome]:valor                                
    }); 
}

const enderecoChange = (e) =>{
    let nome = e.target.name;
    let valor = e.target.value;
    setEnderecoSelecionado({
        ...enderecoSelecionado,[nome]:valor             
    }); 
          
}



const pedidoPost= async()=>{
    onSave();
    //funcionarioSelecionado.dataNascimento = "2022-08-01T23:29:40.719Z";
    // funcionario.endereco.numero = parseInt(funcionarioSelecionado.endereco.numero)
    await axios.post(BASE_URL, funcionario)
        .then(response =>{
            setData(data.concat(response.data))
            Alert("Sucesso", response.data.mensagem)
        }).catch(error =>{
            console.log(error);
        })

}

return (   
    <div>
        {/* <div>
            <p>{JSON.stringify(funcionarioSelecionado)}</p>
        </div> */}
        {/* <div>
            <p>{JSON.stringify(enderecoSelecionado)}</p>
        </div> */}
    <Box
      component="form"
      sx={{
        '& .MuiTextField-root': { m: 1, width: '25ch' },
      }}
      noValidate
      autoComplete="off"
    >      
        
      <div>
        <h5>Dados cadastrais</h5>       
       
        <TextField
          required
          id="id-nome"
          label="Nome:"
          placeholder="Nome completo"          
          variant="standard"
          name="nome"
          onChange={funcionarioChange}
        />
       
        <TextField
          required
          id="id-idade"
          label="Idade:"
          placeholder="Idade"          
          variant="standard"
          name="idade"
          onChange={funcionarioChange}
          
        />
        
        <TextField
          required
          id="id-data-nascimento"
          label="Data Nascimento:"
          placeholder="DD/MM/YYYY"          
          variant="standard"
          name="dataNascimento"
          onChange={funcionarioChange}
        />
        <TextField
          required
          id="id-rg"
          label="Identidade:"
          placeholder="16.522.333"          
          variant="standard"
          name="rg"
          onChange={funcionarioChange}
        />
        <TextField
          required
          id="id-cpf"
          label="CPF:"
          placeholder="999.999.999-99"          
          variant="standard"
          name="cpf"
          onChange={funcionarioChange}
        />
        <TextField          
          id="id-telefone"
          label="Telefone:"
          placeholder="3455-0055"          
          variant="standard"
          name="telefone"
          onChange={funcionarioChange}
        />
        <TextField
          required
          id="id-celular"
          label="Celular:"
          placeholder="99855-5544"          
          variant="standard"
          name="celular"
          onChange={funcionarioChange}
        />

        <TextField
          id="id-profissao"
          select
          label="Profissão"
          value={currency}
          onChange={handleChange}
          helperText="Selecione a profissão"
          variant="standard"
         
        >
          {currencies.map((option) => (
            <MenuItem key={option.value} value={option.value} name="rg"
            onChange={funcionarioChange}>
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
            onChange={funcionarioChange} >
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
          onChange={funcionarioChange}
        />
        <FormGroup>
            <FormControlLabel control={<Checkbox defaultChecked />} label="Ativo" name="situacao"
          onChange={funcionarioChange} id= "id-situacao"/>            
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
          onChange={funcionarioChange}
        />
        <TextField
          required
          id="id-carteira-convenio"
          label="Número Convênio:"
          placeholder="1231456"          
          variant="standard"
          name="carteiraConvenio"
          onChange={funcionarioChange}
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
          onChange={enderecoChange}
          
        />
        <TextField
          id="id-numero"
          label="Número:"  
          placeholder="Número"         
          variant="standard"
          name = "numero"
          onChange={funcionarioChange}
        />

        <TextField
          required
          id="id-bairro"
          label="Bairro:"
          placeholder="Bairro"          
          variant="standard"
          name="bairro"
          onChange={funcionarioChange}
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
          onChange={funcionarioChange}
        />
         <TextField
          required
          id="id-cidade"
          label="Cidade:"
          placeholder="Belo Horizonte"          
          variant="standard"
        />

        <TextField
          required
          id="id-estado"
          label="Estado:"
          placeholder="Minas Gerais"          
          variant="standard"
          name="estado"
          onChange={funcionarioChange}
        />

        <TextField
          required
          id="id-uf"
          label="UF:"
          placeholder="Brasil"          
          variant="standard"
          name="uf"
          onChange={funcionarioChange}
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
          onChange={funcionarioChange}
        />
        <TextField
          id="id-senha"
          label="Senha"
          type="password"
          autoComplete="current-password"
          variant="standard"
          name="senha"
          onChange={funcionarioChange}
        />
      </div>

      <div>
        <Stack direction="row" spacing={2}>
            <Button variant="contained" onClick={() => pedidoPost()}>Salvar</Button> 
            <Button variant="contained" color="error" onClick={()=> navigate('/funcionarios')}>Cancelar</Button>           
            
        </Stack>
      </div>
        
    </Box>
        
    </div>
    )
};
