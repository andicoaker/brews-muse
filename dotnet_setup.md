# .NET setup

### Step 1 - Setup project repo (backend student)
1. Project 'Leader': clone the repo
   + https://github.com/chris-nimmons/project
2. Create a new repo, reset the origin, and push to new repo location
3. Add team members as collaborators

### Step 2 - (frontend)

1. Install .NET core 1.0.0
   +  https://github.com/dotnet/cli/releases/tag/v1.0.0-preview2-1-3177
2. Download and alias  openssl
  ```
  brew install openssl
  mkdir -p /usr/local/lib
  ln -s /usr/local/opt/openssl/lib/libcrypto.1.0.0.dylib /usr/local/lib/
  ln -s /usr/local/opt/openssl/lib/libssl.1.0.0.dylib /usr/local/lib/
  ``` 
3. Clone your team's repository
4. Inside the project-repoIn terminal, navigate to `Application/src/Application.web`. 
  Execute: `$ dotnet restore`
   + fetches project dependencies
5. In terminal: `$ dotnet run`
   + Will run the database and a webserver on http://localhost:5000

### Step 3 - Configure react + backbone build

1. Navigate to `Application/src/Application.web`
2. In terminal: `$ npm install`
3. In terminal `$ npm run go`
4. Check to see that changes in `src-client` show up in the wwwroot directory