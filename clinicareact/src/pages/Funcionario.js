import React, {useState, useEffect} from 'react';
import { FuncionarioService } from '../api/FuncionarioService';
import {Button, Modal, ModalBody, ModalFooter, ModalHeader} from 'reactstrap';
import "react-datepicker/dist/react-datepicker.css";
import DatePicker from "react-datepicker";

import { useNavigate } from 'react-router-dom';
import { Stack } from '@mui/material';


export const Funcionario = () => {
    
  const [data, setData] = useState([]);
  const [modalIncluir, setModalIncluir] = useState(false);

  const [funcionarioSelecionado, setFuncionarioSelecionado] =  useState({
    id:'',
    nome:''
  })

  const abrirFecharIncluir= () =>{
    setModalIncluir(!modalIncluir);
  }

  const [selectedDate, setSelectedDate] = useState(null);

  const handleChange = e =>{
    const {name, value} = e.target;
    setFuncionarioSelecionado({
      ...funcionarioSelecionado,
      [name]:value
    });
    console.log(funcionarioSelecionado);
  }

  const editarFuncionario =(funcionario, opcao) =>{
      setFuncionarioSelecionado(funcionario);
      (opcao === "Editar") && navigate('/EditarFuncionario')
  }

  const funcionarioGet = async()=>{
    await FuncionarioService.getFuncionarios()
    .then(response => {
      setData(response.data);
    }).catch(error=>{
      console.log(error);
    })
  }
  const funcionarioPost = async()=>{
    delete funcionarioSelecionado.id;

    await FuncionarioService.getFuncionarios(funcionarioSelecionado)
    .then(response => {
      setData(data.concat(response.data));
      abrirFecharIncluir();
    }).catch(error=>{
      console.log(error);
    })
  }

  useEffect(()=>{
    funcionarioGet();
  })

  const navigate = useNavigate();
  return (

    <><br /><h4>Cadastro de funcionarios</h4><br/>
    
    <header>
      <div>
        <Stack direction="row" spacing={2}>
            <Button variant="contained" color="success" onClick={() => navigate('/NovoFuncionario')}>Novo Funcionário</Button>       
        </Stack>
      </div>      
    </header><br/>

    <table className="table table-bordered">
        <thead>
          <tr>
            <th>Id</th>
            <th>Nome</th>
          </tr>
        </thead>
        <tbody>

          {data.map(funcionario => (
            <tr key={funcionario.id}>
              <td>{funcionario.id}</td>
              <td>{funcionario.nome}</td>
              <td>
                <button className="btn btn-primary"  onClick={() => editarFuncionario(funcionario, "Editar")}> Editar</button>{" "}
                <button className="btn btn-danger" onClick={() => editarFuncionario(funcionario, "Excluir")}> Excluir</button>
              </td>
            </tr>

          ))}

        </tbody>
      </table><Modal isOpen={modalIncluir} className="modal-dialog modal-lg">
        <ModalHeader>Cadastrar Funcionários</ModalHeader>
        <ModalBody>

          <form class="row gx-3 gy-2 align-items-center">
            <div class="col-md-6">
              <label for="inputNome" class="fcol-sm-2 col-form-label col-form-label-sm">Nome:</label>
              <input type="text" class="form-control form-control-sm form-control form-control-sm-sm" id="inputNome" />
            </div>
            <div class="col-md-1">
              <label for="inputNome" class="fcol-sm-2 col-form-label col-form-label-sm">Idade:</label>
              <input type="text" class="form-control form-control-sm form-control form-control-sm-sm" id="inputNome" />
            </div>
            <div class="col-md-2">
              <label for="inputDataNascimento" class="fcol-sm-2 col-form-label col-form-label-sm">Data Nascimeno</label>
              <DatePicker
                selected={selectedDate}
                onChange={date => selectedDate(date)}
                className="form-control form-control-sm"
                id="dataNascimento"
                placeholderText="dd/mm/yyyy"
                type="text" />
            </div>
            <div class="col-md-2">
              <label for="inputDataNascimento" class="fcol-sm-2 col-form-label col-form-label-sm">RG</label>
              <input type="text" class="form-control form-control-sm" id="inputDataNascimento" />
            </div>
            <div class="col-1">
              <div class="form-check">
                <input class="form-check-input" type="checkbox" id="gridCheck" />
                <label class="fcol-sm-2 col-form-label col-form-label-sm" for="gridCheck">
                  Ativo
                </label>
              </div>
            </div>
            <div class="col-md-3">
              <label for="inputDataNascimento" class="ffcol-sm-2 col-form-label col-form-label-sm">CPF:</label>
              <input type="text" class="form-control form-control-sm" id="inputDataNascimento" />
            </div>
            <div class="col-md-3">
              <label for="inputTelefone" class="ffcol-sm-2 col-form-label col-form-label-sm">Telefone:</label>
              <input type="text" class="form-control form-control-sm" id="inputTelefone" />
            </div>
            <div class="col-md-3">
              <label for="inputTelefone" class="ffcol-sm-2 col-form-label col-form-label-sm">Celular:</label>
              <input type="text" class="form-control form-control-sm" id="inputTelefone" />
            </div>
            <div class="col-md-3">
              <label for="inputProfissao" class="ffcol-sm-2 col-form-label col-form-label-sm">Profissao:</label>
              <input type="text" class="form-control form-control-sm" id="inputProfissao" />
            </div>
            <fieldset class="row mb-0">
              <legend class="col-form-label col-sm-0 pt-0">Sexo:</legend>
              <div class="col-sm-10">
                <div class="form-check">
                  <input class="form-check-input" type="radio" name="gridRadios" id="gridRadios1" value="option1" checked />
                  <label class="form-check-label" for="gridRadios1">
                    Masculino
                  </label>
                </div>
                <div class="form-check">
                  <input class="form-check-input" type="radio" name="gridRadios" id="gridRadios2" value="option2" />
                  <label class="form-check-label" for="gridRadios2">
                    Feminino
                  </label>
                </div>
              </div>
            </fieldset>
            <div class="col-md-3">
              <label for="inputTelefone" class="ffcol-sm-2 col-form-label col-form-label-sm">Nome Convênio:</label>
              <input type="text" class="form-control form-control-sm" id="inputTelefone" />
            </div>
            <div class="col-md-4">
              <label for="inputTelefone" class="ffcol-sm-2 col-form-label col-form-label-sm">Númeo Convênio:</label>
              <input type="text" class="form-control form-control-sm" id="inputTelefone" />
            </div>
            <div class="col-md-6">
              <label for="inputAddress" class="fcol-sm-2 col-form-label col-form-label-sm">Endereço</label>
              <input type="text" class="form-control form-control-sm" id="inputAddress" placeholder="Rua Exemplo 150" />
            </div>
            <div class="col-md-1">
              <label for="inputTelefone" class="ffcol-sm-2 col-form-label col-form-label-sm">Número:</label>
              <input type="text" class="form-control form-control-sm" id="inputTelefone" />
            </div>
            <div class="col-md-5">
              <label for="inputComplemento" class="fcol-sm-2 col-form-label col-form-label-sm">Complemento:</label>
              <input type="text" class="form-control form-control-sm" id="inputComplemento" placeholder="Apartamento 302" />
            </div>
            <div class="col-md-6">
              <label for="inputCity" class="fcol-sm-2 col-form-label col-form-label-sm">Cidade:</label>
              <input type="text" class="form-control form-control-sm" id="inputCity" />
            </div>
            <div class="col-md-4">
              <label for="inputState" class="fcol-sm-2 col-form-label col-form-label-sm">Estado</label>
              <select id="inputState" class="form-select">
                <option selected>Selecione...</option>
                <option>...</option>
              </select>
            </div>
            <div class="col-md-2">
              <label for="inputZip" class="fcol-sm-2 col-form-label col-form-label-sm">CEP</label>
              <input type="text" class="form-control form-control-sm" id="inputZip" />
            </div>

            <div class="col-md-3">
              <label for="inputNome" class="fcol-sm-2 col-form-label col-form-label-sm">Usuário:</label>
              <input type="text" class="form-control form-control-sm form-control form-control-sm-sm" id="inputNome" />
            </div>
            <div class="col-md-3">
              <label for="inputNome" class="fcol-sm-2 col-form-label col-form-label-sm">Senha:</label>
              <input type="password" class="form-control form-control-sm form-control form-control-sm-sm" id="inputNome" />
            </div>

          </form>

        </ModalBody>
        <ModalFooter>
          <button className="btn btn-primary"> Incluir</button>{" "}
          <button className="btn btn-danger" onClick={() => abrirFecharIncluir()}> Cancelar</button>
        </ModalFooter>
      </Modal></>

  )

};
