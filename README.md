

### 1. Azure Link

- Here is the URL of my APIs that have been hosted on Azure:

  https://msa-projects-phase1-schoolsims-webapi.azurewebsites.net/



### 2. Explanation of code

####	2.1 Database Update

1. Create table named **Address** with attributes: `StudentId`, `Street Number`, `Street`, `Suburb`, `City`, `Postcode` and `Country`. 

The screenshot shows the properties of Address Model. 

![Annotation_AddressModel](https://raw.githubusercontent.com/ZhonglinChen/MSA-2020-Phase1-BackEndDev-WebAPI-StudentSIMS/master/Images/Annotation_AddressModel.png)

In this case,

- The addressId was set as Primary Key incremented automatically; 

- The studentId was set as Foreign Key of Address Model.

  

2. Adapt code so that **Student** table could have a one-to-many relationship with table **Address**.

The screenshot shows the properties of Student Model. 

![Annotation_StudentModel](https://raw.githubusercontent.com/ZhonglinChen/MSA-2020-Phase1-BackEndDev-WebAPI-StudentSIMS/master/Images/Annotation_StudentModel.png)

In this case,

- Virtual collection of addresses was added to student model;
- Initialise the collection of addresses in the constructor.



3. Showcases of data using Query editor for both tables with rows of example instances from Azure SQL Server.

![Annotation_StudentSQLExample](https://raw.githubusercontent.com/ZhonglinChen/MSA-2020-Phase1-BackEndDev-WebAPI-StudentSIMS/master/Images/Annotation_StudentSQLExample.png)

![Annotation_AddressSQLExample](https://raw.githubusercontent.com/ZhonglinChen/MSA-2020-Phase1-BackEndDev-WebAPI-StudentSIMS/master/Images/Annotation_AddressSQLExample.png)


