import './App.css';
import { useEffect, useState } from 'react'

function App() {
  const [dadosPessoais, setDadosPessoais] = useState([])
  const [enderecos, setEnderecos] = useState([])
  const [cep, setCep] = useState([])
  const [endereco1, setEndereco] = useState([])
  const [cidade, setCidade] = useState([])
  const [estado, setEstado] = useState([])
  const [numero, setNumero] = useState([])
  const [complemento, setComplemento] = useState([])
  const [nome, setNome] = useState([])
  const [sobrenome, setSobrenome] = useState([])
  const [cpf, setCpf] = useState([])
  const [dataNascimento, setDataNascimento] = useState([])
  const [idEndereco, setIdEndereco] = useState([])

  const requestApiGetDados = () => {
    fetch("http://localhost:5000/DadosPessoais")
      .then((value) => value.json())
      .then((data) => setDadosPessoais(data))
  }

  const requestApiGetAdrress = () => {
    fetch("http://localhost:5000/Endereco")
      .then((value) => value.json())
      .then((data) => setEnderecos(data))
  }

  const requestApiPostData = () => {
    const newData = { nome, sobrenome, cpf, dataNascimento, idEndereco }
    console.log(newData)

    if ((cpf.length > 11 || cpf.length < 11) || (idEndereco.length === 0)) {
      alert("Preencha corretamente os campos")
    } else {

      fetch("http://localhost:5000/DadosPessoais", {
        body: JSON.stringify({ nome, sobrenome, cpf, dataNascimento, idEndereco }),
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        }
      })
        .then((value) => value.json())
        .then(() => window.location.reload())
      alert("Cadastro realizado com sucesso")
    }
  }

  const requestApiPostAdrress = () => {
    const newadrress = { cep, endereco1, cidade, estado, numero, complemento }
    console.log(newadrress)

    if ((cep.length > 8 || cpf.length < 8) && (endereco1.length === 0)) {
      alert("Preencha corretamente os campos")
    } else {
      fetch("http://localhost:5000/Endereco", {
        body: JSON.stringify({ cep, endereco1, cidade, estado, numero, complemento }),
        method: "POST",
        headers: {
          "Content-Type": "application/json"
        }
      })
        .then((value) => value.json())
        .then(() => document.location.reload())
      alert("Cadastro realizado com sucesso")
    }
  }

  useEffect(() => {
    requestApiGetDados()
    requestApiGetAdrress()
  }, [])

  const formatarData = (dateNascimento) => {
    let dataemdate = new Date(dateNascimento);
    let dataFormatada = ((dataemdate.getDate())) + "/" + ((dataemdate.getMonth() + 1)) + "/" + dataemdate.getFullYear();
    return (dataFormatada);
  }


  return (
    <div className="App">
      <div className="CadastroGeral">
        <div className="cadastro">
          <h1>Cadastre seu Endereço</h1>
          <label>Cep</label>
          <input type={"text"} onChange={(event) => setCep(event.target.value)} />

          <label>Endereco</label>
          <input type={"text"} onChange={(event) => setEndereco(event.target.value)} />

          <label>Estado</label>
          <input type={"text"} onChange={(event) => setEstado(event.target.value)} />

          <label>Cidade</label>
          <input type={"text"} onChange={(event) => setCidade(event.target.value)} />

          <label>numero</label>
          <input type={"text"} onChange={(event) => setNumero(event.target.value)} />

          <label>complemento</label>
          <input type={"text"} onChange={(event) => setComplemento(event.target.value)} />

          <button onClick={() => requestApiPostAdrress()}>Cadastrar</button>
        </div>

        <div className="cadastro">
          <h1>Cadastre seus Dados DadosPessoais</h1>
          <label>Nome</label>
          <input type="text" onChange={(event) => setNome(event.target.value)} />

          <label>Sobrenome</label>
          <input type="text" onChange={(event) => setSobrenome(event.target.value)} />

          <label>Cpf</label>
          <input type="text" onChange={(event) => setCpf(event.target.value)} />

          <label>Data Nascimento</label>
          <input type="date" onChange={(event) => setDataNascimento(event.target.value)} />

          <label>Id do Seu Endereço</label>
          <input type="text" onChange={(event) => setIdEndereco(event.target.value)} />

          <button onClick={() => requestApiPostData()}>Cadastrar</button>

        </div>
      </div>


      <div className="Tabelas">
        <h1>DadosPessoais</h1>
        <div className="table">
          {
            dadosPessoais && dadosPessoais.map((e, i) => {
              return (
                <div key={i} className="tabela">
                  <p><b>Nome: </b>{e.nome}</p>
                  <p><b>Sobrenome: </b>{e.sobrenome}</p>
                  <p><b>Cpf: </b>{e.cpf}</p>
                  <p><b>Data de Nascimento: </b>{formatarData(e.dataNascimento)}</p>
                  <p><b>Cep: </b>{e.idEnderecoNavigation.cep}</p>
                  <p><b>Endereço: </b>{e.idEnderecoNavigation.endereco1}</p>
                  <p><b>Numero: </b>{e.idEnderecoNavigation.numero}</p>
                  <p><b>Cidade: </b>{e.idEnderecoNavigation.cidade}</p>
                  <p><b>Estado: </b>{e.idEnderecoNavigation.estado}</p>
                  <p><b>Complemento: </b>{e.idEnderecoNavigation.complemento}</p>
                </div>
              )
            })
          }
        </div>
        <h1>Endereços</h1>
        <div className="table">
          {
            enderecos && enderecos.map((e, i) => {
              return (
                <div key={i} className="tabela">
                  <p><b>IdEndereço: </b>{e.idEndereco}</p>
                  <p><b>Cep: </b>{e.cep}</p>
                  <p><b>Endereço: </b>{e.endereco1}</p>
                  <p><b>Numero: </b>{e.numero}</p>
                  <p><b>Cidade: </b>{e.cidade}</p>
                  <p><b>Estado: </b>{e.estado}</p>
                  <p><b>Complemento: </b>{e.complemento}</p>
                </div>
              )
            })
          }
        </div>
      </div>
    </div>
  );
}

export default App;
