import React from "react";
import { useLocation, useParams } from "react-router-dom";

const HostPage = () => {
  const location = useLocation();
  // TODO: if no location.state, useParams to get the info about the person,
  // TODO:  otherwise just use the state props
  // location.state
  //   ? console.log("location.state:", location.state)
  //   : console.log("NO LOCATION STATE");

  const params = useParams();
  const { episodeList, name } = location.state;
  return (
    <>
      <div>{name}</div>
      {episodeList.map((episode, index) => (
        <div key={index}>{episode}</div>
      ))}
    </>
  );
};

export default HostPage;
