import axios from "axios";

const BASE_URL = 'https://localhost:44365/api';
const withBaseUrl = path => `${BASE_URL}${path}`;

export class FuncionarioService {

    static getFuncionarios(){
        return axios(withBaseUrl('/Funcionarios'));
    }

    static postFuncionarios(){
        return axios(withBaseUrl('/Funcionarios'));
    }    

    static getPaciente(){
        return axios(withBaseUrl('/Pacientes'));
    }
}
