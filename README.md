It is a pleasure the opportunity that you offer me to participate in this selection process, sincerely I would like to add more functionalities to this small system, but for time reasons I have limited myself to adding what is requested according to requirements.

The libraries, and the WebApi and WebApp projects use net core 3.1, the application has been designed using multi-layers, assigning different kinds of responsibilities according to each layer, example DAL will take care of the data from the database, BL of the business logic layer, EN the layer of entities or models. The project was separated into different folders Backend and Frontend within the same solution.

The app uses EntityFramework migration, this will auto-create the database without using a database script, at this example the database would be re-create for each time when the app begins to run.

Before start the application, let’s check some file configuration.

appsettings.json in JobBoardApi to change the ConnectionString according to the local database to be used. 

When need to change the Url Api, you can change it in appsettings.json in JobBoardWebApp. 

