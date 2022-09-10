env=dev
build:
	ENVIRONMENT=$(env) docker-compose build

run:
	ENVIRONMENT=$(env) docker-compose up -d wiremock
	ENVIRONMENT=$(env) docker-compose up dev
	ENVIRONMENT=$(env) docker-compose down
	
run_without_mocks:
	ENVIRONMENT=dev-no-mock docker-compose run dev bash -c "WeatherService__Key=$(key) sh ./scripts/run_dev.sh"
 
run_unit_tests:
	ENVIRONMENT=$(env) docker-compose run dev bash -c "make run_unit_tests"
	
run_functional_tests:
	ENVIRONMENT=$(env) docker-compose up -d wiremock
	ENVIRONMENT=$(env) docker-compose run dev bash -c "make run_functional_tests"
	ENVIRONMENT=$(env) docker-compose down