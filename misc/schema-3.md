```
Pros
Perfil carrega instantaneamente.
Cons
Feed precisa de 1 ordenação.
```

## Collections

### Blog
```js
{
    _id: <ObjectId>,
    owner: {
        name: string,
        credentials: {
            username: string,
            password: string
        }
    },
    description: string,
    posts: [
        {
            _id: <ObjectId>,
            title: string,
            firstContent: string,
            publishDate: string
        },
        {
            _id: <ObjectId>,
            title: string,
            firstContent: string,
            publishDate: ISODate()
        }
    ]
}
```

### Section
```js
{
    _id: <ObjectId>,
    postId: <ObjectId>,
    content: string,
    subsections: [
        {
            title: string,
            content: string,
            subsections: [
                {
                    title: string,
                    content: string
                },
                {
                    title: string,
                    content: string
                }
            ]
        },
        {
            title: string,
            content: string
        }
    ]
}
```