# Hair Salon DB

#### By **Loren Glenn**

## Description

Can store stylists and customer info on this site.

#### Specs

| Test                                                                           | Input               | Output            | Description                                                                                                                                                  |
|--------------------------------------------------------------------------------|---------------------|-------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------|
| User is able to insert a new Stylist                                           | "Kyle"              | Kyle              | This will be the most simple because the Stylist is the first object that will be added and we will just be checking that the name is stored in the database |
| User is able to insert a new Client                                            | "Cindy"             | Cindy             | This will check if the user input for a new client is being stored in the database                                                                           |
| User is able to associate a Client with a Stylist using the stylist ID         | "Cindy", "1"        | Kyle > Cindy      | This will check to see if the foreign Client key is associated with the correct Stylist                                                                      |
| User is able to associate multiple Clients with a Stylist using the stylist ID | "Cindy, Dan" , "1"  | Kyle > Cindy, Dan | This will check if multiple Clients can associate to the same Stylist                                                                                        |
| User can update Stylist information                                            | "1", "Mark"         | Mark              | This will check if Stylist info can be updated in the database by the user                                                                                   |
| User can update Client information                                             | "Dan", "5555555"    | 5555555           | This will check if Client information (phone) can be updated in the database by the user                                                                     |
| User can delete a Stylist                                                      | click delete button | ""                | This will check if after the user clicks the delete button, if the Stylist associated with that id no longer exists in the database                          |
| User can delete a Client                                                       | click delete button | ""                | This will check if after the user clicks the delete button, if the Client associated with that id no longer exists in the database                           |


## Setup/Installation Requirements
To create the database and tables, open Powershell and type in your sqlcmd -S localdb:

In SQLCMD:
> CREATE DATABASE hair_salon;
> GO
> USE hair_salon;
> GO
> CREATE TABLE stylists (id INT IDENTITY(1,1), name VARCHAR(255), hours VARCHAR(255), phone INT);
> CREATE TABLE clients (id INT IDENTITY(1,1), name VARCHAR(255), hair_color VARCHAR(255), phone INT, stylist_id INT);
> GO

Requires Windows and .Net

Clone repository, run ">dnx kestrel" in Powershell and visit "localhost:5004".

## Known Bugs

None.


## Technologies Used

 C# was used for the backend logic as well as routing with Nancy and testing with Xunit. Razor was used to display data on the html pages.

## Support and contact details

 _lorencglenn@gmail.com_

### License

 Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

 The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

 Copyright (c) 2016 **_Loren Glenn_**
