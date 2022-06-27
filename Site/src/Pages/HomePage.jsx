import React, { useEffect, useState } from "react";
import HomePageContent from "../Components/HomePageContent";
import { Spinner } from "react-bootstrap";
import SiteRepository from "../API/SiteRepository";

const HomePage = () => {
  const [slides, setSlides] = useState(null);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    async function fetchData() {
      setSlides((await SiteRepository.GetSlides()).slides);
      setIsLoading(false);
    }
    fetchData();
  }, []);

  return (
    <>
      {isLoading ? (
        <Spinner animation="grow" variant="info" />
      ) : (
        <HomePageContent data={slides} />
      )}
    </>
  );
};

export default HomePage;
