import React, {useState} from 'react';
import { EpisodesSearch } from "./components/EpisodesSearch.tsx";
import { Result } from "./components/Result.tsx";
import { Search } from "./components/Search/Search.tsx";
import Stack from '@mui/material/Stack';
import './custom.css';


function App() {
  const [hasResult, setHasResult] = useState(false);
  const [result, setResult] = useState([]);

  //todo look into router
  
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
    <Stack spacing={2} justifyContent="center" alignItems="center" sx={{minWidth:0}}>
    {hasResult && result.map((result, index) => (
                    <Result key={index} result={result} />
                ))}
    </Stack>
  </div>
}

export { App };