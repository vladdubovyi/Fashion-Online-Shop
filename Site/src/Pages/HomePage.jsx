import React, { useEffect, useState } from "react";
import HomePageContent from "../Components/HomePageContent";
import SiteRepository from "../API/SiteRepository";
import Loader from "../Components/UI/Loader";

const HomePage = () => {
  const [slides, setSlides] = useState(null);
  const [collections, setCollections] = useState(null);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    async function fetchData() {
      setSlides(await SiteRepository.GetSlides());
      setCollections(await SiteRepository.GetCollections());
      setIsLoading(false);
    }
    fetchData();
  }, []);

  return (
    <>
      {isLoading ? (
        <Loader animation="grow" variant="info" />
      ) : (
        <HomePageContent
          data={{ slides: slides.slides, collections: collections.collections }}
        />
      )}
    </>
  );
};

export default HomePage;
