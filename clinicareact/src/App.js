import React, {useState} from 'react';

export default function App() {
  const [posts, setPosts] = useState([]);

  function getPosts(){
    const baseURL = "https://localhost:5001/api/Funcionarios";

    fetch(baseURL,{
      method:'GET'
    })
    .then(response => response.json())
    .then(postsFromServer =>{
      console.log(postsFromServer);
      setPosts(postsFromServer);
    })
    .catch((error) => {
      console.log(error);
      alert(error);
    });
  }

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-colums justify-content-center align-items-center">
          <div>
            <h1>Cadastro funcionario</h1>
            <div className="mt-5">
              <button onClick={getPosts} className="btn btn-dark btn-lg w-100"> Busca servidor</button>
              <button onClick={() => {}} className="btn btn-secondary btn-lg w-100 mt-4">Novo</button>
            </div> 
          </div>  


          {renderPostsTable()}
        </div>   
      </div>       
    </div>
  );

  function renderPostsTable(){
    return(
      <div className="table-responsive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">Chave</th>
              <th scope="col">Id</th>
              <th scope="col">Nome</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <th scope="row">1</th>
              <td>1</td>              
              <td>Anderson</td>
            </tr>
        </tbody>     
        </table>
        

      </div>

    );
  }
}



