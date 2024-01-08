# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 5000

# Create a directory for external configuration
RUN mkdir /config

COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SimpleCustomCalculator.dll"]
