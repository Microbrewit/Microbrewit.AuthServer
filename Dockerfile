FROM microsoft/aspnet:1.0.0-rc1-update1

WORKDIR /app
COPY ["./project.json","/app"]
RUN ["dnu", "restore"]

COPY . /app
RUN ["dnu","restore"]

EXPOSE 22530

CMD ["dnx", "-p", "project.json", "web"]
