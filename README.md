# Textile-Automation-App
Textile Automation Program that retrieves data from Ms Sql


![2](https://github.com/sahinkaraoglu/Textile-Automation-App/assets/76259114/ecab9f4c-1c7a-426e-8e46-dd5d7f4eb649)
![1](https://github.com/sahinkaraoglu/Textile-Automation-App/assets/76259114/21dce37f-0638-4685-b754-8f5106007927)



# Textile Company Management System

A Windows Forms application for managing textile company information and products, built with C# and MS SQL Server.

## Features

- Secure login system
- Company information management including:
  - Company details (name, contact info, address)
  - Product categories
  - Authorized person information
  - Location data (city/district)
- Advanced search functionality
- Excel export capabilities
- User-friendly interface with Turkish language support

## Technical Details

- Built with C# Windows Forms
- MS SQL Server database integration
- Excel integration for data export
- Modular design with separate forms for login and main operations

## Screenshots

![Login Screen](https://github.com/sahinkaraoglu/Textile-Automation-App/assets/76259114/21dce37f-0638-4685-b754-8f5106007927)
![Main Interface](https://github.com/sahinkaraoglu/Textile-Automation-App/assets/76259114/ecab9f4c-1c7a-426e-8e46-dd5d7f4eb649)

## Database Structure

The application uses the following main tables:
- Company Information (bilgi)
- User Authentication (giris)
- Cities (iller)
- Districts (ilceler)

## Installation

1. Download the project as ZIP from the green "Code" button above
2. Extract the ZIP file to your computer
3. Run the SQL scripts in the "Veritabanı" folder using SQL Server Management Studio
4. Open the project in Visual Studio

## Requirements

- Windows OS
- .NET Framework
- MS SQL Server
- Microsoft Office (for Excel export functionality)
