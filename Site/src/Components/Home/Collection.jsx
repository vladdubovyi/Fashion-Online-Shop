import React from "react";

const Collection = ({ name, img }) => {
  return (
    <>
      <div className="collection collection-2">
        <img src={img} />
        <h2>{name}</h2>
        <a href="/Shop">
          <p>Shop now</p>
        </a>
      </div>
    </>
  );
};

export default Collection;
