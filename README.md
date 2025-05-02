## 🐳 Building and Running the Container with Docker and Docker Compose

### 🔹 Using Docker Only

##### Build the image from the Dockerfile
docker build -t my-dotnet-app

##### Run the container with port mapping
docker run -d -p 5000:80 my-dotnet-app
The API will be available at: http://localhost:5000

### 🔹 Using Docker Compose


##### Run all services defined in docker-compose.yml-
docker-compose up --build

##### All services specified in docker-compose.yml will be started automatically
docker-compose down

GO TO - [Swagger UI](http://localhost:5000/swagger/index.html) and see calculateApi.



