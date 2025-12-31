# Weather Microservice (P001)

This repository contains a **Weather microservice** built using the
`cloops.microservices` SDK.  
The service listens on a NATS subject and returns real-time weather
information for a given city using the public **wttr.in** API.

---

## Overview

- **Language / Framework**: .NET 9
- **Microservice SDK**: cloops.microservices
- **Messaging System**: NATS
- **External Weather API**: https://wttr.in
- **Communication Pattern**: Request / Reply via NATS

---

## NATS API

### Subject
weather.request

### Request Payload
```json
{
  "city": "Pune"
}
Response Payload
{
  "weather": { ... }
}

The weather field contains the JSON response fetched from:
https://wttr.in/{city}?format=j2

Implementation Details

The microservice is implemented using the cloops.microservices SDK.

Incoming messages on the weather.request subject are handled inside
WeatherController.

The service fetches weather data by making an HTTP GET request to
wttr.in.

The wttr.in service is public and does not require an API key.

Errors such as invalid city names or network failures are handled
gracefully and returned as error responses.

Running the Service Locally
Prerequisites

.NET 9.0 SDK

Docker

NATS Server

Step 1: Start NATS: docker run -p 4222:4222 nats

Step 2: Run the microservice
chmod +x run.sh
./run.sh

Step 3: Test using NATS CLI
docker run --rm natsio/nats-box \
  nats --server nats://host.docker.internal:4222 \
  request weather.request '{"city":"Pune"}'

Verification

Incoming requests on the weather.request subject are received by the
microservice.

Weather data is fetched from wttr.in and processed successfully.

The service produces a valid JSON response based on the external API data.
Notes

This project uses the public wttr.in API; it does not host or modify it.

The wttr.in GitHub repository was referenced only for documentation and
understanding supported response formats.

No secrets or API keys are committed to the repository.
References

cloops.microservices
https://github.com/connectionloops/cloops.microservices

wttr.in
https://github.com/chubin/wttr.in