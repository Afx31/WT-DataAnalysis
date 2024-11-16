# WillTech - Data Analysis

The "datalogging" view with my race cars aftermarket ECU software is pretty poor, so with my custom race dash I decided to implement a datalogging feature to save to CSV. I then needed something to view the data and anaylsis at the track/home, so here we are!

### Project setup - Settings file

The application utilises the `AppSettings.json` file for application settings. An example file can be found in `WT-DataAnalysis/Examples/AppSettings.json`. It will be need be placed in the build directory, e.g. `WT-DataAnalysis/bin/Debug/net8.0-windows/` to be loaded in. Might change this one day