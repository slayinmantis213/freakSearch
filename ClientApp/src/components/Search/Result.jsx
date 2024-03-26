import React, { Component } from "react";
import Paper from "@mui/material/Paper";
import Link from "@mui/material/Link";

const Result = (props) => {
  const { result } = props;

  return (
    <Paper elevation={3} sx={{ maxWidth: 850, padding: 2 }}>
      <h3>
        <Link href={result.link} target="_blank" rel="noreferrer">
          {result.episodeNumber}
        </Link>
      </h3>
      <h4>{result.title}</h4>
      <h5>{result.id}</h5>
      <Paper elevation={0} sx={{ padding: 2 }}>
        Summary: {result.summary}
      </Paper>
      <Paper elevation={3} sx={{ padding: 2 }}>
        Excerpt: {result.highlight}
      </Paper>
    </Paper>
  );
};

export default Result;
