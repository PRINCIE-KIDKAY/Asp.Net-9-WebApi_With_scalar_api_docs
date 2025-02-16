# to create Api Setup run

`dotnet new webapi`

# to run use 
`dotnet watch run` 


# to add package example 

# for Api documentaion `dotnet add package Scalar.AspNetCore --version 2.0.*` 


# to Access Api docs normally --- `http://localhost:5257/openapi/v1.json`
# with Scalar --- `http://localhost:5257/scalar/v2`


# To extract requirements on a file 

`dotnet list package > requirements.txt`


# database manipulation too
`dotnet tool install --global dotnet-ef`

# migrations
`dotnet ef migrations add InitialCreate`
`dotnet ef database update`