import React from "react";
import { Container, Nav, Navbar } from "react-bootstrap";
import { BsSearch, BsSuitHeart, BsFillBagFill } from "react-icons/bs";

const AppNavbar = () => {
  return (
    <Navbar>
      <Container>
        <Navbar.Brand href="/">Clothkolibry</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav>
            <Nav.Link href="/">Home</Nav.Link>
            <Nav.Link href="/Shop">Shop</Nav.Link>
            <Nav.Link href="/AboutUs">About us</Nav.Link>
            <Nav.Link href="/Contacts">Contacts</Nav.Link>
          </Nav>
        </Navbar.Collapse>
        <Nav>
          <Nav.Link href="/Search" className="search">
            <BsSearch />
          </Nav.Link>
          <Nav.Link href="/Heart" className="heart">
            <BsSuitHeart />
          </Nav.Link>
          <Nav.Link href="/Cart" className="cart">
            <BsFillBagFill />
          </Nav.Link>
        </Nav>
      </Container>
    </Navbar>
  );
};

export default AppNavbar;
