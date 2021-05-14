# ECommerceWebAPI


Please create a database and name it [ECommerce]

And run the scripts found in the below location 
https://github.com/KgaboMaraka/ECommerceWebAPI/tree/master/ECommerceWebAPI/SQL%20Scripts

Please remember to change the connection string in the Web.config file to point to your SQL Server instance

Database is SQL Server

PLEASE SEE ENDPOINTS BELOW

• Get customer details by ID (GET api/Customers/{id})
• Get all Products (GET api/Products)
• Get all products for a category (GET api/Products/{id})
• Get all bundles (GET api/Bundles)
• Customer adds a product to his basket (this should also check if all the required products to form a bundle is present) (POST api/Baskets)
• Get current value of the basket (GET api/Baskets/{id})
