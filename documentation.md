# Architekturdokumenation

## Infrastruktur

![Architektur](./infrastructure.png)

## Software

### Frontend

### Backend

* ASP.NET Core / Kestrel
* OAuth (vorbereitet)
* REST API mit Swagger
* Entity Framework Core (Code First)
* Maria DB
* Docker

### Entwicklung

#### CI/CD

* github (https://github.com/laufburschen/hackaton)
* dockerhub (wirvsvirusgs/deinlaufbursche)), automatisierter Build bei Änderung in github
* der letzte Schritt besteht darin, auf der VM das docker-compose bei Bedarf manuell neu zu starten

* Visual Studio Code & Professional
* Postman  