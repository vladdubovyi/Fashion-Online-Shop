import React from "react";
import { Container } from "react-bootstrap";
import Collection from "./Collection";

const CollectionSection = ({ collections }) => {
  return (
    <Container className="pt-5">
      <div className="row">
        {collections.map((item) => {
          return (
            <div className="col collection" key={item.id}>
              <Collection
                name={item.name}
                img={require("../../Images/" + item.imageSrc)}
              />
            </div>
          );
        })}
      </div>
    </Container>
  );
};

export default CollectionSection;
