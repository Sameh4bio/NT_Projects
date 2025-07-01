# NT Integration Viewer

This project provides a viewer for multiple message formats with a .NET 8 Web API backend and React frontend.

## Setup

### Backend

```bash
cd NT_Integration_Viewer.Api
dotnet publish -o ../publish
```

### Frontend

```bash
cd NT_Integration_Viewer.Web
npm install
npm run build
```

Place `dist/` contents into the `wwwroot` folder of the publish directory for IIS deployment.

### Configuration

Credentials and session timeout are stored in `appsettings.json`.

