import { MainMenu } from "./MainMenu";
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';

const Header = () => {
  return (
    <Navbar bg="info" expand="lg">
    <Container>
      <Navbar.Brand href="#home">Sistema de gerenciamento de clinica</Navbar.Brand>
      <Navbar.Toggle aria-controls="basic-navbar-nav" />
      <Navbar.Collapse id="basic-navbar-nav">
        <Nav className="me-auto">
          <Nav.Link href="#home">Cadastro de Paciente</Nav.Link>
          <Nav.Link href="#link">Avaliação</Nav.Link>
          <NavDropdown title="Cadastros" id="basic-nav-dropdown">
            <NavDropdown.Item href="#action/3.1">Funcionarios</NavDropdown.Item>
            <NavDropdown.Item href="#action/3.2">Sessão</NavDropdown.Item>
            <NavDropdown.Item href="#action/3.3">Evolução diaria</NavDropdown.Item>
            <NavDropdown.Divider />
            <NavDropdown.Item href="#action/3.4">Separated link</NavDropdown.Item>
          </NavDropdown>
        </Nav>
      </Navbar.Collapse>
    </Container>
  </Navbar>
  );
}

export default Header;
