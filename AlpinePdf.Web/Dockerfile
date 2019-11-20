FROM mcr.microsoft.com/dotnet/core/sdk:3.0.100-alpine3.9 AS build-env
COPY . /app
WORKDIR /app
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0.0-alpine3.9
RUN echo "http://dl-cdn.alpinelinux.org/alpine/edge/testing" >> /etc/apk/repositories \
    && apk update \
    && apk add \
        libgdiplus-dev \
        fontconfig \
        ttf-dejavu \
        curl \
        && curl -o /usr/lib/libwkhtmltox.so \
            --location \
            https://github.com/rdvojmoc/DinkToPdf/raw/v1.0.8/v0.12.4/64%20bit/libwkhtmltox.so
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT dotnet AlpinePdf.Web.dll
