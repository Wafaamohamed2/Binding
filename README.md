 # Project Overview
This ASP.NET Core MVC project demonstrates essential features such as model binding, basic CRUD operations, and view rendering.
The project is designed to serve as a learning resource for understanding how data is passed between controllers, models, and views in an ASP.NET Core application.

# Features :
  # 1. Model Binding in BindController1
   The BindController1 demonstrates how ASP.NET Core maps incoming request data to action method parameters.
  
  - Binding Primitive Types:
       Example: Bind/BindController1/TestPrimitiv?id=1&name=Ahmed&age=25
       Maps query parameters to action parameters (id, name, age, color).
      
   - Binding Collection Types:
        Example: Bind/BindController1/TestCollection?phones[home]=123456&phones[work]=789456&name=Ahmed
        Binds dictionary data (phones) and string parameter (name).
      
   - Binding Complex Types:
        Example: Bind/BindController1/TestComplex?id=1&name=Ahmed&age=25
        Demonstrates binding custom objects like the Department model

 # 2. CRUD Operations in DepartmentController
  The DepartmentController implements basic CRUD operations for managing departments:

  - Index Action:
      Fetches and displays a list of departments from the database.
      View: Index.cshtml renders the department list in a table.
  - New Action:
      Displays a form for adding a new department.
      View: New.cshtml provides the form layout.
  - SaveData Action:
      Handles form submission and saves a new department to the database.
      Implements validation for department name and assigns a default manager name if not provided.

# Views
  1. Index.cshtml
     Displays a table of all departments, including their ID, name, and manager name.

   ~ Path: /Department/Index
   ~ Key Features:
      Table dynamically renders department data using @model List<Department>.
      Provides a link to create a new department.
  2. New.cshtml
      Renders a form for adding a new department.

  ~ Path: /Department/New
       ~ Key Features:
         Uses the @model Department type.
         Includes input fields for department name and manager name.
        Posts data to /Department/SaveData
        
# Key Concepts 

   Model Binding: Automatically maps request data to parameters or model objects in controller actions.
   CRUD Operations: Create, Read, Update, Delete functionality implemented in DepartmentController.
   View Rendering: Using Razor views to display and capture user input.     
