### 1. Azure Link

-----------------

- Here is the URL of my APIs that have been hosted on Azure:

  https://msa-projects-phase1-schoolsims-webapi.azurewebsites.net/



### 2. Explanation of code

-------------

####	2.1 Database Update

----------------

2.1.1 -> Create table named **Address** with attributes: `StudentId`, `Street Number`, `Street`, `Suburb`, `City`, `Postcode` and `Country`. 

The screenshot shows the properties of Address Model. 

![Annotation_AddressModel](https://raw.githubusercontent.com/ZhonglinChen/MSA-2020-Phase1-BackEndDev-WebAPI-StudentSIMS/master/Images/Annotation_AddressModel.png)

In this case,

- The addressId was set as Primary Key incremented automatically; 

- The studentId was set as Foreign Key of Address Model.

  

2.1.2 -> Adapt code so that **Student** table could have a one-to-many relationship with table **Address**.

The screenshot shows the properties of Student Model. 

![Annotation_StudentModel](https://raw.githubusercontent.com/ZhonglinChen/MSA-2020-Phase1-BackEndDev-WebAPI-StudentSIMS/master/Images/Annotation_StudentModel.png)

In this case,

- Virtual collection of addresses was added to student model;
- Initialise the collection of addresses in the constructor.



2.1.3 -> Showcases of data using Query editor for both tables with rows of example instances from Azure SQL Server.

![Annotation_StudentSQLExample](https://raw.githubusercontent.com/ZhonglinChen/MSA-2020-Phase1-BackEndDev-WebAPI-StudentSIMS/master/Images/Annotation_StudentSQLExample.png)

![Annotation_AddressSQLExample](https://raw.githubusercontent.com/ZhonglinChen/MSA-2020-Phase1-BackEndDev-WebAPI-StudentSIMS/master/Images/Annotation_AddressSQLExample.png)



#### 2.2 API Implementations

-------------

##### 2.2.1 Basic CRUD requests for **Student** and Address table 

- Student: `GET: api/Students` - `GetStudents()` ![Annotation_StudentControllerGetStudents](https://raw.githubusercontent.com/ZhonglinChen/MSA-2020-Phase1-BackEndDev-WebAPI-StudentSIMS/master/Images/Annotation_StudentControllerGetStudents.png)

To **read** information including addresses of all students , we use Linq query method **Include()** that would retrieve addresses for each student.



- Student: `GET: api/Students/:id` - `GetStudent(int id)`![Annotation_StudentControllerGetStudentById](https://raw.githubusercontent.com/ZhonglinChen/MSA-2020-Phase1-BackEndDev-WebAPI-StudentSIMS/master/Images/Annotation_StudentControllerGetStudentById.png)

This API **reads** information including addresses of a student using studentId.



- Student: `POST: api/Students` - `PostStudent(Student student)`![Annotation_StudentControllerPostStudent](https://raw.githubusercontent.com/ZhonglinChen/MSA-2020-Phase1-BackEndDev-WebAPI-StudentSIMS/master/Images/Annotation_StudentControllerPostStudent.png)

This API **creates** a new row of a student to DB by posting a new student object using JSON.



- Student: `PUT: api/Students/:id` - `PostStudent(int id, [Bind("...")]Student student)`![Annotation_StudentControllerPutStudent](https://raw.githubusercontent.com/ZhonglinChen/MSA-2020-Phase1-BackEndDev-WebAPI-StudentSIMS/master/Images/Annotation_StudentControllerPutStudent.png)

This API **updates** information excluding addresses for a student using studentId. 

This means: *<u>Even if some additional addresses was contained in the JSON object of a student sent from client side, the update of addresses would be ignored.</u>*

To change the address of a student using studentId, refer to <u>API method that **changes** the address of a student using his/her StudentId.</u>



- Student: `Delete: api/Students/:id` - `DeleteStudent(int id)`![Annotation_StudentControllerDeleteStudent](https://raw.githubusercontent.com/ZhonglinChen/MSA-2020-Phase1-BackEndDev-WebAPI-StudentSIMS/master/Images/Annotation_StudentControllerDeleteStudent.png)

This API **deletes** a student using studentId if the student exists.



- Address: `GET: api/Addresses` - `GetAddresses()` ![Annotation_AddressControllerGetAddresses](https://raw.githubusercontent.com/ZhonglinChen/MSA-2020-Phase1-BackEndDev-WebAPI-StudentSIMS/master/Images/Annotation_AddressControllerGetAddresses.png)

This API **reads** all rows of address stored in the Address Table.



- Address: `GET: api/addresses/:id` - `GetAddress(int id)`![Annotation_AddressControllerGetAddressById](https://raw.githubusercontent.com/ZhonglinChen/MSA-2020-Phase1-BackEndDev-WebAPI-StudentSIMS/master/Images/Annotation_AddressControllerGetAddressById.png)

This API **reads** a row of address using addressId if the address with the id exists.



- Address: `Post: api/addresses` - `PostAddress(Address address)`![Annotation_AddressControllerPostAddress](https://raw.githubusercontent.com/ZhonglinChen/MSA-2020-Phase1-BackEndDev-WebAPI-StudentSIMS/master/Images/Annotation_AddressControllerPostAddress.png)

This API **creates** a row of address to DB when received a address object from client side. 

Meanwhile, a student with the studentId in the received object of Address have to exist in the Student table.



- Address: `Put: api/addresses/:id` - `PutAddress(int id, Address address)`![Annotation_AddressControllerPutAddress](https://raw.githubusercontent.com/ZhonglinChen/MSA-2020-Phase1-BackEndDev-WebAPI-StudentSIMS/master/Images/Annotation_AddressControllerPutAddress.png)

This API would **update** a row of address to DB when received **addressId** and a **address object** that contains the same **addressId** from client side.

Meanwhile, this update cannot break the constraints between Student and Address table.



- Address: `Delete: api/addresses/:id` - `DeleteAddress(int id)`![Annotation_AddressControllerDeleteAddress](https://raw.githubusercontent.com/ZhonglinChen/MSA-2020-Phase1-BackEndDev-WebAPI-StudentSIMS/master/Images/Annotation_AddressControllerDeleteAddress.png)

This API would **delete** a row of address from DB if a address with this id exists.