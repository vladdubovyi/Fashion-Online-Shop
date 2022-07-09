import React from "react";
import CollectionSection from "./Home/CollectionsSection";
import HomeSlider from "./UI/Slider/HomeSlider";

const HomePageContent = ({ data }) => {
  return (
    <>
      <HomeSlider slides={data.slides} />
      <CollectionSection collections={data.collections} />
    </>
  );
};

export default HomePageContent;
