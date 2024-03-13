# Stage 1: Build the React frontend
FROM node:18.17.0 as build
WORKDIR /app
COPY ClientApp/package*.json ./
RUN npm install
COPY ClientApp/ ./
RUN npm run build

# Stage 2: Build the C# backend
FROM mcr.microsoft.com/dotnet/sdk:6.0 as backend
WORKDIR /src
COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN apt-get update && \
    curl -sL https://deb.nodesource.com/setup_18.x | bash - && \
    apt-get install -y nodejs
RUN dotnet publish -c Release -o /app

# Stage 3: Build the final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=backend /app ./
COPY --from=build /app/build ./ClientApp/build
ENTRYPOINT ["dotnet", "freakSearch.dll"]