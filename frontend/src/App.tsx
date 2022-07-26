import "./App.css";
import { useState } from "react";
import { TextField, Button, Paper, Box } from "@mui/material";
import SearchIcon from "@mui/icons-material/Search";
import axios from "axios";

function App() {
  const [ipAddress, setIpAddress] = useState("");
  const [locationInfomation, setLocationInfomation] = useState<undefined | any>(
    undefined
  );

  const search = () => {
    if (ipAddress === "") {
      setLocationInfomation(undefined);
      return;
    }

    axios
      .get(`https://api.apilayer.com/ip_to_location/${ipAddress}`, {
        headers: {
          apikey: "pyjfzLbYtSHxSVGPW4OJ1foS7KiCvD1I",
        },
      })
      .then((res) => {
        console.log("SUCCESS");
        console.log(res.data);
        setLocationInfomation(res.data);
      })
      .catch(() => {
        setLocationInfomation(null);
      });
  };

  const getLocationBackColor = () => {
    if (locationInfomation === null) {
      return "#FCE2DB";
    } else {
      // set object variables to repersent each continent color
      const continentColor = {
        Africa: "red",
        Asia: "yellow",
        Europe: "blue",
        "North America": "green",
        Oceania: "purple",
        "South America": "orange",
      };

      // get continent name from locationInfomation object
      const continentName = locationInfomation["continent_name"];

      if (continentName === "Africa") {
        return "red";
      } else if (continentName === "Asia") {
        return "yellow";
      } else if (continentName === "Europe") {
        return "blue";
      } else if (continentName === "North America") {
        return "green";
      } else if (continentName === "Oceania") {
        return "purple";
      } else if (continentName === "South America") {
        return "orange";
      } else {
        return "#FCE2DB";
      }
    }
  };

  return (
    <div>
      <div className="searchPart">
        <h1>IP Location Search</h1>
        <div className="searchInputPart">
          <TextField
            id="searchIp"
            label="Enter IP Address..."
            variant="standard"
            value={ipAddress}
            onChange={(e) => setIpAddress(e.target.value)}
            size="medium"
          />

          <Button variant="text" onClick={() => search()}>
            <SearchIcon className="searchIcon" />
          </Button>
        </div>
      </div>
      {locationInfomation === undefined ? (
        <div className="locationPart">Please enter IP address to search</div>
      ) : (
        <div className="locationPart">
          <Paper sx={{ backgroundColor: getLocationBackColor() }}>
            <Box
              sx={{
                display: "flex",
                flexDirection: "column",
                alignItems: "center",
                justifyContent: "center",
                p: 1,
              }}
            >
              {locationInfomation === null ? (
                <h2>Please enter correct IP address</h2>
              ) : locationInfomation.city === "-" ? (
                <h2>Location information not found</h2>
              ) : (
                <div>
                  <h2>{locationInfomation.city}</h2>
                  <p>
                    Country name: {locationInfomation.country_name} <br></br>
                    Continent name: {locationInfomation.continent_name}{" "}
                    <br></br>
                    Latitude: {locationInfomation.latitude} <br></br>
                    Longitude: {locationInfomation.longitude} <br></br>
                  </p>
                </div>
              )}
            </Box>
          </Paper>
        </div>
      )}
    </div>
  );
}

export default App;
