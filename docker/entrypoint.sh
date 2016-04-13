﻿#!/bin/bash
set -e

sed -i \
    -e 's,${POSTGRES_DB},'"${POSTGRES_DB}"',g' \
    -e 's,${POSTGRES_USER},'"${POSTGRES_USER}"',g' \
    -e 's,${POSTGRES_PASSWORD},'"${POSTGRES_PASSWORD}"',g' \
    -e 's,${ELASTICSEARCH_INDEX},'"${ELASTICSEARCH_INDEX}"',g' \
    -e 's,${MICROBREWIT_AUTHURL},'"${MICROBREWIT_AUTHURL}"',g' \
    ./docker/appsettings.json

# Remove default config and replace with environment variable based config.
rm ./appsettings.json
mv ./docker/appsettings.json ./appsettings.json


echo "START ALL THE THINGS!"

# Exec docker run invokers original command
dnx -p project.json web
