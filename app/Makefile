run_unit_tests:
	dotnet test --filter FullyQualifiedName!~.Specs --settings settings/coverlet.runsettings --logger trx --results-directory "test-results"
	reportgenerator "-reports:test-results/**/*.opencover.xml" "-targetdir:test-report"

run_functional_tests:
	dotnet test ${SPECS_PROJECT_PATH}/${SPECS_PROJECT_NAME}
	livingdoc test-assembly ${SPECS_PROJECT_PATH}/bin/Debug/${NET_VERSION}/${SPECS_DLL_NAME} -t ${SPECS_PROJECT_PATH}/bin/Debug/${NET_VERSION}/TestExecution.json --output behavioral-test-results