To run these project follow these steps :<br/>
1.customize the connection string in web.config :<br/>
    <add name="DefaultConnection" connectionString="Server=.\SQLEXPRESS;Database=CarRentalDb;Trusted_Connection=True;" providerName="System.Data.SqlClient" />
2.in package manager run : Update-DataBase<br/>
3. Apply the sql file (goCar.sql) in order to seed data in database <br/>
4. run the application
