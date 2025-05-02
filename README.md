## 🐳 Building and Running the Container with Docker and Docker Compose

### 🔹 Using Docker Only

##### Build the image from the Dockerfile
go to \CalculateProject\IO.Swagger and run -
docker build -t swagger-api .

##### Run the container with port mapping
docker run -d -p 8080:8080 -e ASPNETCORE_ENVIRONMENT=Development swagger-api

The API will be available at: http://localhost:8080

##### If you want to stop the container
docker stop <CONTAINER_ID>

### 🔹 Using Docker Compose


##### Run all services defined in docker-compose.yml-
docker-compose up --build

##### If you want to stop the services
docker-compose down

GO TO - [Swagger UI](http://localhost:8080/swagger/index.html) and see calculateApi.



