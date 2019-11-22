# WIP Readme

## Get all blogs

That's the main feed.

Definition: `GET /blogs`

Payload: ` `

Responses:

Success: `200 OK`
```json
{
  [
    {
      "title": "The blog title",
      "username": "The blog owner",
      "description": "The description of the blog",
    },
    {
      "title": "The blog title",
      "username": "The blog owner",
      "description": "The description of the blog",
    }
  ]
}
```

## Create blog

Definition: `POST /blogs`

Payload:
```json
{
  "title": "The blog title",
  "username": "The blog owner's username",
  "password": "The blog owner's password",
  "description": "The description of the blog",
},
```

Response:

Success: `200 OK`

Failure:

Username already being used: `401 CONFLICT`


**POST**

### `blogs/{username}

**GET**

**DELETE**

### `blogs/{username}

**GET**

**POST**

**DELETE**
