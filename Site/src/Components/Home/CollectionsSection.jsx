import React from "react";
import { Container } from "react-bootstrap";
import Collection from "./Collection";

const CollectionSection = ({ collections }) => {
  return (
    <Container className="d-flex justify-content-center">
      {collections.map((item) => {
        return (
          <Collection
            name={item.name}
            img={require("../../Images/" + item.imageSrc)}
            key={item.id}
          />
        );
      })}
    </Container>
  );
};

export default CollectionSection;
