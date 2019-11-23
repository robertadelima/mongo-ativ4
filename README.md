# MongoDB Project Blogs

This a project me and @mabo3n made for a NoSQL Database class. A backend for a blog management system is provided which uses MongoDB and exposes a RESTFul API to create and retrieve blog and blog posts.

The documentation for the API can be accessed through the `/swagger` endpoint:

`GET​ /blogs`

Returns a collection of registered blogs sorted by their last post's publish date

`POST ​/blogs`

Creates a new blog account

`GET​ /blogs​/{owner}`

Returns the blog's posts sorted by publish date

`DELETE ​/blogs​/{owner}`

Deletes a blog account

`POST​ /blogs​/{owner}`

Creates a new post in a blog

`GET​ /blogs​/{owner}​/{position}`

Returns sections for a given post position


