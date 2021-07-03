
# BridgeShop

BridgeShop is an API that provides Product and Category data. For example, Product admin want the product data to be available at an endpoint that looks like the following.
 
![image](https://user-images.githubusercontent.com/86763158/124349774-85f4d500-dc0e-11eb-8b7a-90cf3495238d.png) 
 
1. The protocol that is used here is http.
2. localhost:26125 is the domain.
3. The path /api in the URI indicates that this is an API. This is just a convention that most people follow. With this convention just by looking at the URL, we can say this is a REST API URL.
4. Finally /products is the endpoint at which we have the resource.


Similarly, if the Product admin want the Category data, is available at an endpoint that looks like the following.

![image](https://user-images.githubusercontent.com/86763158/124349743-678ed980-dc0e-11eb-83ad-a7cfa2547caa.png)

So in a REST API, each resource is identified by a specific URI.
## Prerequisites

#### Software

```bash 
  Visual Studio 2019
  Sql Server
  Postman
```

#### Database support

* To add database support we will use Entity Framework Core 5.0. Install the following 3 Nuget packages in the order specified.

```http 
  Install-Package Microsoft.EntityFrameworkCore
  Install-Package Microsoft.EntityFrameworkCore.SqlServer
  Install-Package Microsoft.EntityFrameworkCore.Tools
```
    
#### Database Connection String

```http 
  "ConnectionStrings": {
  "DBConnection": "server=localDB;database=ShopBridgeDb;Integrated Security=true"
}
```

#### Create and execute database migrations

* Use the following 2 commands to create and execute the initial database migrations

```http
  Update-Database

```
## Download Project Source Code & Running the Application

* Clone the project

```http
  git clone https://link-to-project
```

* Go to the project directory

```http
  Right Click Solution and Open With Visual Studio 2019
```
* Install NuGet packages

```http
  Install-Package Microsoft.EntityFrameworkCore
  Install-Package Microsoft.EntityFrameworkCore.SqlServer
  Install-Package Microsoft.EntityFrameworkCore.Tools
```
* Execute the command from Package Manager Console

```http
  Update-Database
```



* Run the application

```http
  CTRL+F5
```

  
## Solution Layout


![image](https://user-images.githubusercontent.com/86763158/124349697-3e6e4900-dc0e-11eb-9326-79390b72bd0c.png)


  
## API Reference

* Along with the URI, we also need to send an HTTP verb to the server. The following are the common HTTP verbs.

```http
  GET
  POST
  PUT
  PATCH
  DELETE
```
* It is this HTTP verb that tells the API what to do with the resource. 
  So the combination of the URI and the HTTP verb, that is sent with each request tells the API what to do with the resource.

#### Get all products

```http
  GET /api/products
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| *| * |* |  

#### Get product

```http
  GET /api/product/1
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | Gets product with Id = 1 |

#### Create product

```http
  POST /api/product
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| *      | * | Creates a new product |

#### Delete product

```http
  DELETE /api/product/1
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | Deletes product with Id = 1 |

#### Update product

```http
  PUT or PATCH /api/product/1
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | Updates product with Id = 1 |

* PUT Updates the entire object
* PATCH Partial update - only a subset of the properties

  
## Test the endpoints

* Use Postman to call the API

```http
  To retrieve all products, issue a GET request - http://localhost:26125/api/products?page=0&page_size=3 
```

#### Pagination
* Pagination is a process of dividing n number of records into multiple pages. At one-page certain number of records are visible. And next record set can be visible with next - previous button or scroll or using some other technique.

* In the API, pagination has been implemented  as shown below.

![image](https://user-images.githubusercontent.com/86763158/124349975-804bbf00-dc0f-11eb-8a39-8cc553a13820.png)

![image](https://user-images.githubusercontent.com/86763158/124349990-922d6200-dc0f-11eb-93ee-e201a54d3026.png)

![image](https://user-images.githubusercontent.com/86763158/124350011-b5f0a800-dc0f-11eb-8cab-507579357eca.png)


```http
  To retrieve specific product, issue a GET request - http://localhost:26125/api/products/1 
```

![image](https://user-images.githubusercontent.com/86763158/124350035-da4c8480-dc0f-11eb-8ab5-bfab3e9528d9.png)

```http
  To add a new product, Add the product o update in the body and issue a POST request - http://localhost:26125/api/products 
```

![image](https://user-images.githubusercontent.com/86763158/124350101-4b8c3780-dc10-11eb-94bf-4784b1e9d173.png)

```http
  To update product, Add the product in the body and issue a PUT request - http://localhost:26125/api/products/1 
```
  
![image](https://user-images.githubusercontent.com/86763158/124350157-91490000-dc10-11eb-834a-71193b70bd4f.png)
  
 ```http
  To delete a product, issue a DELETE request - http://localhost:26125/api/products/1 
```
   
![image](https://user-images.githubusercontent.com/86763158/124350194-cce3ca00-dc10-11eb-8539-e12914c752b5.png)

* Similarly to test the category endpoints

 ```http
  To get all categories, issue a GET request - http://localhost:26125/api/category?page=0&page_size=2 
```
![image](https://user-images.githubusercontent.com/86763158/124350528-d1a97d80-dc12-11eb-8fe3-a8a011a6e01f.png)

 ```http
  To get a specific category, issue a GET request with Id - http://localhost:26125/api/category/5 
```
![image](https://user-images.githubusercontent.com/86763158/124350608-2220db00-dc13-11eb-8bdb-f21f5a8172e3.png)


## Contributing

Contributions are always welcome!
