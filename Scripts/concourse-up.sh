#!/bin/bash -e

docker compose -f Docker/docker-compose-concourse-ec2.yml up -d
echo "Waiting for Concourse to startup..."

sleep 10 # wait for concourse to spin up

curl 'http://localhost:8080/api/v1/cli?arch=amd64&platform=linux' -o fly \
    && chmod +x ./fly \
    && sudo mv ./fly /usr/local/bin/

fly -t resumetech login -c http://localhost:8080 -u resumetech -p resumetech