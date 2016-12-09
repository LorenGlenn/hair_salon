| Test                                                                           | Input              | Output            | Description                                                                                                                                                  |
|--------------------------------------------------------------------------------|--------------------|-------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------|
| User is able to insert a new Stylist                                           | "Kyle"             | Kyle              | This will be the most simple because the Stylist is the first object that will be added and we will just be checking that the name is stored in the database |
| User is able to insert a new Client                                            | "Cindy"            | Cindy             | This will check if the user input for a new client is being stored in the database                                                                           |
| User is able to associate a Client with a Stylist using the stylist ID         | "Cindy", "1"       | Kyle > Cindy      | This will check to see if the foreign Client key is associated with the correct Stylist                                                                      |
| User is able to associate multiple Clients with a Stylist using the stylist ID | "Cindy, Dan" , "1" | Kyle > Cindy, Dan | This will check if multiple Clients can associate to the same Stylist                                                                                        |
| User can update Stylist information                                            | "1", "Mark"        | Mark              | This will check if Stylist info can be updated in the database by the user                                                                                   |
| User can update Client information                                             | "Dan", "5555555"   | 5555555           | This will check if Client information (phone) can be updated in the database by the user                                                                     |
