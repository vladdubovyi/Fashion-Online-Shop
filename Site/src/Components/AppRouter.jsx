import React from "react";
import { Redirect, Route, Routes } from "react-router-dom";
import HomePage from "../Pages/HomePage";
import ShopPage from "../Pages/ShopPage";
import AboutUsPage from "../Pages/AboutUsPage";
import ContactsPage from "../Pages/ContactsPage";

const AppRouter = () => {
  return (
    <Routes>
      <Route path="/" element={<HomePage />} />
      <Route path="/Shop" element={<ShopPage />} />
      <Route path="/AboutUs" element={<AboutUsPage />} />
      <Route path="/Contacts" element={<ContactsPage />} />
    </Routes>
  );
};

export default AppRouter;
