# CRUDE-NET
CRUD Application Generator in ASP.NET Core and SQL Server Database.

* Features List:
  * [Basic CRUD Features](https://github.com/EitanBlumin/CRUDE-NET/wiki/Features-List:-Basic-Evolutility-features)
  * [Advanced CRUD Features](https://github.com/EitanBlumin/CRUDE-NET/wiki/Features-List:-Advanced-Evolutility-features)
  * [All New Features](https://github.com/EitanBlumin/CRUDE-NET/wiki/Features-List:-All-New-Features)
* Design Documents:
  * [Database ERD Design](https://github.com/EitanBlumin/CRUDE-NET/wiki/Database-ERD)
  * [MVC Routing Schema](https://github.com/EitanBlumin/CRUDE-NET/wiki/MVC-Routing-Schema)

# Summary

The project's aim is to implement a CRUD application generator.

I want to base it on an admin template with bootstrap 4 (such as ngx-admin), and an existing open source crud generator such as Evolutility, CRUDBooster or serenity, but I'm open to other ideas.

The best examples I could find that were closest to my vision of a CRUD generator are [Evolutility](http://www.evolutility.org/), [CRUDBooster](http://crudbooster.com) and [Serenity](https://github.com/volkanceylan/Serenity).

Unfortunately, they all lack certain features that I believe are critical, but since they're open-source, they can be leveraged as a good starting point.


## Most crucial requirements:

1. The development stack must be such as to allow as few installations and 3rd party programs as possible during deployment.

    * This is why I chose ASP.NET because it already relies on pre-existing Windows components.
    * And it's why I chose Angular/React as front-end because after build I can just copy and paste the files into wwwroot and it'll work.
    * No need for 3rd party installations (such as Docker, Node.js or Apachee), and no need to run any executable in order to make it work.

2. The database backend MUST be Microsoft SQL Server (or something compatible such as localDB or Compact SQL Server). This is NOT negotiable (although, assuming the DB layer could be decoupled, integrating other database technologies at a later stage is not out of the question).

3. The ability to create and manage forms/views/models/modules/components/however you wanna call it, MUST be in an easy-to-use graphical user interface, changes in which would be seen immediately in the portal. No coding experience should be needed (not for basic crud needs, anyway).

## Related resources:

* [CRUDBooster on PHP and Laravel](https://github.com/crocodic-studio/crudbooster)
* [Serenity on ASP.NET Core MVC and Typescript](https://github.com/volkanceylan/Serenity)
* [Evolutility on ASP.NET Webforms + SQL Server](https://github.com/evoluteur/evolutility-asp.net)
* [Evolutility on React + Node.js + PostgreSQL](https://github.com/evoluteur/evolutility-ui-react)
* [NGX-Admin visual template](https://github.com/akveo/ngx-admin)

* [CRUDE-ASP (my own attempt at doing it myself using classic asp)](https://github.com/EitanBlumin/CRUDE-ASP)


[Click here to read more in the Wiki](https://github.com/EitanBlumin/CRUDE-NET/wiki)
