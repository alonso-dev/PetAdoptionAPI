# Pet Adoption API

## Description
The Pet Adoption API is a backend service built using **ASP.NET Core**. It provides endpoints to manage and fetch information about pets available for adoption. This project is designed to showcase clean architecture and best practices in .NET development.

## Prerequisites
To run this project locally, you need to have the following tools installed:

1. **.NET SDK** (version 8 or higher):  
   [Download .NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

2. **Git**:  
   [Download Git](https://git-scm.com/downloads)

3. **An IDE**:  
   - Recommended: [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/).

## Getting Started

### 1. Clone the Repository
Clone this repository to your local machine:
```bash
git clone [https://github.com/<your-username>/<your-repo-name>.git](https://github.com/alonso-dev/PetAdoptionAPI.git)
```
Replace `<your-username>` and `<your-repo-name>` with your GitHub username and the repository name.

### 2. Restore Dependencies
Navigate to the project folder and restore the required NuGet packages:
```bash
cd <project-folder>
dotnet restore
```

### 3. Run the Project
Start the API locally:
```bash
dotnet run
```
This will host the API on a local development server. By default, it should be accessible at:
```
http://localhost:5034
```

### 4. Test the API
#### Using Swagger
1. Open your browser and go to:
   ```
   http://localhost:5034/swagger
   ```
2. Test the available endpoints directly from the Swagger UI.

#### Using HTTP Files
1. Use the provided `.http` file in the repository (`PetAdoptionAPI.http`) to test the endpoints directly within Visual Studio Code or another compatible tool.

