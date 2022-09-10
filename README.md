# TUI Musement - Cities Weather

This project realizes a CLI application which prints out the weather forecasts for today and tomorrow for all the cities returned from the Musement `/cities` endpoint.
The code structure follows the principles of the clean architecture.

The project is provided with a CI pipeline, implemented through Github Actions, which does the following:
- builds and tags the docker containers
- runs the unit tests and uploads an artifact with the coverage report
- runs the functional tests and uploads an artifact with the report

## Table of contents

1. [Requirements](#requirements)
2. [Useful commands](#useful-commands)
3. [API Design](#api-design)

## Requirements

In order to run the project you need:

- A unix-like OS or WSL if using windows
- docker and docker-compose executable without root privileges
- make installed

## Useful commands

The following commands can be executed from the project root directory.

### 1. Build
```
make build
```
Builds and tags the docker containers. The application consists of three containers:
- dev: the container with the dotnet sdk and the source code. Is used to test the application locally and to run the unit and functional tests
- prod: the production container which has only the dotnet runtime and the publish output
- wiremock: a wiremock container used to mock the `/cities` and the `/forecast.json` endpoints.

### 2. Run the application
```
make run
```
Runs the application using wiremock to serve the `/cities` and the `/forecast.json` endpoints.

### 3. Run the application without mocks
```
 make run_without_mocks key=<api-key>
```
Runs the application targeting `https://sandbox.musement.com/api/v3` for the `/cities` endpoint and `http://api.weatherapi.com/v1` for the `/forecast.json` endpoint.
Replace `<api-key>`with your own weatherapi.com API Key.


### 4. Run the unit tests
```
make run_unit_tests
```
Runs the unit tests. The coverage report will be stored in the `<project_root>/app/test-report` directory.
### 5. Run the functional tests
```
make run_functional_tests
```
Runs the functional tests. The report will be stored in the `<project-root>/app/behavioral-test-report` directory.

## API Design

For the API Design, second step of the task, please refer to the [openapi.yaml](./openapi.yaml) file.

## Author
- [Daniele De Francesco](https://github.com/danieledefrancesco)
