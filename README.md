# ToDo List API

Este es un backend para gestionar tareas ("todo items"). Permite crear, leer, actualizar y eliminar tareas. Está diseñado para ser ejecutado en Visual Studio.

## Características

POST /todos - Crea un nuevo todo item con un nombre y una fecha.\
GET /todos - Obtiene la lista de todos los todo items.\
GET /todos/{id} - Obtiene un todo item específico por ID.\
PUT /todos/{id} - Actualiza un todo item específico por ID.\
DELETE /todos/{id} - Elimina un todo item específico por ID.

## Requisitos

- Visual Studio (para ejecutar el proyecto).

## Instalación

Clonar el repositorio:

git clone [<https://github.com/FrancoExeqGarcia/LABIV>]

Abrir el proyecto en Visual Studio.

Restaurar las dependencias:
En la ventana de Package Manager Console, ejecuta:
dotnet restore

Ejecutar el proyecto:
Presiona F5 o selecciona Run desde el menú de Visual Studio para iniciar la aplicación.
