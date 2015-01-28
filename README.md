# EDRoutePlanner
Elite Dangerous Route Planner

## Running
Requirements:
* .NET Framework 3.5+ or Mono
* Commodities Data from (currently) Cmdr's Log, either version will suffice
* (optional, but recommended for profit calculation) Station Trade data from Cmdr's Log 1.x or RegulatedNoise

Tested with version 1.6b (2.1b) of Cmdr's Log and version 1.83 of RegulatedNoise. Other versions might break compatibility.

Running:
After launching the application, go to the defaults on the top right of the main screen and set your data paths.
The files you should be looking for are:
* For Cmdr's Log (1.x + 2.x) commodities data: "default_commodity_data.txt"
* For Cmdr's Log (1.x) station data: "system_data.txt"
* For RegulatedNoise station data: "AutoSave.csv"

## Known issues
* I am pretty sure that the commodity names do not match between Cmdr's Log 1.x and RegulatedNoise. Please report any issues you have with that!
* Due to the way RegulatedNoise saves its data (manually or on quit) the autoloading feature does not really do anything, as the data file never changes unless closing & restarting RegulatedNoise.
  * Workaround:
  * You can manually save your data file using the button "Save Unified CSV" whenever you change anything.
  * Save it to the same file every time and select that file in EDRoutePlanner as source for the station data. (You can also save to the AutoSave.csv - that way you will also get the most recent data when you close RegulatedNoise)

## Contributing
Contributions are welcome at any point!

Software/Languages used:
* Visual Studio 2008 Standard
* C# on .NET 3.5 Client Profile
The project should be compatible with the Express versions for C# and of course newer versions of Visual Studio.
If you work with a newer version please take care not to commit incompatible stuff when creating a pull request...


## License
Copyright 2015 Oliver Kahrmann

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
