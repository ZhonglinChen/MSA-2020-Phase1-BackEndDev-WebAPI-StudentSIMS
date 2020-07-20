# Assignments for API + Database module

## 10.1 Submission

Students will need to submit a link to GitHub repository. Your `README.md` should contain the following contents, refer to 10.2 for more details:

- All the screenshots and explanations/notes
- URLs of your APIs that have been hosted on Azure

## 10.2 Project Guidelines

- Create a **code-first** API server with Azure SQL Database
  - Database:
    - Create another table named **Address** with attributes: `StudentId`, `Street Number`, `Street`, `Suburb`, `City`, `Postcode` and `Country`. The **Student** table would have a one-to-many relationship with this table. Please assign appropriate datatype (i.e. `string`, `int` etc.) for each of the attributes.
    - Show SQL database through the Query editor (**screenshots**) for both tables with rows of example instances
  - API manipulate the created Azure Database using Code-First migration:
    - Create basic CRUD requests for the **Student** and **Address** table.
    - Create an API method that **adds** new address for a student using his/her StudentId.
    - Create an API method that **changes** the address of a student using his/her StudentId.
    - **Screenshot** of Swagger UI showing all API Endpoints
- Microsoft Learn Module
  - Student will need to finish 1 compulsory :
    - Compulsory: [Create a web API with ASP.NET Core](https://docs.microsoft.com/en-us/learn/modules/build-web-api-net-core/?fbclid=IwAR0YijdrKtl3UUkQLVTUw3i6RTJbkxLte7RbZhD2aBPYvZva-Pp-_WRYbJM)
    - Optional module that will help you with your learning:
      - [Provision an Azure SQL database to store application data](https://docs.microsoft.com/en-us/learn/modules/provision-azure-sql-db/?fbclid=IwAR0k7zN0rgLgISyDoSZP7l3Mm1nEUjUY9nJJS0TnVEPjdn78xzWThfJesLk)
      - [Develop and configure an ASP.NET application that queries an Azure SQL database](https://docs.microsoft.com/en-us/learn/modules/develop-app-that-queries-azure-sql/?fbclid=IwAR2j2JDWm8dfkpOV8T-QYu6M1VHw6cFgvRBYF03K_ZXUerX2HJ28O2OUWBo)