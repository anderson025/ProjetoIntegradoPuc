import axios from "axios";

const BASE_URL = 'https://localhost:44365';
const withBaseUrl = path => `${BASE_URL}${path}`;

export class FuncionarioService {

    static getFuncionarios(){
        return axios(withBaseUrl('/api/Funcionarios'));
    }
}
