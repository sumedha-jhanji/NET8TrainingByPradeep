# NET8TrainingByPradeep

## Evolution of .Net
- 2002 -> .net 1.0
- 2005 -> .net 2.0 (stable version)
- 2008 -> .net 3.5
- 2016 -> new framework launched  .NET CORE 1.0 along with .Net 4.5(traditional)
- 2017 -> .NET core 2.0
- 2019 -> .NET core 3.0/3.1 (out of support)
- 2021 -> .Net 5 (out of support)
- 2021 -> .NEt 6.0(actually a core) (LTS)
- 2022 -> .Net 7(out of support)
- 2023 -> .Net 8(actually a core) along with .Net 4.8(traditional)(LTS)

## .NET Core
-  one platform to develop windows, mobile, web etc apps
- cross platform(Windows, Linux, MAC)
- Open source
- High performance
- scalable
- support DOCKER(Containerization)
- DOTNET CLI (Command Line Interface) -> we can build apps without using VS
- everything is nuget package
- much fater response than traditional .net

## .NET 
- unified platform for developing different types of applications
-  can develop Cloud(Azure), Web(asp.net, Blazor), Mobile(xamarin, MUI), Gaming(unity), IoT, AI, Desktop(WPF, Winforms, .Net MUI)

## Traditional .NET
- Only meant for windows
- C# code is converted into IL using CBC compiler which then converted into Machine code using CLR JIT Compiler

## In .net Core
- C# code is converted into IL using Roslyn compiler(single compiler for multiple languages and is open compiler) which then converted into Machine code using Core CLR RyuJIT Compiler(for cross platform)

## Roslyn compiler
- single modern compiler for multiple language
- Open source
- have api's for code analyzing, generating code, on the fly code error(automatically show the compilation error on the fly)
- very powerful compiler

## RyuJIT 
- faster, cross platform, have GC

## Traditional Hosting can be done using below Web servers
- IIS(for windows)
- Ningx (for Linus)

## Traditional VS .NET Core
- In traditional (IIS(only windows)), when we send request to web server, there are various HTTPHandlers and HTTPModules which handle the request and response.

## .Net Core(Cross Platform), 
  - HttpHandlers and modules has been replaced by Middleware (plug and play s/w components about what we want in our pipeline)
  - on webserver, we also have KESTRAL SERVER developed by Microsoft. 

## KESTRAL SERVER
 - It is very fastest server. 
 - It is just limited to handle request and response. 
- If we want to use say session, caching etc, for that we need IIS or ningx. 
- Kestral will only allow processing by just opening port.
- It is just like a base class
- first request goes to IIS then to Kestral

## ASP.NET MVC
- for windows platform
- web.Config -> totally binded to IIS
- Global.asax is available
- HTTPHandlers and HTTPModules were there which rely on IIS
- libraries in GAC which is only there in windows
- Html Helpers
- partial views (static and dynamic)

## ASP.NET CORE MVC
- cross platform
- appsettings.config
- no Global.asax. we have program.cs
-  we have middleware for http pipeline
-  everything is nuget package
-  Html Helpers & tag helpers
- partial views -> static partial view for static and for dynamic - view components

# Routing
- serving a web page based on requested URL
- matches the pattern of request and execute the code accordingly

## Types of Routing
- Conventional based Routing
- Attribute based routing

## Ways to pass data via a route
- Model Binder
    - binds the parameter of the method from the URL querystring
            public string GetAddress(string city, string country){}
            http://localhost:port/controllername/getaddress?city=chandigarh&country=india
    - also binds the value from forms control to model

- Route Data
    - we can use RouteData as below
        ```csharp
            [Route("address/{city}/{country})]
            public string GetAddress(string city, string country){}

            http://localhost:port/controllername/getaddress/chandigarh/india
            
            [Route("address/{city:string}/{country})] ---> city can be only string value ```
        
## GET vs POST HTTP Methods
- get passes everything in url
- post will pass everything in bounday
   ** Note -** by default form submit and action will allow both post and get which is a loop hole. To avoid that we should provide [HttpPost] attribute over controller method.

# HtmlHelpers
- Extension methods used for generating HTML code.
- Standar HTML Helpers
  ```csharp  <div>
                    @Html.Label("Product ID") // standard helpers
                    @Html.TextBox("ProductId")
                </div> ```
- Strongly Typed Helpers
   ```csharp model ProductViewModel
            @using(Html.BeginForm()){
                    @Html.LabelFor(d => d.ProductId)
                    @Html.TextBoxFor(d => d.ProductId)
            } ```
   
## Binding Form to Model
- Use BeginForm() to mark the form beginning
  ```csharp @using(Html.BeginForm()) ```

        OR
```csharp @using(Html.BeginForm("actionmethodname", "folder, FormMethod.Post)) ```

## Templated Helper
- It will load all controls automatically using strongly typed model.
- It depends upon data type
- **Dis-advantage is:** We don't have control on the form.
- Build form fastly but not recommended
```csharp @Html.EditorForModel() ```

## Display Labels with custom names
- Displayname can be used to display custom name on label in case of Strongly types views
```csharp
[DisplayName("Product Code")]
public string ProductCode{get;set;}
```
- **Note: ** By default the field will be marked as **Required** as it is defined as not nullable

## Bootstrap
- CSS framework for designing responsive UI.(changing resolution won't stretch the content)
- Divides screen into 12 columns
- can handle different screen sizes representing xs, sm, md, lg      - 

# .NET Core Tag Helpers
- Available in .NET Core
- Helper methods to generate HTML code.
- It can embed server side code with HTML element.
- provides html friendly development.
- it also prevents from cross site scripting errors
- Represents using **asp-***
- asp-route-* tag helper can be used to pass data to controller method (* will be replaced by controller parameter name like asp-route-view="1")
  - Controller action method
  ```csharp
    public IActionResult Summary(int view = 0)
    {
        if(view == 1)
        {
            return View("ProductsView",products);
        }
            else return View("CardsView",products);
    } 
    ```
  - route will be "**asp-route-view**"

**Example of Tag helper:**

```csharp
<form method="post" **asp-action**="addproduct" **asp-controller**="product">
     <div class="form-group">
         <label **asp-for**="ProductId"></label>
         <input type="text"** asp-for**="ProductId" class="form-control" />
     </div>
     <div class="form-group">
         <label **asp-for**="ProductCode"></label>
         <input type="text" asp-for="ProductCode" class="form-control" />
     </div>
     <div class="form-group">
         <label **asp-for**="ProductName"></label>
         <input type="text" **asp-for**="ProductName" class="form-control" />
     </div>
     <div class="form-group">
         <label **asp-for**="ProductPrice"></label>
         <input type="text" **asp-for**="ProductPrice" class="form-control" />
     </div>
     <div class="container flex-container">
         <input type="submit" class="btn btn-primary" value="Save Product" />
     </div>       
 </form>
```
**Other Tag Helper**
- asp-action -> specify action of controller
- asp-controller -> controller name
- partial -> to specify partial view
   
## Partial View
- View with in a view
- We can share the view across application
- We will create this view inside shared folder if required on all views otherwise, we can place it in specific feature folder
- While creating view, enable "create partial view" option
- We will use tag helper, **partial** to use that view
```csharp <partial name="_offers" model="product" /> ```
**Note:** "name" will take name of partial view to be used and "model" will be the strongly typed model whose values we want to display on partial view

## Layout View 
- to have consistent layout, we have separate view which will be shared by other views
- In layout view, we need to use **@RenderBody()** at loaction where whole view will get loaded.
- In our views, we can refer layout view as **Layout = "_layout view name"**;
      
# VIEW COMPONENT
- To pass dynamic content to partial view
- We can create dynamic partial view which are called View Components
- Steps to create View Component
  - Create a class say **DiscountOfferViewComponent.cs**
    **Note:** Rule is to append **ViewComponent** at back of name
  - Inherit your class from ViewComponent class
  - Create method **Invoke** with return type **IViewComponentResult** and requried parameters
  ```csharp public class DiscountOffersViewComponent : ViewComponent
  {
      public IViewComponentResult Invoke(decimal price)
      {
          if (price > 50000)
          {
              decimal discount = price * 15 / 100;
              decimal finalprice = price - discount;
              return View("_discountOffer", finalprice);
          }           
  
          return View("_noOffer");
      }
  }```
  - Inside View/Shared folder, we need to have folder "**Components**" - it is requriement (MUST)
  - Inside **Components** folder, we need to have folder say "**DiscountOffers**".
    **Note:** name should be same that of ViewComponent
  - Inside "**DiscountOffers**" folder, we need to create views say "**_discountOffer**" and "**_noOffer**" 
  - In _ViewImports, add
    ```csharp @using QuestpondTrainingWebApp.Component
              @addTagHelper *, QuestpondTrainingWebApp
   ```
  - To use view component in required partial view,  rule is we need to specify view component name using kebab case 
  ```csharp <vc:discount-offer productprice = "@Model.Price"></vc:discount-offer>  ```
            
# Custom Tag Helpers
- Create class in **Custom** foder. Name it as <name>TagHelper example "MyCustomTagHelper"
- Inherit from **TagHelper** class
- Define **override Process(TagHelperContext, TagHelperOutput)** or **ProcessAsync(TagHelperContext, TagHelperOutput)**
- Inside method we can sethtmlcontent or can perform our logic.
  ```csharp
  public class ExampleCustomTagHelper : TagHelper
  {
      public string Author { get; set; } // property to pass dynamic data to custom tag he;per
      public override void Process(TagHelperContext context, TagHelperOutput output)
      {
          output.Content.SetHtmlContent($"This is custom tag helper example by {Author}");
      }
  }
  ```

  ```csharp
   public class GenerateOrderedListTagHelper : TagHelper
   {
       public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
       {
           var existingContent = await output.GetChildContentAsync();
           var existingData = existingContent.GetContent();
           if (existingData != null && existingData.Count() > 0) {                
               var listData = existingData.Split(",", StringSplitOptions.RemoveEmptyEntries);
               if (listData.Count() > 1)
               {
                   output.TagName = "ul";
                   foreach (var item in listData)
                   {
                       output.Content.AppendHtml($"<li>{item}</li>");
                   }
               }
           }
       }
   }
  ```
- In _viewImports, add ->  @addTagHelper *, QuestpondTrainingWebApp
- In cshtml we need to use the custom tag helper using kebab case
  ```csharp
  <example-custom author="Sumedha Jhanji"></example-custom>
  ```
- If we want to pass data dynamic in tag helper 
  - Define property in custom tag helper class. Property should also be refereneced in cshtml as kebab case
  - In cshtml dynamic data can be passed using kebab case
- If we want to use different tag name for custom tag helper, then on class we can provide decorator
  ```csharp
    [HTMLTargetElement("custom")]
     public class ExampleCustomTagHelper : TagHelper
  ```
- In cshtml, then we can refer the custom tage helper as **<custom />**
  
## ModelExpression property
- If we want to use strongly type model, we need to define property of type **ModelExpression**.
  ```csharp
  public ModelExpression ProductName{get;set;}
  ```
- In **ProcessAsync()** method, use **ModelExpression** as **output.Content.SetHtmlContent($"{ProductName.Model});**
- In cshtml, use kebab case as "**<my-custom product-name="value"/>**" for ModelExtension property
- **HTMLAttributeName** can be used for changing property name

# Validations
- To protect data from invalid data inputs
- Client side and Server side

## Explicit Model validation
- will validate properties in action method like 
    ``` csharp
    public IActionResult Save(ProductModel productVM)
    {
        if(productVM.ProductCode == null) {
            ModelState.AddModelError("ProductCode", "message")
        }
        if(ModelState.IsValid){
            //save code
        }
    }
    ```    

## Data annotation
- In model, provide DataAnnotations
```csharp
[Required]
public string ProductCode{get;set;}

[Required(ErrorMessage="ProductName is mandatory)]
public string ProductName{get;set;}
```

```csharp
<form method="post" asp-action="addproduct" asp-controller="product">
<div asp-validation-summary="All" class="text-danger"></div>
<div class="form-group">
 <label asp-for="ProductId"></label>
 <input type="text" asp-for="ProductId" class="form-control" />
 <span asp-validation-for="ProductId" class="text-danger"></span>
</div>
<div class="form-group">
 <label asp-for="ProductCode"></label>
 <input type="text" asp-for="ProductCode" class="form-control" />
 <span asp-validation-for="ProductCode" class="text-danger"></span>
</div>
<div class="form-group">
 <label asp-for="ProductName"></label>
 <input type="text" asp-for="ProductName" class="form-control" />
 <span asp-validation-for="ProductName" class="text-danger"></span>
</div>
<div class="form-group">
 <label asp-for="ProductPrice"></label>
 <input type="text" asp-for="ProductPrice" class="form-control" />
 <span asp-validation-for="ProductPrice" class="text-danger"></span>
</div>
<div class="container flex-container">
 <input type="submit" class="btn btn-primary" value="Save Product" />
</div>       
</form>
```
- <div asp-validation-summary="All" class="text-danger"></div> used for showing validation summary
-  **asp-validation-for="<propertyname>" **can be used for showing validation error specific to input element

## Steps to create custom validation
- Create class in **Custom** folder say **CodeValidator**
- Inherit from **ValidationAttribute**
- Override **IsValid()** and specify logic in same
- Use "**[CodeValidator]**" as data annotation in model class    
- If we want to return user provided error message from custom validator -> we have predefined "ErrorMessage' property available
- If we want any other value from user for custom validator, we can define property say "Character" for that in validator and use that in [CodeValidator(Character ="")]
**Note: **Till now all validations are getting performed on server -side validation

## Steps to perform Client side validation
- in view, we need to drag below files in given order
    **jquery.min.js, 
    jquery.validate.min.js, 
    jquery.validate.unobtrusive.min.js**
- using these files, it will perform all the validations (data annnotation) on client side except Custom validator because all validations get rendered in input elements except custom ones.
- ## Steps to use Custom validation at client side
- inherit the custom validation class from "**IClientModelValidator**"
- implement the interface method -> **AddValidation()**
- in **AddValidation()** we need to tell what we need to render in input element
    - Add the attributes for client side
       ** context.Attributes.Add("data-val-codevalidator", ErrorMessage); // ErrorMessage is predefined property from ValidationAttribute class
        context.Attributes.Add("data-val-codevalidator-character", Character); //Character is property defined by us in custom validator**
- Define logic for client side
    - add new js file
    - in js file, our job is to add our validation a spart of unobtrusive
        jQuery.validator.addMethod("codevalidator", function(val, element, param){
            //same logic that was written for server side custom validator.
        })

        jQuery.validator.unobtrusive.adaptor.add("codevalidator", ["char"], function(option){
            option.rules['codevalidator']= {char: option.param.char};
            option.messages['codevalidator'] = option.message;
        })
    - load js in html view file.

# Database connectivity
- ADO.NET
    - sql connection
    - sql command   
    - sql data reader / sql data adapter
- ORM (Object Relational Mapping)
    - do all RDBMS activity with help of OOP
    - have APIs to do CRUD operations without writing scripts
    - we create class which act like DB. 
        - Classes will have entities representing tables. 
        - Enity class will have properties which acts as columns
        - DBSet<Entity> acts as Rows
    - ORMs available
        - NHibernate
        - Dapper
        - Entity Framework (works only on traditional .net framework)
        - Entity Framework core (works on cross platform)

## Entity Framework Core
- Types of Data Modelling
  - Code first approach
  - Db first approach (Reverse Engineering)

## Steps for EFcore with Sql server (Code first approach)
- add nuget packages
  - Microsoft.EntityFrameworkCore
  - Microsoft.EntityFrameworkCore.SQLServer
  - Microsoft.EntityFrameworkCore.Tools
- Add class say DemoDbcontext.cs -> we are creating database (we usually refer Db as DbContext)
- inherit it from DbContext class.
- add new folder -> entities
  - add new class say Product -> represent a table
  - add properties i.e. columns in table
  - provdie attribute to class [Table("tbltablename", schema="")]
  - use [Key] attribute on property for primary key
  - [Column(TypeName ="varchar(200)")] -> to provide type to property. By default string is nvarchar(max)
- In DemoDbcontext, add property -> DbSet<Entity> -> example public DbSet<Product> Product {get;set;}
- In DemoDbcontext, override OnConfiguring() to define connection string using (Data Source, Initial Catalog, Integrated Security=true) and call UseSqlServer() in it on builder

## Migration Commands
- commannd line to execute and generate SQL script
- execute sql script in DB
    
## Steps in Migration
- Add Migration <migration name>
- Update-Database
- Script-Migration

## Process to follow to Create DB using EF core
- Open Package Manager console
  - Set the EF core project as "Set as Startup" project
  - In package manager console, select the EF core project from drop down
  - run commannd "Add-Migration <name of migration>":  it will create migration file under Migration folder which is having DB structure.
  - run "Update-database": it will use connection string and verify if DB exists. If no, it will execute migration script and create DB. It will automaicalliy create "__EFMigrationsHistory" table which consists of tracking of all migrations
- follow these steps when ever any modification is made to DB objects or new DB objects are created.
- Say we have created 2 or more migrations before running update-database, Running update-database will execute all the latest created migrations in one go.

## Create Foriegn Key 
- In class which required foriegn key relation, we need to add **navigation property**
  - public Category Category { get; set; }  // here Category is Foriegn table entity name
- also add property which we need as foreign key. Note, it should be with same name as it is defined in foreign table
  - public int CategoryId { get;set; }
- if we want to add foreign key property with some other name , then we need add attribute as below to that property
  - [ForeignKey("Category")] // foreign class name
  ![image](https://github.com/user-attachments/assets/f3795d49-bbec-482f-95bf-be89cffc277e)

 Product table which needs CategoryId as foreign key from Category table
  ![image](https://github.com/user-attachments/assets/52337563-8412-476f-9dcb-1a1507a5c669)

  ![image](https://github.com/user-attachments/assets/65964226-336e-4288-b861-76e6bd780b45)

## Key Concepts/points of EF core
- Using: var products - context.PRoducts.where(condition).ToList() will perform: open connection, generate script, execute query, deserialze to List<Product>, close connection

## Repository pattern
- design pattern for connection from app to data access layer to have loose coupling  
- according to Martin Fowler, Repository pattern mediates between domain(model) and data mapping layer(DAL) acting like a in-memory collection of domain Object
- decouples application from persistant framework like EF, ADO.NET
- minimize duplicacy of code
- it will give list of domain objects.
- we should use Repository pattern on top of EF so that tomorrow, we want to use oracle, then we need to make change to logic layer for consuming that in place of EF. If we have RP, we just need to modify RP to connect to correct DAL
- allow unit tetsing since we create interface and class
- ensure that it will always give us class object
- will hav add, remove, get, getall etc methods
- **Steps to implement Repository pattern**
  - add new class library project (like Repositories)
  - create 2 folders
    - Abstraction(maintain all interfaces example ICategoryRepository, IProductRepository // we can have generic repository/ base repository also),
    - Implementation 
  - Declare required methods in I<Entity>Repository
  - In implementation folder, create classes that will implement corresponding interfaces
  ```csharp
  public class ProductRepository: IProductRepository
  {
      private readonly DemoDbcontext _context; // to connect to Database
      public ProductRepository(){
          _context = new DemoDbcontext();
      }

      bool Add(Product productToAdd){
          _context.Products.Add(productToAdd);
          var rowsAffected = _context.SaveChanges(); //open connection, generate insert script, execute script, fetch latest id, close connection
          return (rowsAffected > 0);
      }

      bool Delete(int productId){
          //ef doesn't have any method to delete. it has for remove but not delete.
         // executeDelete - select the record and delete it

         _context.Products.Where(d=> d.productId).ExecuteDelete(); // if no product id, it will return 0
         var rowsAffected = _context.SaveChanges();
         return (rowsAffected > 0);
  
         // or we can get the product, then check if we have product and then call .Remove()
      }

      IEnumerable<Product> GetAll(){
          var products = (from prod in context.PRoducts
                          where prod.Productid > 0
                          select prod).AsNoLocking().ToList(); // toList will actually execute the query //.AsNoLocking() - will not lock table
          return products;
      }

      bool Update(Product productToAUpdate){

          //one way
          //_context.Products.Where(condition).ExecuteUpdate(s=> {s.SetProperty(p => p.productCode, productToAUpdate.ProductCode)}); // if we want to update specific properpty

          _context.Entry<Product>(productToAUpdate).State= EntityState.Modified;
          _context.SaveChanges();
          return true;
      }
  }
  ```
- We need to add another layer in between Web app and Repository pattern to convert Domain object to Viewmodel or DTO which will then be referenced by Webapp
  - create business layer **(BAL)**: add new class library

- **Handle transactions using EF**
- context.database.begintransaction() - in try
- context.database.comminttransation()  - in try
- context.database.RollbackTransaction() - in catch 

![image](https://github.com/user-attachments/assets/59ec7dec-536d-4489-9f61-fee4ccfaa872)

- **Key Points**
- Repositories entities classes count must be same as count of entities in DAL
- BL interfaces count can or cannot be equal to repositories classes count
- To bind data to drop down we need result in **SelectList**, but in case of validating error at server level, it will get empty, so we need to re-bind the drop down
- for many to many relationship in EF core, we use **onModelCreating()**

     

        

        

    





        



    

    




