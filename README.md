# CandidateMS_API

PostgreSQL database gonfigured locally, a local setup of postgres will be required for this project.

Update the application.json file connection string with your local postgreSQl instance:

  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=postgres;Username=postgres;Password=P@ssword"
  }

Once that is setup just run the entity framwork migration:

`dotnet ef database update`

That should build a code first approach for the entities

then run the api and fe together.

Mock login UserName: admin, Password: P@ssword
