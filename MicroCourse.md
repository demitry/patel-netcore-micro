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
            - [Entity Framework Core Tools](#entity-framework-core-tools)
        - [Create AppDbContext [16]](#create-appdbcontext-16)
        - [Create Coupon API Database [17]](#create-coupon-api-database-17)
        - [Seed Database [18]](#seed-database-18)
            - [Automatically apply pending migrations on App Start](#automatically-apply-pending-migrations-on-app-start)
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
        - [VS - Run Multiple projects](#vs---run-multiple-projects)
        - [Bootswatch Theme and Bootstrap Icons [30]](#bootswatch-theme-and-bootstrap-icons-30)
        - [](#)
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
            - [Use Token Code - Login Code](#use-token-code---login-code)
            - [Request](#request)
            - [Response](#response)
            - [Token](#token)
        - [Assign Role [51]](#assign-role-51)
            - [Populate Roles on login AspNetRoles Assign Role AspNetUserRoles](#populate-roles-on-login-aspnetroles-assign-role-aspnetuserroles)
            - [Test](#test)
                - [Request](#request)
                - [Response](#response)
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
        - [Add Authentication to Swagger Gen [65]](#add-authentication-to-swagger-gen-65)
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

```cs
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CouponApiController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CouponApiController(AppDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public object Get()
        {
            try
            {
                List<Coupon> couponList =  _db.Coupons.ToList();
                return couponList;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        [HttpGet]
        [Route("{id:int}")] // Without the route Swagger will error Fetch error response status is 500 https://localhost:7001/swagger/v1/swagger.json
        public object Get(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.First(c => c.CouponId == id);
                return coupon;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}

```
### Common Response [20]

return Coupon, return List<Coupon>...  Need Common Response

Common Response for API

```cs
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
```

```cs
    public class CouponApiController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;

        public CouponApiController(AppDbContext db)
        {
            _db = db;
            _response = new ResponseDto();
        }
        
        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                List<Coupon> couponList =  _db.Coupons.ToList();
                _response.Result = couponList;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.First(c => c.CouponId == id);
                _response.Result = coupon;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
```

### AutoMapper [21]

```cs
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
            return mappingConfig;
        }
    }

```

Program.cs:

```cs
...

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
...
```

### Coupon API CRUD Endpoints [22]

```cs
        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                Coupon coupon = _db.Coupons.First(c => c.CouponCode.ToLower() == code.ToLower());

                //if FirstOrDefault() => have to check for null
                //Coupon coupon = _db.Coupons.FirstOrDefault(c => c.CouponCode.ToLower() == code.ToLower());
                //if(coupon == null)
                //{
                //    _response.IsSuccess = false;
                //}

                _response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon coupon = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Add(coupon);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon coupon = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Update(coupon);
                _db.SaveChanges();

                _response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpDelete]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.First(c => c.CouponId == id);
                _db.Coupons.Remove(coupon);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
```

## Section 3: Section 3 Coupon API - CRUD
### Create Web Project [23]
### Create Request and Response DTO [24]

Copy ResponseDto.cs and change namespace.

For mS it is common: "So keeping the models isolated to their corresponding project is important when you are building microservices."

### Base Service Interface [25]

### Base Service Implementation [26]

MediaTypeNames.Application.Json

https://github.com/dotnet/corefx/blob/master/src/System.Net.Mail/src/System/Net/Mime/MediaTypeNames.cs

MediaTypeNames  

MediaTypeNames.Application.Json

```cs
            public const string Json = "application/json" 
            ...

    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, MediaTypeNames.Application.Json);
```

```cs
    public static class ExtensionMethods
    {
        public static HttpMethod ToHttpMethod(this ApiType apiType)
        {
            switch (apiType)
            {
                case ApiType.POST: return HttpMethod.Post;
                case ApiType.DELETE: return HttpMethod.Delete;
                case ApiType.PUT: return HttpMethod.Put;
                default: return HttpMethod.Get;
            }
        }

        public static async Task<ResponseDto?> ToResponseDtoAsync(this HttpResponseMessage? httpResponseMessage)
        {
            switch (httpResponseMessage.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new() { IsSuccess = false, Message = "Not Found" };
                case HttpStatusCode.Forbidden:
                    return new() { IsSuccess = false, Message = "Access Denied" };
                case HttpStatusCode.Unauthorized:
                    return new() { IsSuccess = false, Message = "Unauthorized" };
                case HttpStatusCode.InternalServerError:
                    return new() { IsSuccess = false, Message = "Internal Server Error" };
                default:
                    var apiContent = await httpResponseMessage.Content.ReadAsStringAsync();
                    var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                    return apiResponseDto;
            }
        }
    }
```

```cs
    public class BaseService : IBaseService
    {
        private IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient("MangoApi");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", MediaTypeNames.Application.Json);
            //tbd: token

            message.RequestUri = new Uri(requestDto.Url);
            if (requestDto.Data != null) // for post
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data),
                    Encoding.UTF8, MediaTypeNames.Application.Json);
            }

            message.Method = requestDto.ApiType.ToHttpMethod();
            HttpResponseMessage? apiResponse = await httpClient.SendAsync(message);
            return await apiResponse.ToResponseDtoAsync();
        }
    }
```

### Coupon Service Interface [27]



### Register Services in Program Class File [28]
```cs
using Mango.Web.Service.IService;
using Mango.Web.Service;
using Mango.Web.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ICouponService, CouponService>();
ServiceUrls.CouponAPIBase = builder.Configuration["ServiceUrls:CouponAPI"];

builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<ICouponService, CouponService>();

var app = builder.Build();
...
```

### Endpoints in Coupon Service [29]

```cs
using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using System;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.POST,
                Data = couponDto,
                Url = ServiceUrls.CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.DELETE,
                Url = ServiceUrls.CouponAPIBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto() 
            { 
                ApiType = ApiType.GET,
                Url = ServiceUrls.CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = ServiceUrls.CouponAPIBase + "/api/coupon/GetByCode/" + couponCode
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.GET,
                Url = ServiceUrls.CouponAPIBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = ApiType.PUT,
                Data = couponDto,
                Url = ServiceUrls.CouponAPIBase + "/api/coupon"
            });
        }
    }
}

```
### VS - Run Multiple projects

- Solution -> Configure Startup Projects...
- Multiple Startup Projects
- Action = Start

### Bootswatch Theme and Bootstrap Icons [30]

https://bootswatch.com/

Slate Theme

https://icons.getbootstrap.com/

###     

Fixed "Not Found" - fixed route

```cs
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? list = new();
            ResponseDto? responseDto = await _couponService.GetAllCouponsAsync();
            
            if(responseDto != null && responseDto.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(responseDto.Result));
            }
            return View(list);
        }
    }
```

### API Call in Action [32]

### Coupon Index View [33]

### Create Coupon View [34]

```cs
        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }
```

```cs
@model CouponDto

<form asp-action="CouponCreate">
    @* action to post a form *@
    <br />
    <div class="container border p-3">
        <h1 class="text-white text-center">Create Coupon</h1>

        <hr />
        <div class="row">
            <div class="col-2">
                <label class="control-label pt-2" style="font-size:20px;"> Coupon Code</label>
            </div>
            <div class="col-10 pb-3">
                <input asp-for="CouponCode" class="form-control" />
                <span asp-validation-for="CouponCode" class="text-danger"></span>
            </div>
            <div class="col-2">
                <label class="control-label pt-2" style="font-size:20px;">Discount Amount</label>
            </div>
            <div class="col-10 pb-3">
                <input asp-for="DiscountAmount" class="form-control" />
                <span asp-validation-for="DiscountAmount" class="text-danger"></span>
            </div>
            <div class="col-2">
                <label class="control-label pt-2" style="font-size:20px;">Minimum Amount</label>
            </div>
            <div class="col-10 pb-3">
                <input asp-for="MinAmount" class="form-control" />
                <span asp-validation-for="MinAmount" class="text-danger"></span>
            </div>

            <div class="col-5 offset-2">

                <a asp-action="CouponIndex" class="btn-primary btn form-control ">Back to List</a>
            </div>
            <div class="col-5">
                <input type="submit" value="Create" class="btn btn-success form-control" />
            </div>
        </div>
        <div>
        </div>
    </div>
</form>

@section Scripts {
    <partial name="_ValidationScriptsPartial" />
}
```

### Create Coupon in Action [35]

```cs
        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _couponService.CreateCouponAsync(model);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(CouponIndex));
                }
            }

            return View(model);
        }
```

### Delete Coupon and Error [36]

```cs
        public async Task<IActionResult> CouponDelete(int couponId)
        {
            ResponseDto? response = await _couponService.GetCouponByIdAsync(couponId);

            if (response != null && response.IsSuccess)
            {
                CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDto couponDto)
        {
            ResponseDto? response = await _couponService.DeleteCouponAsync(couponDto.CouponId);

            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(CouponIndex));
            }

            return View(couponDto);
        }
```

```cs
@model CouponDto

<form asp-action="CouponDelete">
    <br />
    <div class="container border p-3">
        <h1 class="text-white text-center">Delete Coupon</h1>
        <input asp-for="CouponId" hidden />
        <hr />
        <div class="row">
            <div class="col-2">
                <label class="control-label pt-2" style="font-size:20px;"> Coupon Code</label>
            </div>
            <div class="col-10 pb-3">
                <input asp-for="CouponCode" disabled class="form-control" />
            </div>
            <div class="col-2">
                <label class="control-label pt-2" style="font-size:20px;">Discount Amount</label>
            </div>
            <div class="col-10 pb-3">
                <input asp-for="DiscountAmount" disabled class="form-control" />
            </div>
            <div class="col-2">
                <label class="control-label pt-2" style="font-size:20px;">Minimum Amount</label>
            </div>
            <div class="col-10 pb-3">
                <input asp-for="MinAmount" disabled class="form-control" />
            </div>

            <div class="col-5 offset-2">
                <a asp-action="CouponIndex" class="btn-primary btn form-control ">Back to List</a>
            </div>
            <div class="col-5">
                <input type="submit" value="Delete" class="btn btn-danger form-control" />
            </div>
        </div>
    </div>
</form>
```

### Delete Coupon in Action [37]

```cs
        public async Task<IActionResult> CouponDelete(int couponId)
        {
            ResponseDto? response = await _couponService.GetCouponByIdAsync(couponId);

            if (response != null && response.IsSuccess)
            {
                CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDto couponDto)
        {
            ResponseDto? response = await _couponService.DeleteCouponAsync(couponDto.CouponId);

            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(CouponIndex));
            }

            return View(couponDto);
        }
```

We will not update the coupon. Why? We'll see later.

### Toastr Notifications [38]

Don't forget to include after the @RenderBody()
```cs
        <main role="main" class="pb-3">
            @RenderBody()
            <partial name="_Notifications" />
        </main>
```

## Section 4: Section 4 Auth API

### Create Auth API and NuGet Packages [39]

```cs
    <PackageReference Include="AutoMapper" Version="12.0.1" />
    <PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="12.0.1" />
    <PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="7.0.11" />
    <PackageReference Include="Microsoft.AspNetCore.OpenApi" Version="7.0.11" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="7.0.11" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.11" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="7.0.11">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0" />
```

### Add DbContext and Create Identity Tables [40]

- launchSettings.json - change port number
- Copy Data folder, update namespace
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Remove InvariantGlobalization true from project
- Set Connection String in appsettinigs.json: 
  - "DefaultConnection": "Server=.;Database=Mango_Auth;Trusted_Connection=True;TrustServerCertificate=True"
- Use IdentityDbContext, not DbContext:
- IdentityDbContext < IdentityUser > :
- Add-Migration addIdentityTables
- Update-Database
- Check the Mango_Auth Database

```cs
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.AuthAPI.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

```

### Add Custom Properties to User Table [41]

```sql
SELECT TOP (1000) [Id]
      ,[UserName]
      ,[NormalizedUserName]
      ,[Email]
      ,[NormalizedEmail]
      ,[EmailConfirmed]
      ,[PasswordHash]
      ,[SecurityStamp]
      ,[ConcurrencyStamp]
      ,[PhoneNumber]
      ,[PhoneNumberConfirmed]
      ,[TwoFactorEnabled]
      ,[LockoutEnd]
      ,[LockoutEnabled]
      ,[AccessFailedCount]
  FROM [Mango_Auth].[dbo].[AspNetUsers]
```

Want more properties ?

- Change Identity User to Application User
 - define class ApplicationUser : IdentityUser
 - in AppDBContext
 - in Program
- You might been thinking that it will create new table "ApplicationUser"
- But EF is smart
- Application user is extending the identity user
- EF will add 1 more column.
- Add-Migration addNameToAspNetUsers
- Update-Database

```cs
using Microsoft.AspNetCore.Identity;

namespace Mango.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}

```

### Endpoints for Login and Register [42]

```cs
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }
    }
}

```

2 endpoints:

- Mango.Services.AuthAPI 1.0 OAS3
- https://localhost:7002/swagger/v1/swagger.json
- AuthApi
- POST /api/auth/register
- POST /api/auth/login

### Add DTO's [43]

- We don't need all db properties in the UserDto
- User Id will be the guid, so it will be a string, not the integer!

### Configure JwtOptions [44]

- When we work with authentication, we deal with creating JWT token.
- It is used to validate a user that has logged in.
- Login Response has Token
- That token generated with the help of a secret key.

Settings to configure:

```json
  "ApiSettings": {
    "JwtOptions": {
      "Secret": "THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET",
      "Issuer": "mango-auth-api",
      "Audience": "mango-client"
    }
  }
```

- Can access it with the Configuration object
- Or config like that:

```cs

    public class JwtOptions
    {
        public string Secret { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
    }

// And in Program.cs:

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection($"ApiSettings:{nameof(JwtOptions)}"));

```

### IAuth Service [45]

```cs
using Mango.Services.AuthAPI.Data;
using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Models.Dto;
using Mango.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace Mango.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(AppDbContext db,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> Register(RegistrationRequestDto registrationRequestDto)
        {
            throw new NotImplementedException();
        }
    }
}

```

### Register Endpoint in Auth Service [46]

All the heavy-lifting with hashing password is done by .NET Identity

```cs
        public async Task<UserDto> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                Name = registrationRequestDto.Name,
                PhoneNumber = registrationRequestDto.PhoneNumber
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
                // All the heavy-lifting with hashing password is done by .NET Identity
                
                if(result.Succeeded)
                {
                    var userRoReturn = _db.ApplicationUsers
                        .First(u => u.UserName == registrationRequestDto.Email);

                    UserDto userDto = new UserDto()
                    {
                        Email = userRoReturn.Email,
                        ID = userRoReturn.Id,
                        Name = userRoReturn.Name,
                        PhoneNumber = userRoReturn.PhoneNumber
                    };
                    return userDto;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return new UserDto();
        }
```

### Register in Action [47]

program

```cs
builder.Services.AddScoped<IAuthService, AuthService>();
```

```cs
        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                Name = registrationRequestDto.Name,
                PhoneNumber = registrationRequestDto.PhoneNumber
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
                // All the heavy-lifting with hashing password is done by .NET Identity
                
                if(result.Succeeded)
                {
                    var userRoReturn = _db.ApplicationUsers
                        .First(u => u.UserName == registrationRequestDto.Email);

                    UserDto userDto = new UserDto()
                    {
                        Email = userRoReturn.Email,
                        ID = userRoReturn.Id,
                        Name = userRoReturn.Name,
                        PhoneNumber = userRoReturn.PhoneNumber
                    };
                    return string.Empty;
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
```

```cs

    public class AuthApiController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDto _response;
        public AuthApiController(IAuthService authService)
        {
            _authService = authService;
            _response = new();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var errorMessage = await _authService.Register(model);
            if (!errorMessage.IsNullOrEmpty())
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(errorMessage);
            }
            return Ok(_response);
        }
        ...
    }
    
```

```
curl -X 'POST' \
  'https://localhost:7002/api/auth/register' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "email": "string@string.com",
  "name": "string",
  "phoneNumber": "string",
  "password": "String123!",
  "role": "string"
}'
```

### Login in Action [48]

```cs
        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());

            if(user == null)
            {
                return new LoginResponseDto() { User = null, Token = string.Empty };
            }

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if(!isValid)
            {
                return new LoginResponseDto() { User = null, Token = string.Empty };
            }

            // If user was found and password OK, generate JWT token

            UserDto userDto = new()
            {
                Email = user.Email,
                ID = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber
            };

            LoginResponseDto loginResponseDto = new()
            {
                User = userDto,
                Token = "" //todo: Generate
            };

            return loginResponseDto;
        }
```

```cs
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);

            if(loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(loginResponse);
            }
            return Ok(_response);
        }
```


```
curl -X 'POST' \
  'https://localhost:7002/api/auth/login' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "userName": "string@string.com",
  "password": "String123!"
}'

Response:
{
  "result": null,
  "isSuccess": true,
  "message": ""
}

```

### Generate Jwt Token [49]

JwtTokenGenerator.cs:

```cs
using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Service.IService;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mango.Services.AuthAPI.Service
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtOptions _jwtOptions;

        public JwtTokenGenerator(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public string GenerateToken(ApplicationUser applicationUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            
            var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret); 

            var claimList = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, applicationUser.Email),
                new Claim(JwtRegisteredClaimNames.Sub, applicationUser.Id),
                new Claim(JwtRegisteredClaimNames.Name, applicationUser.UserName.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _jwtOptions.Audience,
                Issuer = _jwtOptions.Issuer,
                Subject = new ClaimsIdentity(claimList),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}


```

### Token in Action [50]

#### Use Token Code - Login Code

```cs
        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => 
                u.UserName.ToLower() == loginRequestDto.UserName.ToLower());

            if(user == null)
            {
                return new LoginResponseDto() { User = null, Token = string.Empty };
            }

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if(!isValid)
            {
                return new LoginResponseDto() { User = null, Token = string.Empty };
            }

            // If user was found and password is OK, generate JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            UserDto userDto = new()
            {
                Email = user.Email,
                ID = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber
            };

            LoginResponseDto loginResponseDto = new()
            {
                User = userDto,
                Token = token
            };

            return loginResponseDto;
        }
```

#### Request

https://localhost:7002/api/auth/login

```cs
curl -X 'POST' \
  'https://localhost:7002/api/auth/login' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "userName": "string@string.com",
  "password": "String123!"
}'
```

#### Response

{
  "result": {
    "user": {
      "id": "12e98410-a56d-4f95-ad1c-3d0e8b069fc9",
      "email": "string@string.com",
      "name": "string",
      "phoneNumber": "string"
    },
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InN0cmluZ0BzdHJpbmcuY29tIiwic3ViIjoiMTJlOTg0MTAtYTU2ZC00Zjk1LWFkMWMtM2QwZThiMDY5ZmM5IiwibmFtZSI6InN0cmluZ0BzdHJpbmcuY29tIiwibmJmIjoxNjk1Mjc1Nzg5LCJleHAiOjE2OTU4ODA1ODksImlhdCI6MTY5NTI3NTc4OSwiaXNzIjoibWFuZ28tYXV0aC1hcGkiLCJhdWQiOiJtYW5nby1jbGllbnQifQ.40VBe2_1kM4MYFaIjP1i0E84Oad6osm1wQI3PD4N8tU"
  },
  "isSuccess": true,
  "message": ""
}

#### Token

https://jwt.io/

Decoded:

- Header:
```json
{
  "alg": "HS256",
  "typ": "JWT"
}
```

- PAYLOAD:

```json
{
  "email": "string@string.com",
  "sub": "12e98410-a56d-4f95-ad1c-3d0e8b069fc9",
  "name": "string@string.com",
  "nbf": 1695275789,
  "exp": 1695880589,
  "iat": 1695275789,
  "iss": "mango-auth-api",
  "aud": "mango-client"
}

```

### Assign Role [51]

AspNetRoles, AspNetUserRoles tables

#### Populate Roles on login (AspNetRoles) Assign Role (AspNetUserRoles)

Auth Service:

```cs
        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

            if (user == null)
            {
                return false;
            }

            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                var createResult = _roleManager.CreateAsync(new IdentityRole(roleName));
                
                if(!createResult.Result.Succeeded)
                { 
                    return false; 
                }
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);

            return result.Succeeded;
        }
```
Controller:
```cs
        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            bool roleAssigned = await _authService.AssignRole(model.Email, model.Role.ToUpper());

            if (!roleAssigned)
            {
                _response.IsSuccess = false;
                _response.Message = "Error occurred. Cannot Assign Role";
                return BadRequest(_response);
            }

            return Ok(_response);
        }
```

#### Test

string1@string.com

String123!

##### Request

{
  "email": "string1@string.com",
  "name": "string",
  "phoneNumber": "string",
  "password": "String123!",
  "role": "Admin"
}

```
curl -X 'POST' \
  'https://localhost:7002/api/auth/AssignRole' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "email": "string1@string.com",
  "name": "string",
  "phoneNumber": "string",
  "password": "String123!",
  "role": "Admin"
}'
```

##### Response
```
{
  "result": null,
  "isSuccess": true,
  "message": ""
}
```
Db is OK

## Section 5: Section 5 Consuming Auth API

### Add DTO's in Web Project [52]

### Auth Service in Web Project [53]

### Auth Controller in Web Project [54]

### Login and Register UI [55]

### Dropdown for Role [56]

Via ViewBag:

```cs
[HttpGet]
public IActionResult Register()
{
    var roleList = new List<SelectListItem>()
    {
        new SelectListItem{ Text = AppRole.Admin, Value = AppRole.Admin },
        new SelectListItem{ Text = AppRole.Customer, Value = AppRole.Customer }
    };
    ViewBag.RoleList = roleList;
    return View();
}
```

```cs
<div class="col-12 col-md-6 offset-md-3 pb-2">
    <select asp-for="Role" class="form-select" asp-items="@ViewBag.RoleList">
        <option disabled selected>--Select Role--</option>
    </select>
</div>
```

### Register in Action with Role [57]

```cs
        void PopulateViewBagRoleList()
        {
            ViewBag.RoleList = new List<SelectListItem>()
            {
                new SelectListItem{ Text = AppRole.Admin, Value = AppRole.Admin },
                new SelectListItem{ Text = AppRole.Customer, Value = AppRole.Customer }
            };
        }

        [HttpGet]
        public IActionResult Register()
        {
            PopulateViewBagRoleList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDto registerDto)
        {
            ResponseDto result = await _authService.RegisterAsync(registerDto);

            ResponseDto assignRoleDto;

            if (result != null && result.IsSuccess)
            {
                if (string.IsNullOrEmpty(registerDto.Role))
                {
                    registerDto.Role = AppRole.Customer;
                }

                assignRoleDto = await _authService.AssignRoleAsync(registerDto);

                if (assignRoleDto != null && assignRoleDto.IsSuccess)
                {
                    TempData["success"] = "Registration Successful";
                    return RedirectToAction(nameof(Login));
                }
            }

            PopulateViewBagRoleList();

            return View(registerDto);
        }

```

string2@string.com

String123!

### Login in Action [58]

```cs
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            ResponseDto responseDto = await _authService.LoginAsync(loginRequestDto);

            if (responseDto != null && responseDto.IsSuccess)
            {
                LoginResponseDto loginResponseDto =
                    JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", responseDto.Message);
                return View(loginRequestDto);
            }
        }
```

Fixed issue with login bad request.

```cs
                case HttpStatusCode.BadRequest:
                    return new() { IsSuccess = false, Message = "Bad Request" };
```


### Token Provider Services [59]

- When we logging in - we receive the token
- Could be saved in session, we will save it in cookie.
- Working with cookies - inject IHttpContextAccessor
- Config in startup class

```cs
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public TokenProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void ClearToken() => _contextAccessor.HttpContext?.Response.Cookies.Delete(Constant.TokenCookie);

        public string? GetToken() => _contextAccessor.HttpContext?.Request.Cookies.TryGetValue(Constant.TokenCookie, out string? token) is true ? token : null;

        public void SetToken(string token) => _contextAccessor.HttpContext?.Response.Cookies.Append(Constant.TokenCookie, token);
    }
}

```

### Sign in a user in .NET Identity [60]

```cs
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            ResponseDto responseDto = await _authService.LoginAsync(loginRequestDto);

            if (responseDto != null && responseDto.IsSuccess)
            {
                LoginResponseDto loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));

                await SignInUser(loginResponseDto);  // SIGN-IN

                _tokenProvider.SetToken(loginResponseDto.Token);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", responseDto.Message);
                return View(loginRequestDto);
            }
        }
```

```cs
        private async Task SignInUser(LoginResponseDto loginResponseDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.ReadJwtToken(loginResponseDto.Token);
            
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, jwt.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Email).Value),
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value),
                new Claim(JwtRegisteredClaimNames.Name, jwt.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Name).Value),
            };
         
            identity.AddClaims(claims);

            var principal = new ClaimsPrincipal(identity);
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
```

DO NOT FORGET

Program:

```cs
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(10);
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied"; //TODO: Add this page
    });

...

app.UseAuthentication();
```

### Logout in Action [61]

```cs
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenProvider.ClearToken();

            return RedirectToAction("Index", "Home");
        }
```

### Adding Roles in Token [62]

- Having role in the token is CRITICAL when we work with Authorization
- Add on the API level
- It is possible to have multiple roles

```
string3@string.com
Test123!
```

- No connection could be made because the target machine actively refused it. (localhost:7002)
- Service is not run 
- VS -> SLN -> Configure Startup Projects.

### Validation with Login and Register [63]

- [ ] Why I have Bad Request While Register with fake data?
	- [ ] Why is this error has no reason data?
    
### Internal Server Error [64]

Add Authorize to  CouponApiController => Internal Server Error

- Why "Internal Server Error" and not auth error?
- In the Coupon API the auth is not defined.

app.UseAuthentication();

before the 

app.UseAuthorization();

When we authenticating, we validating 3 thing:

- Secret
- Issuer
- Audience

We will validate our token using 3 of them.

```cs
var settingsSection = builder.Configuration.GetSection("ApiSettings");

var secret = settingsSection.GetValue<string>("Secret");
var issuer = settingsSection.GetValue<string>("Issuer");
var audience = settingsSection.GetValue<string>("Audience");

var key = Encoding.ASCII.GetBytes(secret);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // "Bearer"
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    // When we validating the token, validation parameters are:
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        ValidateAudience = true
    };
});

builder.Services.AddAuthorization();
```

So Now we have "Unauthorized" and not "Internal Server Error"

### Add Authentication to Swagger Gen [65]

We cannot authorize through the Swagger UI for the moment


```cs
using Microsoft.OpenApi.Models;

...

builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme //"Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            }, new string[]{}
        }
    });
});

```

Note, "Authorize" button on Mango.Services.CouponAPI Swagger UI

Register admin

```
{
  "email": "admin@gmail.com",
  "name": "Admin",
  "phoneNumber": "+380679307850",
  "password": "Admin123!",
  "role": "Admin"
}

curl -X 'POST' \
  'https://localhost:7002/api/auth/register' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "email": "admin@gmail.com",
  "name": "Admin",
  "phoneNumber": "+380679307850",
  "password": "Admin123!",
  "role": "Admin"
}'
```

Login

```
curl -X 'POST' \
  'https://localhost:7002/api/auth/login' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "userName": "admin@gmail.com",
  "password": "Admin123!"
}'
```

```
{
  "result": {
    "user": {
      "id": "45da03c0-4e8a-40d5-afcd-cb226ec3e09b",
      "email": "admin@gmail.com",
      "name": "Admin",
      "phoneNumber": "+380679307850"
    },
    "token": "eyJhb ... 67Uw"
  },
  "isSuccess": true,
  "message": ""
}
```

Authorize with token in the Coupon API

```
curl -X 'GET' \
  'https://localhost:7001/api/coupon' \
  -H 'accept: text/plain' \
  -H 'Authorization: Bearer eyJhbG...aUOSr-VY'

{
  "result": [
    {
      "couponId": 1,
      "couponCode": "10OFF",
      "discountAmount": 10,
      "minAmount": 20
    },
    {
      "couponId": 2,
      "couponCode": "20OFF",
      "discountAmount": 20,
      "minAmount": 40
    },
    {
      "couponId": 6,
      "couponCode": "23",
      "discountAmount": 23,
      "minAmount": 23
    }
  ],
  "isSuccess": true,
  "message": ""
}

```

ok


### Passing Token to API [66]

if we login or register we go without token, otherwise

we pass the token

```cs
        public async Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                //token
                if (withBearer)
                {
                    var token = _tokenProvider.GetToken();
                    message.Headers.Add("Authorization", $"Bearer {token}");
                }
                ...
```

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
