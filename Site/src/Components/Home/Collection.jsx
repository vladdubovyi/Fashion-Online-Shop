import React from "react";

const Collection = ({ name, img }) => {
  return (
    <>
      <img src={img} />
      <h2>{name}</h2>
      <a href="/Shop">
        <p>Shop now</p>
      </a>
    </>
  );
};

export default Collection;
