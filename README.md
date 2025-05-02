## 🐳 Building and Running the Container with Docker and Docker Compose

### 🔹 Using Docker Only

##### Build the image from the Dockerfile
go to \CalculateProject\IO.Swagger and run -
docker build -t swagger-api .

##### Run the container with port mapping
docker run -d -p 8080:8080 -e ASPNETCORE_ENVIRONMENT=Development swagger-api
The API will be available at: http://localhost:8080

### 🔹 Using Docker Compose


##### Run all services defined in docker-compose.yml-
docker-compose up --build

##### All services specified in docker-compose.yml will be started automatically
docker-compose down

GO TO - [Swagger UI](http://localhost:8080/swagger/index.html) and see calculateApi.



