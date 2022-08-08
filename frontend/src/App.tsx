import React from 'react';
import './App.css';
import { useState } from 'react';
import { TextField, Button, Paper, Box } from '@mui/material';
import SearchIcon from "@mui/icons-material/Search";
import axios from "axios";

function App() {

  const [ipAddress, setIpAddress] = useState('');
  const [locationInfomation, setLocationInfomation] = useState<undefined | any>(undefined);

  

  const search = () => {

    if (ipAddress === "") {
      setLocationInfomation(undefined);
      return;
    }

    axios.get(`https://api.apilayer.com/ip_to_location/${ipAddress}`, {
      headers: {
        "apikey": "pyjfzLbYtSHxSVGPW4OJ1foS7KiCvD1I"
      }
    }).then((res) => {
      console.log("SUCCESS")
      console.log(res.data);
      setLocationInfomation(res.data);
    }).catch(() => {
      setLocationInfomation(null);
    })

  };

  const getLocationBackColor = () => {
    if (locationInfomation === null) {
      return 'white';
    } else {
      // set object variables to repersent each continent color
      const continentColor = {
        'Africa': 'red',
        'Asia': 'yellow',
        'Europe': 'blue',
        'North America': 'green',
        'Oceania': 'purple',
        'South America': 'orange',
      };
      
      // get continent name from locationInfomation object
      const continentName = locationInfomation['continent_name'];

      if (continentName === "Africa") {
        return "red";
      } else if (continentName === "Asiz") {
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
        return "white";
      }
    }
  }

  return (
    <div>
      <div className='searchPart'>
        <h1>Search Ip Location</h1>
        <div className="searchInputPart">
          <TextField 
          id="searchIp"
          label="Enter Ip Address..."
          variant="standard"
          value={ipAddress}
          onChange={(e) => setIpAddress(e.target.value)}
          size="medium"
        />
          <Button variant='text'onClick={() => search()}>
            <SearchIcon className="searchIcon" />
          </Button>
        </div>
      </div>
      {locationInfomation === undefined ? (
        <div className="locationPart">Please input ip address to search</div>
      ) : (
        <div className="locationPart">
          <Paper sx={{backgroundColor: getLocationBackColor()}}>
            <Box sx={{display: 'flex', flexDirection: 'column', alignItems: 'center', justifyContent: 'center', p: 1}}>
              {
                locationInfomation.city === "-" ? (
                  <h2>Location information not found</h2>
                ) :
                (
                  // loop through the locationInfomation object and display each key and value
                  <h2>{locationInfomation.city}</h2>  
                )
              }
            </Box>
          </Paper>
        </div>
      )}
    </div>
  );
}

export default App;
