FROM microsoft/aspnet:1.0.0-rc1-update1

WORKDIR /app
COPY ["./project.json","/app"]
RUN ["dnu", "restore"]

COPY . /app
RUN ["dnu","restore"]

EXPOSE 5001/tcp

ENTRYPOINT ["/app/docker/entrypoint.sh"]
CMD ["dnx", "-p", "project.json", "web"]
