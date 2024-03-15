import React, { useState } from "react";
import { Stack } from "@mui/material";
import { Result } from "./Result.tsx";
import { Input } from "@mui/material";
import { Button } from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";

const Search = () => {
  const [hasResult, setHasResult] = useState(false);
  const [result, setResult] = useState([]);
  const searchButtonClicked = () => {
    const query = document.getElementById("searchInput").value;
    fetch(
      "https://localhost:7099/api/Episode/search?query=" +
        encodeURIComponent(query)
    )
      .then((response) => response.json())
      .then((data) => {
        // returns an array of episode objects with the following properties:
        // id, title, episodeNumber, summary, link, transcript
        setResult(data);
        console.log(data);
      })
      .catch((error) => {
        // Handle any errors here
        console.error(error);
      });
    setHasResult(true);
    // TODO make a search route that puts the search terms inside the URL
    // TODO read up on why form or Input leads to a specific URL
  };
  return (
    <>
      <form onSubmit={searchButtonClicked}>
        <Input
          sx={{ marginBottom: 10 }}
          type="text"
          autoFocus={true}
          id="searchInput"
          name="searchInput"
        />

        <Button type="button" onClick={searchButtonClicked}>
          <SearchIcon />
        </Button>
      </form>

      <Stack spacing={2} justifyContent="center" alignItems="center" sx={{}}>
        {hasResult &&
          result.map((result, index) => <Result key={index} result={result} />)}
      </Stack>
    </>
  );
};

export default Search;
