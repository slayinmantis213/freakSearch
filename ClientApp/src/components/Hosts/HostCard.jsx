import React from "react";
import { Card, CardContent, Typography } from "@mui/material";
import { Route, Link } from "react-router-dom";

const HostCard = (props) => {
  return (
    <Link to={`/${props.name}`} style={{ textDecoration: "none" }}>
      <Card
        className="host-card"
        sx={{
          display: "flex",
          flexDirection: "column",
          justifyContent: "center",
          alignItems: "center",
          width: "100%",
          minWidth: "272.09px",
          height: "100%",
          padding: "1rem",
          margin: "1rem",
        }}
      >
        <CardContent>
          <Typography variant="h5">{props.name}</Typography>
          <Typography variant="body1">
            Episodes: {props.episodeCount}
          </Typography>
        </CardContent>
      </Card>
    </Link>
  );
};

export default HostCard;
