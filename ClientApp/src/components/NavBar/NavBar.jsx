import { Button, ButtonGroup } from "@mui/material";
import React from "react";

const NavBar = () => {
  return (
    <>
      <ButtonGroup
        sx={{ marginTop: 10, marginBottom: 5 }}
        variant="contained"
        aria-label="Navigation buttons"
      >
        <Button href="/search">Episodes</Button>
        <Button href="/hosts">Hosts</Button>
        <Button href="/guests">Guests</Button>
        {/* <Button href="/topics">Topics</Button> */}
      </ButtonGroup>
    </>
  );
};

export default NavBar;
