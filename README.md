# CA2023
CA - Advanced Programming
Graham Bollard - 10617126
10617126@mydbs.ie

The subsequent report details the planning and development process undertaken for the creation of the “Gecko Phones” ecommerce web application. The primary goal of this web application was to enhance the business by establishing an online platform aimed at catering to a specific target audience – people looking for information and to purchase Mobile Phones. This project's principal objective was to design an interactive web application, complete with essential features, enabling customers to efficiently explore, access individual product details. Furthermore, the web application was designed to empower business owners with the ability to add, modify, and remove products from the platform as needed.

**Goals**
The primary objective of this project was to develop a robust and visually appealing e-commerce web application specializing in the sale of Budget Mobile Phones. The application was designed to offer a seamless user experience with both front-end and back-end functionalities, focusing on the following key features:

1. Customer Registration and Authentication:
   - Users can create accounts, log in, and log out securely.

2. Role-Based Access Control:
   - Distinct roles for customers and administrators to ensure appropriate access and functionality.
   - Administrators can log in to manage products and oversee the system.

3. Main Page:
   - A central catalog page showcases all available products in an organized and user-friendly manner.
   - Product information is displayed clearly for customers to browse and select.

5. Product Details Pages:
   - Individual pages for each product offer in-depth details, including images, descriptions, prices.
   - Customers can access comprehensive information before making a purchase.

6. User-Friendly Interface:
   - The web application features an intuitive and aesthetically pleasing design.
   - A responsive layout ensures seamless access from various devices.

7. Customer Support and Contact:
    - Contact options for customer inquiries and support.
    

**Proposed Solution**
As outlined above the goal for this project is to create a visually appealing and intuitive E-commerce web application. The proposed solution is compatible with multiple devices (e.g., mobile, tablet and Computer) 
User Interface (“UI”) and User Experience (“UX”):
The front end of the web application, (i.e., the UI) consists of 10 pages as outlined below:
1.	Main page (Home page).
2.	Product details.
3.	Create product page (Administration access only).
4.	Delete product page (Administration access only).
5.	Edit product page (Administration access only).
6.	New user registration page.
7.	Login page.
8.	Manage your account page.  
9.	About us page.
10.	Contact us page.

**Main Page**
To enhance visibility and user-friendliness, I wanted each product to be presented on its own distinct "card," with each card featuring a corresponding product image. All product data is stored in the web application's database, and these details are automatically presented on the main page. The information prominently showcased on each card encompasses the product's Brand, Model, Price & Description

**Details**
Each product card prominently features clickable links that direct users to the respective product details page. This intuitive design allows users to easily access more information about a specific product of interest.

**Crud Ops**
Product Management Links: On the main page & details page there are links provided for Administration users to Create, Edit, or Delete products directly from the web application's database. These links enable administrators to perform these actions with ease.

Administrator Privileges: These functionalities are exclusive to users with Administration privileges. To access them, a user must be logged in as an administrator. This security measure ensures that only authorized personnel can modify the product database.

Real-time Updates: When a new product is created or existing products are edited or deleted through the administration interface, the main  page is designed to automatically refresh and display the most up-to-date information stored in the database. This ensures that users always see the current product listings.
Testing Credentials: For testing purposes, an administration login has been set up with the following credentials:

Username: admin@admin.com
Password: Abcd1234!
These administration features and testing credentials enable efficient management of the web application's product database, ensuring a smooth experience for administrators while maintaining data accuracy for all users.

**User Registration:**

New users can access the registration function from the “Gecko Phones” Home page. Typically, there is a link or button on the right-hand side of the navigation bar that leads to the registration page.

**User Login:**
Users who have registered can log in to their accounts through the same navigation bar on the Home page. This login function provides secure access to user-specific features and data.

**User Logout:**

To end a session and log out securely, users can click the logout option, often located in the navigation bar as well. This ensures the user's account remains protected.

**Manage Your Account Page:**

- This dedicated page serves as a hub for users to oversee and modify their account settings. Here are the key functionalities available on the Manage Your Account page:

  1. **Update Email and Password:** Users can change their email address and password, allowing for flexibility and account security.

  2. **Two-Factor Authentication (2FA):** Users have the option to enable two-factor authentication for an added layer of account security. This typically involves receiving a one-time code via email or a mobile app during login.

  3. **Data Access Request:** Users can request a copy of their personal data stored in the web application's database. This is in line with data privacy regulations, such as GDPR, that grant users the right to access their own data.

  4. **Data Deletion Request (Account Deletion):** If users wish to remove their data and delete their account, this functionality allows them to submit a request for account deletion.

**About Us Page:**

The 'About Us' page provides users with information about the web application's owners or the company behind the application. It typically includes details about the company's mission, values, history, or any other relevant information that helps users understand the purpose and background of the application.

This page may also feature a personal message from the web application owners, expressing their vision, goals, or appreciation for their customers.

**Contact Us Page:**

The 'Contact Us' page serves as a means for customers to get in touch with the company or web application administrators. It usually includes a contact form that customers can fill out with their inquiries, feedback, or problem reports.

 When a customer submits the form, the information provided is processed by the web application. It is then typically sent as an email to the designated "Companies" email address. This allows for efficient communication between customers and the company.

The contact form typically includes fields for the customer to input their name, email address, subject of inquiry, message, and any other relevant details.


**Architecture**

**Model:**
- The Model component of the web application serves as a representation of the application's data. It acts as a blueprint for the database, defining its structure and how data is organized.
- The Model is responsible for tasks such as retrieving, updating, and deleting information stored in the database. It handles data-related operations and interacts with the database management system.

**View:**
- The View component is responsible for rendering the User Interface (UI) elements that users interact with in a web browser. It presents the data from the Model to users in a visually appealing and understandable manner.
- Views also facilitate user interactions such as updating the database, adding, editing, or deleting products, adding products to a shopping cart, or initiating payment processes. Views interact with the Controller to perform these actions.

**Controller:**
- The Controller component acts as an intermediary between the Model and the View. It handles user requests and manages the flow of data between these two components.
- Controllers receive user actions, determine which Model methods to invoke, and decide how the resulting data should be presented to the user through the View. Importantly, the Model and View components interact with the Controller, but not directly with each other.

