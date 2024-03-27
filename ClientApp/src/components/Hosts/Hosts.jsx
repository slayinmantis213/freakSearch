import React, { useEffect, useState } from "react";
import HostCard from "./HostCard";
import "../../custom.css";

const listOfHosts = [
  {
    name: "Florence Pugh",
    description: "Florence Pugh description",
    episodeCount: 20,
    mostRecentEpisode: "How to die in a fire",
    link: "https://www.google.com",
    episodeList: [
      "Episode 1",
      "Episode 2",
      "Episode 3",
      "Episode 4",
      "Episode 5",
    ],
  },
  {
    name: "Franz Ferdinand",
    description: "Franz Ferdinand description",
    episodeCount: 10,
    mostRecentEpisode: "Max Payne was pretty weak tbh",
    link: "https://www.google.com",
    episodeList: [
      "Episode 1",
      "Episode 2",
      "Episode 3",
      "Episode 4",
      "Episode 5",
    ],
  },
  {
    name: "Sarah McLachlan",
    description: "Sarah McLachlan description",
    episodeCount: 15,
    mostRecentEpisode: " I ate shellfish and I liked it",
    link: "https://www.google.com",
    episodeList: [
      "Episode 1",
      "Episode 2",
      "Episode 3",
      "Episode 4",
      "Episode 5",
    ],
  },
  {
    name: "Jesse_Pinkman",
    description: "Jesse Pinkman description",
    episodeCount: 5,
    mostRecentEpisode: "I am the one who knocks",
    link: "https://www.google.com",
    episodeList: [
      "Episode 1",
      "Episode 2",
      "Episode 3",
      "Episode 4",
      "Episode 5",
    ],
  },
  {
    name: "Gary Newman",
    description: "Gary Newman description",
    episodeCount: 10,
    mostRecentEpisode: "The terrible case of the measles",
    link: "https://www.google.com",
    episodeList: [
      "Episode 1",
      "Episode 2",
      "Episode 3",
      "Episode 4",
      "Episode 5",
    ],
  },
  {
    name: "Walter Chroncite",
    description: "Description",
    episodeCount: 5,
    mostRecentEpisode: "Do you know where your children are?",
    link: "https://www.google.com",
    episodeList: [
      "Episode 1",
      "Episode 2",
      "Episode 3",
      "Episode 4",
      "Episode 5",
    ],
  },
];

const Hosts = () => {
  const [data, setData] = useState([]);
  const [loaded, setLoaded] = useState(false);
  useEffect(() => {
    const url = 'https://localhost:7099/api/Episode/hosts'
    console.log(`gonna fetch ${url}`)
    fetch(url)
    .then(res => res.json())
    .then(data => { setData(data); console.log(data); })
    .catch(err => console.error(err))
    setLoaded(true);
  }, []);

  return (
    <>
      <h1>Hosts</h1>
      <div className="host-list">
        {
          loaded ?
            data.map( e => <HostCard key={e.id} name={e.name} /> )
            :
            "loading..."
        }
      </div>
    </>
  );
};

export default Hosts;
