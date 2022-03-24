# TiendaEventec
Prueba Técnica Evertec - Aplicación Tienda

## Requerimientos
* Visual Studio 2019 o superior.[Instalador](https://visualstudio.microsoft.com/es/vs/).
* Visual Studio Code. [Instalador](https://code.visualstudio.com/).
* SQL Server Express 2019 o superior. [Instalador](https://www.microsoft.com/es-es/sql-server/sql-server-downloads).
* Node JS 16 o ultima versión estable. [Instalador](https://nodejs.org/es/).
* Angular 10 o Superior. [Instalador](https://angular.io/).

## Instalación
1. Descargar todos los fuentes del proyecto (Front, Back, base de Datos)
2. De la carpeta Base de datos, tomar el archivo Tienda.bak y restaurarlo en una base de datos  denominada Tienda.
3. Para el BackEnd realizar la ssiguientes acciones:
  - Abrir la solución ApiTienda.sln en Visual Studio. Este archivo se encuentra en la carpeta Back/ApiTienda.
  - Restaurar los paquetes de Nuget.
  - Modificar la cadena de conexión con los datos de su instancia de base de datos. Esta modificación se hace en el web.config.
  - Compilar la solución y validar que se ejecute correctamente.
5. Para el Front End realizar la siguientes acciones:
  - Abrir el contenido de la carpeta Front/Tienda en Visual Studio Code.
  - Ejecutar en una terminal el comando **npm install** para restaurar los paquetes asociados al proyecto.
  - Ejecutar en una terminal el comando **ng serve**, para validar que el proyecto se ejecute correctamente.

