# Learn Microservices architecture with NET Core MVC (NET 8), Entity Framework Core, NET Identity with Azure Service Bus

<!-- TOC -->

- [Learn Microservices architecture with NET Core MVC NET 8, Entity Framework Core, NET Identity with Azure Service Bus](#learn-microservices-architecture-with-net-core-mvc-net-8-entity-framework-core-net-identity-with-azure-service-bus)
    - [Section 2 Intro](#section-2-intro)
        - [Microservice Architecture](#microservice-architecture)
    - [Section 2: Section 2 Coupon API - Getting Started](#section-2-section-2-coupon-api---getting-started)
        - [Create Empty Solution [11]](#create-empty-solution-11)
        - [Create Folder Structure [12]](#create-folder-structure-12)
        - [Create Coupon API [13]](#create-coupon-api-13)
        - [Create Coupon and CouponDTO [14]](#create-coupon-and-coupondto-14)
        - [Install Nuget Packages [15]](#install-nuget-packages-15)
        - [Create AppDbContext [16]](#create-appdbcontext-16)
        - [Create Coupon API Database [17]](#create-coupon-api-database-17)
        - [Seed Database [18]](#seed-database-18)
        - [Get all and Get Coupon by ID [19]](#get-all-and-get-coupon-by-id-19)
        - [Common Response [20]](#common-response-20)
        - [AutoMapper [21]](#automapper-21)
        - [Coupon API CRUD Endpoints [22]](#coupon-api-crud-endpoints-22)
    - [Section 3: Section 3 Coupon API - CRUD](#section-3-section-3-coupon-api---crud)
        - [Create Web Project [23]](#create-web-project-23)
        - [Create Request and Response DTO [24]](#create-request-and-response-dto-24)
        - [Base Service Interface [25]](#base-service-interface-25)
        - [Base Service Implementation [26]](#base-service-implementation-26)
        - [Coupon Service Interface [27]](#coupon-service-interface-27)
        - [Register Services in Program Class File [28]](#register-services-in-program-class-file-28)
        - [Endpoints in Coupon Service [29]](#endpoints-in-coupon-service-29)
        - [Bootswatch Theme and Bootstrap Icons [30]](#bootswatch-theme-and-bootstrap-icons-30)
        - [Coupon Controller [31]](#coupon-controller-31)
        - [API Call in Action [32]](#api-call-in-action-32)
        - [Coupon Index View [33]](#coupon-index-view-33)
        - [Create Coupon View [34]](#create-coupon-view-34)
        - [Create Coupon in Action [35]](#create-coupon-in-action-35)
        - [Delete Coupon and Error [36]](#delete-coupon-and-error-36)
        - [Delete Coupon in Action [37]](#delete-coupon-in-action-37)
        - [Toastr Notifications [38]](#toastr-notifications-38)
    - [Section 4: Section 4 Auth API](#section-4-section-4-auth-api)
        - [Create Auth API and NuGet Packages [39]](#create-auth-api-and-nuget-packages-39)
        - [Add DbContext and Create Identity Tables [40]](#add-dbcontext-and-create-identity-tables-40)
        - [Add Custom Properties to User Table [41]](#add-custom-properties-to-user-table-41)
        - [Endpoints for Login and Register [42]](#endpoints-for-login-and-register-42)
        - [Add DTO's [43]](#add-dtos-43)
        - [Configure JwtOptions [44]](#configure-jwtoptions-44)
        - [IAuth Service [45]](#iauth-service-45)
        - [Register Endpoint in Auth Service [46]](#register-endpoint-in-auth-service-46)
        - [Register in Action [47]](#register-in-action-47)
        - [Login in Action [48]](#login-in-action-48)
        - [Generate Jwt Token [49]](#generate-jwt-token-49)
        - [Token in Action [50]](#token-in-action-50)
        - [Assign Role [51]](#assign-role-51)
    - [Section 5: Section 5 Consuming Auth API](#section-5-section-5-consuming-auth-api)
        - [Add DTO's in Web Project [52]](#add-dtos-in-web-project-52)
        - [Auth Service in Web Project [53]](#auth-service-in-web-project-53)
        - [Auth Controller in Web Project [54]](#auth-controller-in-web-project-54)
        - [Login and Register UI [55]](#login-and-register-ui-55)
        - [Dropdown for Role [56]](#dropdown-for-role-56)
        - [Register in Action with Role [57]](#register-in-action-with-role-57)
        - [Login in Action [58]](#login-in-action-58)
        - [Token Provider Services [59]](#token-provider-services-59)
        - [Sign in a user in .NET Identity [60]](#sign-in-a-user-in-net-identity-60)
        - [Logout in Action [61]](#logout-in-action-61)
        - [Adding Roles in Token [62]](#adding-roles-in-token-62)
        - [Validation with Login and Register [63]](#validation-with-login-and-register-63)
        - [Internal Server Error [64]](#internal-server-error-64)
        - [Addd Authentication to Swagger Gen [65]](#addd-authentication-to-swagger-gen-65)
        - [Passing Token to API [66]](#passing-token-to-api-66)
        - [Clean Code [67]](#clean-code-67)
        - [Roles Demo [68]](#roles-demo-68)
    - [Section 6: Section 6 Product API](#section-6-section-6-product-api)
        - [Product API Base Setup [69]](#product-api-base-setup-69)
        - [Assignment Product API [70]](#assignment-product-api-70)
        - [Assignment Product API in Action [71]](#assignment-product-api-in-action-71)
        - [Assignment - Consuming Product API Part 1 [72]](#assignment---consuming-product-api-part-1-72)
        - [Assignment - Consuming Product API Part 2 [73]](#assignment---consuming-product-api-part-2-73)
    - [Section 7: Section 7 Home Page and Details](#section-7-section-7-home-page-and-details)
        - [Home Controller Index Action [74]](#home-controller-index-action-74)
        - [Home Page UI [75]](#home-page-ui-75)
        - [Details Get Action Method [76]](#details-get-action-method-76)
        - [Details UI [77]](#details-ui-77)
        - [Add Count in Product [78]](#add-count-in-product-78)
    - [Section 8: Section 8 Shopping Cart](#section-8-section-8-shopping-cart)
        - [Create Project and NuGet Packages [79]](#create-project-and-nuget-packages-79)
        - [Create Model and DTO's [80]](#create-model-and-dtos-80)
        - [Basic API Setup [81]](#basic-api-setup-81)
        - [Create Cart API Controller [82]](#create-cart-api-controller-82)
        - [Cart Upsert Logic Part 1 [83]](#cart-upsert-logic-part-1-83)
        - [Cart Upsert Logic Part 2 [84]](#cart-upsert-logic-part-2-84)
        - [Remove Cart Details [85]](#remove-cart-details-85)
        - [Load Shopping Cart [86]](#load-shopping-cart-86)
        - [Calling Product API from Shopping Cart [87]](#calling-product-api-from-shopping-cart-87)
        - [Interservice API Call in Action [88]](#interservice-api-call-in-action-88)
        - [Apply and Remove Coupon Endpoints [89]](#apply-and-remove-coupon-endpoints-89)
        - [Consuming Coupon API [90]](#consuming-coupon-api-90)
    - [Section 9: Section 9 Shopping Cart in Web Project](#section-9-section-9-shopping-cart-in-web-project)
        - [Add Cart Service [91]](#add-cart-service-91)
        - [Load Shopping Cart in Web Project [92]](#load-shopping-cart-in-web-project-92)
        - [Fixing a Bug [93]](#fixing-a-bug-93)
        - [Add Items to Shopping Cart [94]](#add-items-to-shopping-cart-94)
        - [Shopping Cart UI [95]](#shopping-cart-ui-95)
        - [Shopping Cart Functional [96]](#shopping-cart-functional-96)
        - [Delegating Handlers [97]](#delegating-handlers-97)
        - [Shopping Cart Bug [98]](#shopping-cart-bug-98)
        - [Async in Project [99]](#async-in-project-99)
        - [Async vs Sync Communication in Microservice [100]](#async-vs-sync-communication-in-microservice-100)
    - [Section 10: Section 10 Service Bus](#section-10-section-10-service-bus)
        - [Service Bus in our Architecture [101]](#service-bus-in-our-architecture-101)
        - [Create Service Bus in Azure [102]](#create-service-bus-in-azure-102)
        - [Create Queue in Service Bus [103]](#create-queue-in-service-bus-103)
        - [MessageBus Interface [104]](#messagebus-interface-104)
        - [MessageBus Implementation [105]](#messagebus-implementation-105)
        - [Post Message to Service Bus [106]](#post-message-to-service-bus-106)
        - [More Properties in Cart [107]](#more-properties-in-cart-107)
    - [Section 11: Section 11 Email API - Service Bus Receiver](#section-11-section-11-email-api---service-bus-receiver)
        - [Setup Email and DTO's [108]](#setup-email-and-dtos-108)
        - [Implement Processor for Service Bus [109]](#implement-processor-for-service-bus-109)
        - [Register Methods to Processor [110]](#register-methods-to-processor-110)
        - [Register Service Bus Consumer on Application Start [111]](#register-service-bus-consumer-on-application-start-111)
        - [Consuming Messages in Action [112]](#consuming-messages-in-action-112)
        - [Asynchronous Communication in Action [113]](#asynchronous-communication-in-action-113)
        - [Assignment - Register User Queue [114]](#assignment---register-user-queue-114)
        - [Assignment Solution Part 1 - Send Message to Queue [115]](#assignment-solution-part-1---send-message-to-queue-115)
        - [Assignment Solution Part 2 - Processor on Register User Queue [116]](#assignment-solution-part-2---processor-on-register-user-queue-116)
    - [Section 12: Section 12 Checkout UI and Order API](#section-12-section-12-checkout-ui-and-order-api)
        - [Checkout UI [117]](#checkout-ui-117)
        - [Dynamic Checkout UI [118]](#dynamic-checkout-ui-118)
        - [Create Order API [119]](#create-order-api-119)
        - [Add DTO's in Order API [120]](#add-dtos-in-order-api-120)
        - [Order Header and Details Model and DTO's [121]](#order-header-and-details-model-and-dtos-121)
        - [Order API Base Setup [122]](#order-api-base-setup-122)
        - [Mapping Config for Order API [123]](#mapping-config-for-order-api-123)
        - [Constants in Order API [124]](#constants-in-order-api-124)
        - [Order Create Endpoint [125]](#order-create-endpoint-125)
        - [Create Order Service [126]](#create-order-service-126)
        - [Create Order Header [127]](#create-order-header-127)
    - [Section 13: Section 13 Stripe Checkout](#section-13-section-13-stripe-checkout)
        - [Stripe Flow and Stripe DTO [128]](#stripe-flow-and-stripe-dto-128)
        - [Order Confirmation Page [129]](#order-confirmation-page-129)
        - [Configure Stripe in Project [130]](#configure-stripe-in-project-130)
        - [Create Stripe Session in Order API [131]](#create-stripe-session-in-order-api-131)
        - [Call Stripe Session Endpoint from Web Project [132]](#call-stripe-session-endpoint-from-web-project-132)
        - [Stripe Bug [133]](#stripe-bug-133)
        - [Manage Stripe Coupons [134]](#manage-stripe-coupons-134)
        - [Stripe Coupons and Order in Action [135]](#stripe-coupons-and-order-in-action-135)
        - [Validate Stripe Session [136]](#validate-stripe-session-136)
        - [Payment Intent and Status [137]](#payment-intent-and-status-137)
        - [Topic and Subscription in Service Bus [138]](#topic-and-subscription-in-service-bus-138)
    - [Section 14: Section 14 Rewards API](#section-14-section-14-rewards-api)
        - [Create Rewards API [139]](#create-rewards-api-139)
        - [Setup DBContext and Rewards Table [140]](#setup-dbcontext-and-rewards-table-140)
        - [Publish Message to Topic [141]](#publish-message-to-topic-141)
        - [Send Message to Topic in Action [142]](#send-message-to-topic-in-action-142)
        - [Reward Service [143]](#reward-service-143)
        - [Add Service Bus Consumer to Rewards API [144]](#add-service-bus-consumer-to-rewards-api-144)
        - [New Method in Email Service [145]](#new-method-in-email-service-145)
        - [Consumer Order Created Subscription Message [146]](#consumer-order-created-subscription-message-146)
        - [Solving Bug with Consumers [147]](#solving-bug-with-consumers-147)
    - [Section 15: Section 15 Order Management](#section-15-section-15-order-management)
        - [Get All and Individual Order Endpoints [148]](#get-all-and-individual-order-endpoints-148)
        - [Update Order Status Endpoint [149]](#update-order-status-endpoint-149)
        - [Add Endpoints to Order Service [150]](#add-endpoints-to-order-service-150)
        - [Order List UI [151]](#order-list-ui-151)
        - [Configure Database Endpoint [152]](#configure-database-endpoint-152)
        - [Load Datatables [153]](#load-datatables-153)
        - [Order Details Get Action [154]](#order-details-get-action-154)
        - [Dynamic Order Details UI [155]](#dynamic-order-details-ui-155)
        - [Dynamic Status Buttons [156]](#dynamic-status-buttons-156)
        - [Dynamic Status Updates [157]](#dynamic-status-updates-157)
        - [Add Status Filter in URL [158]](#add-status-filter-in-url-158)
        - [Modify Controller to Accept Status [159]](#modify-controller-to-accept-status-159)
        - [Toggle UI Filters [160]](#toggle-ui-filters-160)
        - [Filter in Action [161]](#filter-in-action-161)
        - [Modify Product Model and DTO [162]](#modify-product-model-and-dto-162)
    - [Section 16: Section 16 Upload Images](#section-16-section-16-upload-images)
        - [Post Endpoint in ProductAPI [164]](#post-endpoint-in-productapi-164)
        - [Modify Base Service for Form File [163]](#modify-base-service-for-form-file-163)
        - [Upload Image on Create Product [165]](#upload-image-on-create-product-165)
        - [Solve Bug with Create Product [166]](#solve-bug-with-create-product-166)
        - [Delete Product with Image [167]](#delete-product-with-image-167)
        - [Update Product Image in Action [168]](#update-product-image-in-action-168)
        - [Custom Validation with Data Annotations [169]](#custom-validation-with-data-annotations-169)
    - [Section 17: Gateway](#section-17-gateway)
        - [Gateway Introduction [170]](#gateway-introduction-170)
        - [Create Gateway Project [171]](#create-gateway-project-171)
        - [Configure Application to use Ocelot [172]](#configure-application-to-use-ocelot-172)
        - [Add Authentication to Ocelot [173]](#add-authentication-to-ocelot-173)
        - [Add First Ocelot Route [174]](#add-first-ocelot-route-174)
        - [Product Functional with Ocelot [175]](#product-functional-with-ocelot-175)
        - [Ocelot Coupon Endpoints [176]](#ocelot-coupon-endpoints-176)
        - [Ocelot Assignment [177]](#ocelot-assignment-177)
        - [Shopping Cart Endpoints with Ocelot [178]](#shopping-cart-endpoints-with-ocelot-178)
        - [Order Endpoints in Ocelot [179]](#order-endpoints-in-ocelot-179)
        - [Clean Code [180]](#clean-code-180)
        - [Ocelot Bug [181]](#ocelot-bug-181)
        - [Small UI Update [182]](#small-ui-update-182)
    - [Section 18: Azure Deployment](#section-18-azure-deployment)
        - [Remove Ocelot [183]](#remove-ocelot-183)
        - [Create Database for API's [184]](#create-database-for-apis-184)
        - [Production Appsettings with Azure SQL Database [185]](#production-appsettings-with-azure-sql-database-185)
        - [Deploy Auth API to Azure [186]](#deploy-auth-api-to-azure-186)
        - [Host API and Modify Environment Variable [187]](#host-api-and-modify-environment-variable-187)
        - [Deploy Web Project [188]](#deploy-web-project-188)
        - [Microservices Functional on Azure [189]](#microservices-functional-on-azure-189)
        - [Deploy Gateway Project [190]](#deploy-gateway-project-190)
        - [Gateway in Action on Azure [191]](#gateway-in-action-on-azure-191)
    - [Section 19: RabbitMQ Implementation](#section-19-rabbitmq-implementation)
        - [Installing RabbitMQ [192]](#installing-rabbitmq-192)
        - [New Branch for RabbitMQ [193]](#new-branch-for-rabbitmq-193)
        - [RabbitMQ Message Sender [194]](#rabbitmq-message-sender-194)
        - [Send Message to RabbitMQ Queue [195]](#send-message-to-rabbitmq-queue-195)
        - [Retrieve Message in RabbitMQ Management [196]](#retrieve-message-in-rabbitmq-management-196)
        - [Create Rabbit MQ Consumer Part 1 [197]](#create-rabbit-mq-consumer-part-1-197)
        - [Create Rabbit MQ Consumer Part 2 [198]](#create-rabbit-mq-consumer-part-2-198)
        - [Consuming Message in Action [199]](#consuming-message-in-action-199)
        - [More optimized RabbitMQ Sender [200]](#more-optimized-rabbitmq-sender-200)
        - [Assignment - Email Functionality with RabbitMQ [201]](#assignment---email-functionality-with-rabbitmq-201)
        - [Assignment - Send Message to Queue [202]](#assignment---send-message-to-queue-202)
        - [Assignment - Consumer Message in Action [203]](#assignment---consumer-message-in-action-203)
        - [Publish to Fanout [204]](#publish-to-fanout-204)
        - [Publish to Fanout in Action [205]](#publish-to-fanout-in-action-205)
        - [Fanout in Action [206]](#fanout-in-action-206)
        - [Direct Exchange Rabbit MQ Sender [207]](#direct-exchange-rabbit-mq-sender-207)
        - [Demo - Direct Message [208]](#demo---direct-message-208)

<!-- /TOC -->
## Section 2 Intro
### Microservice Architecture

- 1 mS = responsible for 1 functionality
- 1 mS = separate db

- Product mS and db
- Coupon mS and db
- Shopping Cart mS and db
- Email mS and db
- Order mS and db
- Rewards mS (no DB?) - track all the rewards 
- .BET Identity microservice - responsible for auth across all the mS

- tightly coupled

- MVC dependency nightmare



## Section 2: Section 2 Coupon API - Getting Started

### Create Empty Solution [11]

### Create Folder Structure [12]

- FrontEnd
- Gateway
- Integration
- Services

### Create Coupon API [13]

Swagger is embedded.

Random port -> change to closely assigned ports

Properties -> launchSettings.json

Change to 7001

```json
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "https://localhost:7001;http://localhost:5118",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
```

https://localhost:7001/swagger/index.html

### Create Coupon and CouponDTO [14]

VS -> Color Tabs by project selected. Wow!

Model and DTO
- Model - complete object
- DTO - props we need. 

Typically return DTO while working with an API 

### Install Nuget Packages [15]

Nugets, Checkbox [ ] Include pre-release 

- AutoMapper
- AutoMapper.Extensions.Microsoft.DependencyInjection
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.AspNetCore.OpenApi
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools

#### Entity Framework Core Tools
Entity Framework Core Tools for the NuGet Package Manager Console in Visual Studio.

Enables these commonly used commands:
- Add-Migration
- Bundle-Migration
- Drop-Database
- Get-DbContext
- Get-Migration
- Optimize-DbContext
- Remove-Migration
- Scaffold-DbContext
- Script-Migration
- Update-Database

### Create AppDbContext [16]

```cs
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }
    }
```

### Create Coupon API Database [17]

In Production - use Azure KeyVault for connection strings

**Issue:**

System.Globalization.CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode
Only the invariant culture is supported in globalization-invariant mode. See https://aka.ms/GlobalizationInvariantMode for more information. (Parameter 'name')
en-us is an invalid culture identifier.

**Solution:**

Set

```xml
<InvariantGlobalization>false</InvariantGlobalization>
```

**Issue:**

A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: SNI_PN11, error: 50 - Local Database Runtime error occurred. The specified LocalDB instance does not exist.

**Solution:**

Change connection str (LocalDb)\\DESKTOP-COMP -> .

```json
"DefaultConnection": "Server=.;Database=Mango_Coupon;Trusted_Connection=True;TrustServerCertificate=True"
```

### Seed Database [18]

Seed Database = Override OnModelCreating() in AppDbContext.

```cs
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Later identity won't work without it!


            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 1,
                CouponCode = "10OFF",
                DiscountAmount = 10,
                MinAmount = 20
            });


            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "20OFF",
                DiscountAmount = 20,
                MinAmount = 40
            });
        }
```

Add-Migration seedCouponTables

#### Automatically apply pending migrations on App Start

Check if there are pending migrations and apply them.

```cs
ApplyMigrations();

app.Run();


void ApplyMigrations()
{
    using (var scope = app.Services.CreateScope())
    {
        var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if (_db.Database.GetPendingMigrations().Count() > 0)
        {
            _db.Database.Migrate();
        }
    }
}
```

### Get all and Get Coupon by ID [19]
### Common Response [20]
### AutoMapper [21]
### Coupon API CRUD Endpoints [22]
## Section 3: Section 3 Coupon API - CRUD
### Create Web Project [23]
### Create Request and Response DTO [24]
### Base Service Interface [25]
### Base Service Implementation [26]
### Coupon Service Interface [27]
### Register Services in Program Class File [28]
### Endpoints in Coupon Service [29]
### Bootswatch Theme and Bootstrap Icons [30]
### Coupon Controller [31]
### API Call in Action [32]
### Coupon Index View [33]
### Create Coupon View [34]
### Create Coupon in Action [35]
### Delete Coupon and Error [36]
### Delete Coupon in Action [37]
### Toastr Notifications [38]
## Section 4: Section 4 Auth API
### Create Auth API and NuGet Packages [39]
### Add DbContext and Create Identity Tables [40]
### Add Custom Properties to User Table [41]
### Endpoints for Login and Register [42]
### Add DTO's [43]
### Configure JwtOptions [44]
### IAuth Service [45]
### Register Endpoint in Auth Service [46]
### Register in Action [47]
### Login in Action [48]
### Generate Jwt Token [49]
### Token in Action [50]
### Assign Role [51]
## Section 5: Section 5 Consuming Auth API
### Add DTO's in Web Project [52]
### Auth Service in Web Project [53]
### Auth Controller in Web Project [54]
### Login and Register UI [55]
### Dropdown for Role [56]
### Register in Action with Role [57]
### Login in Action [58]
### Token Provider Services [59]
### Sign in a user in .NET Identity [60]
### Logout in Action [61]
### Adding Roles in Token [62]
### Validation with Login and Register [63]
### Internal Server Error [64]
### Addd Authentication to Swagger Gen [65]
### Passing Token to API [66]
### Clean Code [67]
### Roles Demo [68]
## Section 6: Section 6 Product API
### Product API Base Setup [69]
### Assignment Product API [70]
### Assignment Product API in Action [71]
### Assignment - Consuming Product API Part 1 [72]
### Assignment - Consuming Product API Part 2 [73]
## Section 7: Section 7 Home Page and Details
### Home Controller Index Action [74]
### Home Page UI [75]
### Details Get Action Method [76]
### Details UI [77]
### Add Count in Product [78]
## Section 8: Section 8 Shopping Cart
### Create Project and NuGet Packages [79]
### Create Model and DTO's [80]
### Basic API Setup [81]
### Create Cart API Controller [82]
### Cart Upsert Logic Part 1 [83]
### Cart Upsert Logic Part 2 [84]
### Remove Cart Details [85]
### Load Shopping Cart [86]
### Calling Product API from Shopping Cart [87]
### Interservice API Call in Action [88]
### Apply and Remove Coupon Endpoints [89]
### Consuming Coupon API [90]
## Section 9: Section 9 Shopping Cart in Web Project
### Add Cart Service [91]
### Load Shopping Cart in Web Project [92]
### Fixing a Bug [93]
### Add Items to Shopping Cart [94]
### Shopping Cart UI [95]
### Shopping Cart Functional [96]
### Delegating Handlers [97]
### Shopping Cart Bug [98]
### Async in Project [99]
### Async vs Sync Communication in Microservice [100]
## Section 10: Section 10 Service Bus
### Service Bus in our Architecture [101]
### Create Service Bus in Azure [102]
### Create Queue in Service Bus [103]
### MessageBus Interface [104]
### MessageBus Implementation [105]
### Post Message to Service Bus [106]
### More Properties in Cart [107]
## Section 11: Section 11 Email API - Service Bus Receiver
### Setup Email and DTO's [108]
### Implement Processor for Service Bus [109]
### Register Methods to Processor [110]
### Register Service Bus Consumer on Application Start [111]
### Consuming Messages in Action [112]
### Asynchronous Communication in Action [113]
### Assignment - Register User Queue [114]
### Assignment Solution Part 1 - Send Message to Queue [115]
### Assignment Solution Part 2 - Processor on Register User Queue [116]
## Section 12: Section 12 Checkout UI and Order API
### Checkout UI [117]
### Dynamic Checkout UI [118]
### Create Order API [119]
### Add DTO's in Order API [120]
### Order Header and Details Model and DTO's [121]
### Order API Base Setup [122]
### Mapping Config for Order API [123]
### Constants in Order API [124]
### Order Create Endpoint [125]
### Create Order Service [126]
### Create Order Header [127]
## Section 13: Section 13 Stripe Checkout
### Stripe Flow and Stripe DTO [128]
### Order Confirmation Page [129]
### Configure Stripe in Project [130]
### Create Stripe Session in Order API [131]
### Call Stripe Session Endpoint from Web Project [132]
### Stripe Bug [133]
### Manage Stripe Coupons [134]
### Stripe Coupons and Order in Action [135]
### Validate Stripe Session [136]
### Payment Intent and Status [137]
### Topic and Subscription in Service Bus [138]
## Section 14: Section 14 Rewards API
### Create Rewards API [139]
### Setup DBContext and Rewards Table [140]
### Publish Message to Topic [141]
### Send Message to Topic in Action [142]
### Reward Service [143]
### Add Service Bus Consumer to Rewards API [144]
### New Method in Email Service [145]
### Consumer Order Created Subscription Message [146]
### Solving Bug with Consumers [147]
## Section 15: Section 15 Order Management
### Get All and Individual Order Endpoints [148]
### Update Order Status Endpoint [149]
### Add Endpoints to Order Service [150]
### Order List UI [151]
### Configure Database Endpoint [152]
### Load Datatables [153]
### Order Details Get Action [154]
### Dynamic Order Details UI [155]
### Dynamic Status Buttons [156]
### Dynamic Status Updates [157]
### Add Status Filter in URL [158]
### Modify Controller to Accept Status [159]
### Toggle UI Filters [160]
### Filter in Action [161]
### Modify Product Model and DTO [162]
## Section 16: Section 16 Upload Images
### Post Endpoint in ProductAPI [164]
### Modify Base Service for Form File [163]
### Upload Image on Create Product [165]
### Solve Bug with Create Product [166]
### Delete Product with Image [167]
### Update Product Image in Action [168]
### Custom Validation with Data Annotations [169]
## Section 17: Gateway
### Gateway Introduction [170]
### Create Gateway Project [171]
### Configure Application to use Ocelot [172]
### Add Authentication to Ocelot [173]
### Add First Ocelot Route [174]
### Product Functional with Ocelot [175]
### Ocelot Coupon Endpoints [176]
### Ocelot Assignment [177]
### Shopping Cart Endpoints with Ocelot [178]
### Order Endpoints in Ocelot [179]
### Clean Code [180]
### Ocelot Bug [181]
### Small UI Update [182]
## Section 18: Azure Deployment
### Remove Ocelot [183]
### Create Database for API's [184]
### Production Appsettings with Azure SQL Database [185]
### Deploy Auth API to Azure [186]
### Host API and Modify Environment Variable [187]
### Deploy Web Project [188]
### Microservices Functional on Azure [189]
### Deploy Gateway Project [190]
### Gateway in Action on Azure [191]
## Section 19: RabbitMQ Implementation
### Installing RabbitMQ [192]
### New Branch for RabbitMQ [193]
### RabbitMQ Message Sender [194]
### Send Message to RabbitMQ Queue [195]
### Retrieve Message in RabbitMQ Management [196]
### Create Rabbit MQ Consumer Part 1 [197]
### Create Rabbit MQ Consumer Part 2 [198]
### Consuming Message in Action [199]
### More optimized RabbitMQ Sender [200]
### Assignment - Email Functionality with RabbitMQ [201]
### Assignment - Send Message to Queue [202]
### Assignment - Consumer Message in Action [203]
### Publish to Fanout [204]
### Publish to Fanout in Action [205]
### Fanout in Action [206]
### Direct Exchange Rabbit MQ Sender [207]
### Demo - Direct Message [208]
