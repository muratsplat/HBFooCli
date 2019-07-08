FROM microsoft/dotnet:sdk AS build-env

# Copy csproj and restore as distinct layers


# Copy everything else and build
COPY HBFoo ./
COPY entry.sh entry.sh
COPY input.txt input.txt

RUN chmod +x entry.sh
WORKDIR /
COPY --from=build-env /app/out .
ENTRYPOINT ["/bin/sh", "entry.sh"]