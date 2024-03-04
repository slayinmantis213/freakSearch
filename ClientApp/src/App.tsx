import React, {useState} from 'react';
import { EpisodesSearch } from "./components/EpisodesSearch.tsx";
import { Result } from "./components/Result.tsx";
import { Search } from "./components/Search/Search.tsx";

function App() {
  const [hasResult, setHasResult] = useState(false);
  const [result, setResult] = useState([]);
  const searchButtonClicked = () => {
    const query = (document.getElementById('searchInput') as HTMLInputElement).value;
    fetch("https://localhost:7099/api/Episode/search?query=" + encodeURIComponent(query))
        .then(response => response.json())
        .then(data => {
            // returns an array of episode objects with the following properties: 
            // id, title, episodeNumber, summary, link, transcript
            setResult(data);
            console.log(data);
        })
        .catch(error => {
            // Handle any errors here
            console.error(error);
        });
    setHasResult(true);
  }

  return <div className='App'>
    {/* <EpisodesSearch /> */}
    <Search searchButtonClicked={searchButtonClicked}/>
    {hasResult && result.map((result, index) => (
                    <Result key={index} result={result} />
                ))}
  </div>
}

export { App };