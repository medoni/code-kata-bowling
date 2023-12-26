# build context /src

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY Bowling-Game-Engine/Bowling-Game-Engine.csproj ./Bowling-Game-Engine/
COPY Bowling-Game-Engine.Tests/Bowling-Game-Engine.Tests.csproj ./Bowling-Game-Engine.Tests/
COPY Bowling-Game-Kata.sln .
RUN dotnet restore

COPY . .
RUN dotnet build -c Release --no-restore

CMD ["dotnet", "test", "/app/"]