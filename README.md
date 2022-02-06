# JoyJet Test
## Cart - Api's

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

This application ilustrate an scenario that a user put some articles
inside of a virtual cart.

## Tech

Technologies / tools / Architecture / Patterns / Package used to make this project:

- [.Net Core] - framework
- [C#] - language
- [Flunt] - package of notifications
- [Visual studio] - Tool to develop this Api's
- [Postman] - Tool to test Api's
- [Entity Framework] - persistance / database
- [Docker] - To deploy this application
- [SQL] - database
- [CQRS] - Architecture to support many calls at the same time
- [S.O.L.I.D] - Priciple
- [DDD] - Design

## Installation / run

There are two ways to run this project:
- Execute with docker
- Execute local( is more fast)

 ✨Run with docker ✨
- Open project in visual studio IDE, right click on solution and restore Nuget packages and select docker to start the project.

✨Run local ✨
- Open project in visual studio IDE, right click on solution and restore Nuget packages and select level to start the project.

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
| Gym |  
| Açai |  
| Coffe |  
| Google | search is life! |


## License

MIT

**Free Software( no comercial use), Hell Yeah!**
