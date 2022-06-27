import React from "react";
import { Container } from "react-bootstrap";
import ButtonShop from "../ButtonShop";

const Slide = ({ header, text, buttonText, buttonLink, img }) => {
  return (
    <div className="slide-wrapper">
      <Container>
        <div className="slide">
          <div className="slide-text-block">
            <div>
              <h1>{header}</h1>
              <h2>{text}</h2>
              <ButtonShop buttonLink={buttonLink} buttonText={buttonText} />
            </div>
          </div>

          <div className="slider-image">
            <img src={img} height="640px;" />
          </div>
        </div>
      </Container>
    </div>
  );
};

export default Slide;
