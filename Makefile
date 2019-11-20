build:
	docker-compose \
		--project-directory=${PWD} \
		--project-name=pdf \
		-f docker-compose.yml \
		build ${ARGS}

start:
	docker-compose \
		--project-directory=${PWD} \
		--project-name=pdf \
		-f docker-compose.yml \
		up --build -d
	bash ./Scripts/wait-until-service-is-up.sh

test:
	dotnet test AlpinePdf.Test

stop:
	docker-compose \
		--project-directory=${PWD} \
		--project-name=pdf \
		-f docker-compose.yml \
		down
