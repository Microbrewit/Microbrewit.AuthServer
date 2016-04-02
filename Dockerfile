FROM microsoft/aspnet:1.0.0-rc1-update1

WORKDIR /app
COPY ["./project.json","/app"]
RUN ["dnu", "restore"]

COPY . /app
RUN ["dnu","restore"]

EXPOSE 127.0.0.1:5001:5001

CMD ["dnx", "-p", "project.json", "web"]