# Prevent Query Generation for Foreign Key Column in Blazor DataGrid

## Overview

This sample demonstrates how to prevent query generation for a foreign-key column in the Syncfusion [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) when foreign-key values are retrieved from a remote data source. The implementation uses an OData V4 service together with a Blazor DataGrid application to show how foreign-key data can be displayed without generating additional queries for the corresponding foreign-key column. This approach helps improve performance by reducing unnecessary network requests and minimizing query overhead when working with remote data sources. The sample is useful for applications that consume OData services and display relational data through foreign-key columns in a DataGrid.

## Key Features

- Demonstrates foreign-key column configuration in the Syncfusion Blazor DataGrid.
- Uses remote data binding with an OData V4 service as the primary data source.
- Shows how to prevent query generation for foreign-key columns when foreign-key data is loaded remotely.
- Demonstrates optimization techniques for remote data scenarios involving relational datasets.
- Uses a dedicated OData service application to provide remote data to the DataGrid.
- Illustrates efficient handling of foreign-key fields without generating additional filter queries.
- Provides a practical reference for applications that consume OData services and require DataGrid foreign-key column support.

## Prerequisites

- Visual Studio 2022 or Visual Studio Code
- .NET SDK compatible with the project's target framework

## How to Run the Project

**Visual Studio 2022**

1. Clone or download the repository.
2. Open the solution file for the `OdataV4Service` project in Visual Studio 2022.
3. Restore all NuGet packages.
4. Build and run the `OdataV4Service` application.
5. Open the solution file for the `Grid_PreventQueryGeneration` project.
6. Restore all NuGet packages.
7. Set `Grid_PreventQueryGeneration` as the startup project if required.
8. Build the solution.
9. Run the project using `Ctrl+F5`.

**Visual Studio Code**

1. Open the repository folder in Visual Studio Code.
2. Open the integrated terminal.
3. Navigate to the OData service project directory.

```bash
cd OdataV4Service
dotnet restore
dotnet run
```

4. Open a second terminal and navigate to the DataGrid project directory.

```bash
cd Grid_PreventQueryGeneration
dotnet restore
dotnet run
```

5. Open the local URLs displayed in the terminal after both applications start successfully.

## Project Structure

- `PreventQueryGeneration/Grid_PreventQueryGeneration/` — contains the Syncfusion Blazor DataGrid implementation that demonstrates prevention of foreign-key query generation.
- `PreventQueryGeneration/OdataV4Service/` — contains the OData V4 service consumed by the DataGrid application.
- `PreventQueryGeneration/Grid_PreventQueryGeneration/Pages/` — hosts the DataGrid page responsible for displaying remote data and foreign-key values.
- `PreventQueryGeneration/Grid_PreventQueryGeneration/Data/` — contains supporting models and sample data structures used by the client application.
- `PreventQueryGeneration/OdataV4Service/Controllers/` — exposes OData endpoints consumed by the Blazor DataGrid.

## Support and Feedback

- For general product questions, visit the [Syncfusion Community Forum](https://www.syncfusion.com/forums) or [Syncfusion Support](https://www.syncfusion.com/support).
- To report an issue specific to this sample, open a GitHub issue in this repository.
- For feature documentation, see the Syncfusion Blazor DataGrid Foreign Key Column documentation: https://help.syncfusion.com/grid-sdk/blazor/data-grid/foreignkey-column

## License

This is a Syncfusion sample project provided to demonstrate product usage. Review the [Syncfusion license terms](https://www.syncfusion.com/sales/pricing?category=ui-components) before using Syncfusion components in your own applications.
