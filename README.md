# TodoList 
Proyecto realizado como parte de la prueba técnica para desarrollador de software junior en Pay Tech Solutions. Este proyecto fue realizado siguiendo las guías de arquitectura de software, 
de Clean Architecture. Creando de esta forma una aplicación orientada al dominio, fácil de testear y extender. 

## Requisitos
* Visual Studio 2022
* .NET Core SDK
* SQL Server

## Configuración
La única configuración a destacar sería la conexión a la base de datos. Esta puede ser modificada en el appsettings.json, en el apartado de ConnectionStrings

## Iniciar base de datos
La creación de la base de datos se realiza mediante el Cli de EntityFramework. Debido a que ya las migraciones existen en el proyecto, no hay que crearlas con posterioridad.
Lo único que hay que hacer para inicializar la base de datos es ejecutar el siguiente comando:

    dotnet-ef database update
Asegurate de estar dentro de la carpeta del proyecto y no de la solución a la hora de correr el comando.
