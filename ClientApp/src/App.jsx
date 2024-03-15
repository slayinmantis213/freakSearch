import React from "react";
import { Navigate, Routes, Route, BrowserRouter } from "react-router-dom";
import Search from "./components/Search/Search.jsx";
import NavBar from "./components/NavBar/NavBar.jsx";
import "./App.css";

function App() {
  //todo look into router

  return (
    <div className="App">
      <NavBar />
      <Routes>
        <Route path="/" element={<Navigate to="/search" />} />
        <Route path="/search" element={<Search />} />
        <Route path="/hosts" element={<div>Hosts</div>} />
        <Route path="/guests" element={<div>Guests</div>} />
        <Route path="/topics" element={<div>Topics</div>} />
      </Routes>
    </div>
  );
}

export { App };
