FROM microsoft/dotnet:1.0.3-sdk-projectjson
ENV name CAAutomation
ENV buildconfig Release
COPY src/$name /root/$name
RUN cd /root/$name && dotnet restore && dotnet build -c $buildconfig && dotnet publish -c $buildconfig
RUN cp -rf /root/$name/bin/$buildconfig/netcoreapp1.0/publish/* /root/
EXPOSE 80/tcp
WORKDIR /root
ENTRYPOINT dotnet ${name}.dll
