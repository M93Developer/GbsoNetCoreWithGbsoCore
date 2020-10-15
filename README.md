# GbsoNetCoreWithGbsoCore
Aplicación creada en .Net Core Mvc y Mssql, Con capas separadas y haciendo uso de una api rest.

## GbsoNetCoreWithGbsoCore.sln
La solución completa, fue creada con visual studio 2019.

## Gbso.Core
Librería de clases padre para la creación de modelos, colecciones, módulos de negocio y datas, 
todo con el fin de estandarizar y simplificar la gestión de objetos.

## Gbso.App.NetMvc
Capa de presentación .Net Core 3.1, 
por el momento solo contiene algunos formularios a modo de prueba del modelo Person.

## Gbsp.App.Model
Librería de modelado, 
contiene las clases de los objetos de la base de datos.

## Gbso.App.Data
Librería métodos crud, 
esta se comunica con la base de datos.

## Gbso.App.Business
Librería de reglas de negocio, 
esta realiza operaciones complejas relacionadas con el negocio.

## Gbso.App.Api
Librería api rest, 
la api obtiene los objetos directo de la data o pasando por las reglas negocio en coso de necesitar objetos resultantes de operaciones complejas.

## Gbso.App.Mssql
Aplicación Mssql, 
contiene la declaración de la estructura y los datos iniciales de la base de datos

## docker-compose
Configuración docker para el lanzamiento de las aplicaciones presentación y api en contenedores.
* Prerequisitos para lanzamiento
	* Cliente Docker configurado para contenedores linux
	* Docker Compose
* Lanzamiento 
	```bash
		docker-compose up
	``` 



