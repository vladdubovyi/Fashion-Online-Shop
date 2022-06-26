import React from "react";
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import Slide from "./Slide";
import summerImage from "../../../Images/MainPage/Slider/sample1.png";

const HomeSlider = () => {
  var settings = {
    dots: true,
    infinite: true,
    speed: 500,
    slidesToShow: 1,
    slidesToScroll: 1,
  };
  return (
    <div className="slider-container">
      <Slider {...settings}>
        <Slide
          header={"Summer collection"}
          text={"Fall-Winter Collection 2022"}
          buttonText={"Shop now!"}
          buttonLink={"/Shop"}
          img={summerImage}
        />
        <div>
          <h3>2</h3>
        </div>
      </Slider>
    </div>
  );
};

export default HomeSlider;
