import { useEffect, useState } from "react";
import { FuncionarioService } from "../api/FuncionarioService";

export const Paciente = () => {

    const [data, setData] = useState([]);

    const pacienteGet = async()=>{
        await FuncionarioService.getPaciente()
        .then(response => {
          setData(response.data);
        }).catch(error=>{
          console.log(error);
        })
      }

      useEffect(()=>{
        pacienteGet();
      })
   
    return(
         <div>
             <h1>Pagina Paciente</h1>
             <table className="table table-bordered">
        <thead>
          <tr>
            <th>id</th>
            <th>Nome</th>            
          </tr>
        </thead>
        <tbody>

          {data.map(paciente => (
            <tr key={paciente.id}>
              <td>{paciente.id}</td>
              <td>{paciente.nome}</td>   
                          
              <td>
                <button className="btn btn-primary"> Editar</button>{" "}
                <button className="btn btn-danger"> Excluir</button>
              </td>
            </tr>

          ))}

        </tbody>
        </table>
         </div>
     )
 };
