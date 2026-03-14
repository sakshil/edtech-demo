										   # EdTetch Dashboard API

## Overview

This project implements a Dashboard Aggregator API for an EdTech platform.
The API composes data from multiple sources to return a single personalized dashboard response for a learner.

The dashboard combines:

* Learner profile information
* CMS-managed content (banners, blocks)
* System-generated course recommendations
* Metadata such as correlation ID and cache indicators

## API Endpoint


 Use **`sakshi123`** as the learnerId to see the complete sample dataset and recommendations.

```
GET /api/v1/dashboard?learnerId={id}
```
Example:
  ```
GET /api/v1/dashboard?learnerId=sakshi123
```

Learner Profile Service
```
GET /api/v1/learners/{learnerId}
```

Learning Events Service 
```
GET /api/v1/learners/{learnerId}/events
```

CMS Content Service
```
GET /api/v1/cms/dashboard?segment={segment}
```

---


## Caching Strategy

Two levels of caching are implemented using **IMemoryCache**.

| Data        | Cache Key               | Duration   |
| ----------- | ----------------------- | ---------- |
| CMS Content | `cmsContent:{segment}`  | 10 minutes |
| Dashboard   | `dashboard:{learnerId}` | 60 seconds |

Caching improves response time and reduces repeated processing.

---


## Testing

The project includes:

* **Unit tests** for recommendation logic


Run tests using:

```
dotnet test
```

--Technologies Used

* .NET 8 Web API
* MemoryCache
* API Versioning
* xUnit (testing)
* Swagger/OpenAPI

