# WillTech - Data Analysis (Datalog Review)

The "datalogging" idea came about when with my race car's aftermatket ECU and software, it's quite pooor to view the datalog files. So, with my custom race dash I decided to implement a datalogging feature to save to CSV. I then needed something to view the data and anaylsis at the track/home, so here we are!

The application will ship in 2 different states.
- Free: Allows the user to utilise the datalog feature
- Paid: Allows the user to do live telemetry from the car to a laptop in the pits or home. This will be added to the Free variant.

### Project setup - Settings file
- The application utilises the `AppSettingsDatalogReview.json` file for application settings. An exaple file can be found in `\WT-DataAnalysis\WT-DataAnalysis-DatalogReview\Examples.json`.
- The application utilises the `AppSettingsLiveTelemetry.json` file for application settings. An exaple file can be found in `\WT-DataAnalysis\WT-DataAnalysis-DatalogReview\Examples.json`.

It will need to be placed in the build directory, e.e. `\WT-DataAnalysis\WT-DataAnalysis\Shared`, to be loaded in.