import React from "react";
import { Container, Nav, Navbar } from "react-bootstrap";
import { BsSuitHeart, BsFillBagFill, BsFillPersonFill } from "react-icons/bs";
import logo from "../Images/Logo_black.png";

const AppNavbar = () => {
  return (
    <Navbar collapseOnSelect expand="lg" bg="light">
      <Container>
        <Navbar.Brand href="/">
          <img
            alt=""
            src={logo}
            width="50"
            height="50"
            className="d-inline-block align-top"
          />{" "}
          Clothkolibry
        </Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto d-flex flex-row">
            <Nav.Link href="/" className="p-2">
              Home
            </Nav.Link>
            <Nav.Link href="/Shop" className="p-2">
              Shop
            </Nav.Link>
            <Nav.Link href="/AboutUs" className="p-2">
              About us
            </Nav.Link>
            <Nav.Link href="/Contacts" className="p-2">
              Contacts
            </Nav.Link>
          </Nav>

          <Nav className="d-flex flex-row">
            <Nav.Link href="/Profile" className="profile p-2">
              <BsFillPersonFill />
            </Nav.Link>
            <Nav.Link href="/Heart" className="heart p-2">
              <BsSuitHeart />
            </Nav.Link>
            <Nav.Link href="/Cart" className="cart p-2">
              <BsFillBagFill />
            </Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default AppNavbar;
