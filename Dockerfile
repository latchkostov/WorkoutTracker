FROM microsoft/aspnetcore-build AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY WorkoutTracker.sln ./
#COPY /src/WorkoutTracker.csproj ./src/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/
RUN dotnet build -c Release -o /app src/WorkoutTracker.csproj

FROM build AS publish
RUN dotnet publish -c Release -o /app src/WorkoutTracker.csproj

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet WorkoutTracker.dll
