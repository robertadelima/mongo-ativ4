
```
Pros
Perfil carrega instantaneamente.
Cons
Feed precisa de 1 ordenação.
```

## Collections

### Blogs
```js
{
    _id: <ObjectId>,
    title: string,
    description: string,
    owner: string,
    password: string,
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

### PostSections
```js
{
    _id: <ObjectId>,
    postId: <ObjectId>,
    title: string,
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
