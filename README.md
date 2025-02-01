To run the project follow these steps :<br/>
1.customize the connection string in web.config :<br/>

    <add name="DefaultConnection" connectionString="Server=.\SQLEXPRESS;Database=CarRentalDb;Trusted_Connection=True;" providerName="System.Data.SqlClient" /> <br>
2.in package manager run : Update-DataBase<br/>
3. Apply the sql file (goCar.sql) in order to seed data in database <br/>
4. run the application

--------------------------------------------------------------------------
<h1>Methodologie Description</h1>
    
I started a webform project with asp.net identity as a membership system , the project is inspired by the last project i worked on "cargo.fr", so it's a booking car application.
I built the master page using css grid system , so the page is divided into  : header, footer ,section and content.
There are six pages : Home.aspx, Agencies.aspx, Cars.aspx and Payment.aspx ,Login.aspx,Register.aspx:

<h2>Home.aspx</h2>
This page displays an invitation to select a city and the start and end days of booking the car.<br>
City selection is created by a dropdownlist that have it's datasource populated from the DbSet citiess from the dbcontext , i choosed four  tunisian cities (Tunis,Sousse,Sfax,Djerba).<br>
flatpickr.js is used to create calender selection for the start and end days of booking.<br>
I added a HyperLink in the section bar that navigates back to Home page.
<h2>Agencies.aspx</h2>
This page displays each city's open agencies, agencies are displayed if the condition start booking time is lower than the end of booking time and if these choosed times are during agencies's open hours.<br>
To display the list of agencies , i used asp:Repeator along with a flex container to wrap items so the display is responsive no matter the number of items.<br>
I added a Hyperlink in the section bar,to display all agencies with their hours of service .
<h2>Cars.aspx</h2>
This page displays each agency's cars with images, like the agency page, i used asp:Repator and the cars are fit in a flex container for a responsive display.<br/>
The cars images are stored in database in base64.<br/>
I added a Hyperlink in the section bar , to display all cars (independant of agency).
<h2>Payment.aspx</h2>
This is the final page, it displays details of booking such as price and speed along the image the car image and duration of booking and invites the user to pay.
Flex is also used to divide the display between the details and image of this page.
<h2>Login.aspx and Register.aspx </h2>
Asp.net identity is used to register and login user, i added a HyperLink in the header that navigates to the Login page where a user can navigate to the register page too.<br/>
In the logic i store each page's url in session (the pages here are Home.aspx,Agencies.aspx,Cars.aspx and Payment.aspx) so the user's redirected back to these pages after login or registration.<br>
<h2>EntityFrameWork 6 Code First</h2>
In order to create the database i used the ORM EntityFrameWork 6 with code first approach along with IdentityDbContext ,my entites tables are :

1. City
2. Agency
3. Car
4. Week
5. WeekDays

City has a relationship one to many with Agency .<br>
Agency has a relationship many to many with Car.<br>
Agency has a relationship one to mmany with Week.<br>
Week has a relationship one to many with WeekDays.
