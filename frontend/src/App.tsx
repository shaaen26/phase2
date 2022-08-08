import React from 'react';
import './App.css';
import { useState } from 'react';
import { TextField, Button } from '@mui/material';
import SearchIcon from "@mui/icons-material/Search";

function App() {

  const [ipAddress, setIpAddress] = useState('');
  const [locationInfomation, setLocationInfomation] = useState<null | object>({});

  

  const search = () => {};

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

    </div>
  );
}

export default App;
