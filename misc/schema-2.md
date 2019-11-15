```
Feed precisa de 1 ordenação.
Perfil precisa de 1 ordenação.
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
    lastPost: {
        title: string,
        firstContent: string,
        publishDate: ISODate()
    }
}
```

### Post
```js
{
    _id: <ObjectId>,
    blogId: <ObjectId>,
    publishDate: ISODate(),
    title: string,
    content: string,
    sections: [
        {
            title: string,
            content: string,
            sections: [
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