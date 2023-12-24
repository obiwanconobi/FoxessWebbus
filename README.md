# FoxessWebbus

## What is this?

FoxessWebbus is a blazor site made for interacting with the H1 Inverter

## Can I use this?
If you have a H1 Inverter from Foxess and for some reason:
A. Don't want to use their official app
B. Don't want to use the Home Assistant addon

Then yeah

## Installation

Docker Compose script:

```bash
version: '3.4'

services:
  FoxessWebbus:
    image: ghcr.io/obiwanconobi/foxesswebbus:main
    ports:
        - "6460:80"
        - "6461:443"
    environment:
      - SqliteDB=Data Source=/Data/FoxessWebbus.db
    volumes:
     ## MAP VOLUME HERE
    build:
      context: .
      dockerfile: FoxessWebbus.Web/Dockerfile

```

## Usage

The service gets real-time data from the Inverter via modbus with an interval time in settings.
There is a daily service which logs the days stats.

