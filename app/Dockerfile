FROM mcr.microsoft.com/dotnet/sdk:6.0-bullseye-slim AS prepare-build-env

#Downloading dependencies
RUN apt-get update
RUN apt-get -y install make

RUN dotnet tool install --global dotnet-reportgenerator-globaltool
RUN dotnet tool install --global coverlet.console --version 3.0.3
RUN dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI --version 3.9.57
ENV PATH=${PATH}:/root/.dotnet/tools

WORKDIR /app
RUN devNull=$(mkdir test-report)
RUN devNull=$(mkdir test-results)
RUN devNull=$(mkdir behavioral-test-results)

RUN apt-get update && apt-get install -y dnsutils ca-certificates curl apt-transport-https lsb-release gnupg
RUN curl -sL https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor | tee /etc/apt/trusted.gpg.d/microsoft.gpg > /dev/null
RUN echo "deb [arch=amd64] https://packages.microsoft.com/repos/azure-cli/ $(lsb_release -cs) main" | tee /etc/apt/sources.list.d/azure-cli.list
RUN apt-get update
RUN apt-get install azure-cli -y

FROM prepare-build-env AS restore

COPY ./TuiMusement.CitiesWeather.sln ./TuiMusement.CitiesWeather.sln

COPY src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done

COPY test/unit/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p test/unit/${file%.*}/ && mv $file test/unit/${file%.*}/; done

COPY test/functional/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p test/functional/${file%.*}/ && mv $file test/functional/${file%.*}/; done

RUN dotnet restore

FROM restore as build-env

COPY ./scripts ./scripts/
COPY ./settings ./settings/
COPY ./src ./src/
COPY ./test ./test/
COPY ./Makefile ./Makefile

RUN dotnet build
ARG PROJECT_PATH
RUN dotnet publish ${PROJECT_PATH} -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0-bullseye-slim AS prepare-prod-env
RUN apt-get update && apt-get -y install curl

FROM prepare-prod-env AS prod
WORKDIR /web
COPY --from=build-env /app/out .
COPY scripts/run_prod.sh .
ARG DLL_NAME
ENV DLL_NAME=$DLL_NAME
CMD ["sh", "./run_prod.sh"]

FROM build-env as dev
ARG PROJECT_PATH
ENV PROJECT_PATH=$PROJECT_PATH
CMD ["sh", "./scripts/run_dev.sh"]


