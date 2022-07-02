import React from "react";
import { Spinner } from "react-bootstrap";

const Loader = ({ variant, animation }) => {
  return (
    <div className="loaredWrapper">
      <Spinner animation={animation} variant={variant} className="spinner" />
    </div>
  );
};

export default Loader;
