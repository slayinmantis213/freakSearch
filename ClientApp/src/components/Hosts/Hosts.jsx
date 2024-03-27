import React, { useEffect, useState } from "react";
import HostCard from "./HostCard";
import "../../custom.css";

const Hosts = () => {
  const [data, setData] = useState([]);
  const [loaded, setLoaded] = useState(false);
  useEffect(() => {
    const url = "https://localhost:7099/api/Episode/hosts";
    console.log(`gonna fetch ${url}`);
    fetch(url)
      .then((res) => res.json())
      .then((data) => {
        setData(data);
        console.log(data);
      })
      .catch((err) => console.error(err));
    setLoaded(true);
  }, []);

  return (
    <>
      <h1>Hosts</h1>
      <div className="host-list">
        {loaded
          ? data.map((e) => (
              <HostCard
                key={e.presenter.id}
                name={e.presenter.name}
                episodeCount={e.episodes.length}
                episodeList={e.episodes}
              />
            ))
          : "loading..."}
      </div>
    </>
  );
};

export default Hosts;
