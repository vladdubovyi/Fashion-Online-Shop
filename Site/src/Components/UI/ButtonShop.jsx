import React from "react";

const ButtonShop = ({ buttonLink, buttonText = "Shop now!" }) => {
  return (
    <a className="button" href={buttonLink}>
      <p>{buttonText}</p>
    </a>
  );
};

export default ButtonShop;
