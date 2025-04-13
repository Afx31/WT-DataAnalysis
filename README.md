# WillTech - Data Analysis (Datalog Review)

The view for the 'datalogging' functionality in my racecars aftermarket ECU chip's softare is a bit iffy to use, found it a bit janky to inspect the log in various ways..

So with that, I decided to implement a datalogging feature in my 'WT - Race Dash' which stores it to a `.csv` file. I've then built a 'Data Analysis' application which reads in that file and allows the user to inspect the data in depth.

*Feature/spec list to come*

The application will ship in 2 different states.
- Free: Allows the user to utilise the datalog feature
- Paid: Allows the user to do live telemetry from the car to a laptop in the pits or home. This will be added to the Free variant.

### Project setup - Settings file

The application stores settings config in `AppSettingsDatalogReview.json`.
- If none exist, a blank settings file is created automatically in the build directory
- An example file can be found in `/WT-DataAnalysis/WT-DataAnalysis-DatalogReview/Examples/AppSettingsDatalogReview.json`
