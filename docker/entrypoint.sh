#!/bin/bash

set -e

echo "START ALL THE THINGS!"

sed -i \
    -e 's,${POSTGRES_DB},'"${POSTGRES_DB}"',g' \
    -e 's,${POSTGRES_USER},'"${POSTGRES_USER}"',g' \
    -e 's,${POSTGRES_PASSWORD},'"${POSTGRES_PASSWORD}"',g' \
    -e 's,${MICROBREWIT_AUTHURL},'"${MICROBREWIT_AUTHURL}"',g' \
    ./docker/appsettings.json

# Remove default config and replace with environment variable based config.
rm ./appsettings.json
cp ./docker/appsettings.json ./appsettings.json

# Exec docker run invokers original command
exec "$@"
