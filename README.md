# JoyJet Test
## Cart - Api's

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

This application ilustrate an scenario that a user put some articles
inside of a virtual cart.

## Tech

Technologies / tools / Architecture / Patterns used to make this project:

- [.Net Core] - framework
- [C#] - language
- [Visual studio] - Tool to develop this Api's
- [Postman] - Tool to test Api's
- [Entity Framework] - persistance / database
- [Docker] - To deploy this application
- [SQL] - database
- [CQRS] - Architecture to support many calls at the same time
- [S.O.L.I.D]

## Installation / run

There are two ways to run this project:
- Execute with docker
- Execute local( is more fast)

 ✨Run with docker ✨
- Open project in visual studio IDE and select docker to start the project.

✨Run local ✨
- Open project in visual studio IDE and select level to start the project.

If you dont have a SQL installed at docker, get one with this command:
```sh
docker pull mcr.microsoft.com/mssql/server:latest
```

And after:
```sh
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=1q2w3e4r@#$' -p 1401:1433 -d --name=SQLSERVER mcr.microsoft.com/mssql/server:latest
```

After that, set the connectionstring at file appsettings.Development.json

Follow the steps bellow to complete setup:

- Step 1:

 Open the package manager console in Visual studio and execute the command line:
 ```sh
add-migration Initial
```

And after:
```sh
Update-Database -verbose
```

- Inside the directory Infra and inside the project Level.Persistance exist an directory called Sql Script
- Take the file script-insert and execute in you sql management or other tool that you prefer.


## Final considerations

This project was developed to expose my experience in the proposed technologies. As it is not a project for commercial purposes, some things were left out, for example CQRS only has 1 DB, the right thing would be to have 2 or more (read, write and maybe a NOSQL).
It would be prudent for a commercial application to put more logs and unit tests. It would be valid to create an article registration and delivery fee and not a sql script like I did.
I hope the end result has served the purpose of the test.



## Thanks

| God |  
| Wife |  
| Family |
| Friends |
| Açai |
| Coffe |
| Google | search is life! |

## Development

Want to contribute? Great!

Dillinger uses Gulp + Webpack for fast developing.
Make a change in your file and instantaneously see your updates!

Open your favorite Terminal and run these commands.

First Tab:

```sh
node app
```

Second Tab:

```sh
gulp watch
```

(optional) Third:

```sh
karma test
```

#### Building for source

For production release:

```sh
gulp build --prod
```

Generating pre-built zip archives for distribution:

```sh
gulp build dist --prod
```

## License

MIT

**Free Software, Hell Yeah!**

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)

   [dill]: <https://github.com/joemccann/dillinger>
   [git-repo-url]: <https://github.com/joemccann/dillinger.git>
   [john gruber]: <http://daringfireball.net>
   [df1]: <http://daringfireball.net/projects/markdown/>
   [markdown-it]: <https://github.com/markdown-it/markdown-it>
   [Ace Editor]: <http://ace.ajax.org>
   [node.js]: <http://nodejs.org>
   [Twitter Bootstrap]: <http://twitter.github.com/bootstrap/>
   [jQuery]: <http://jquery.com>
   [@tjholowaychuk]: <http://twitter.com/tjholowaychuk>
   [express]: <http://expressjs.com>
   [AngularJS]: <http://angularjs.org>
   [Gulp]: <http://gulpjs.com>

   [PlDb]: <https://github.com/joemccann/dillinger/tree/master/plugins/dropbox/README.md>
   [PlGh]: <https://github.com/joemccann/dillinger/tree/master/plugins/github/README.md>
   [PlGd]: <https://github.com/joemccann/dillinger/tree/master/plugins/googledrive/README.md>
   [PlOd]: <https://github.com/joemccann/dillinger/tree/master/plugins/onedrive/README.md>
   [PlMe]: <https://github.com/joemccann/dillinger/tree/master/plugins/medium/README.md>
   [PlGa]: <https://github.com/RahulHP/dillinger/blob/master/plugins/googleanalytics/README.md>

