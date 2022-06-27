import React from "react";
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import Slide from "./Slide";

const HomeSlider = ({ slides }) => {
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
        {slides.map((item) => {
          return (
            <Slide
              header={item.header}
              text={item.text}
              buttonText={item.buttonText}
              buttonLink={item.buttonLink}
              img={require("../../../Images/" + item.imageSrc)}
              key={item.id}
            />
          );
        })}
      </Slider>
    </div>
  );
};

export default HomeSlider;
