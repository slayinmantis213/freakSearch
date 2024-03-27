import React, { useEffect, useState } from "react";
import HostCard from "../Hosts/HostCard";

const Guests = () => {
  const [data, setData] = useState([]);
  const [loaded, setLoaded] = useState(false);
  useEffect(() => {
    const url = "https://localhost:7099/api/Episode/guests";
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
      <h1>Guests</h1>
      <div className="host-list">
        {loaded
          ? data.map((e) => (
              <HostCard
                key={e.guest.id}
                name={e.guest.name}
                episodeCount={e.episodes.length}
                episodeList={e.episodes}
              />
            ))
          : "loading..."}
      </div>
    </>
  );
};

export default Guests;
