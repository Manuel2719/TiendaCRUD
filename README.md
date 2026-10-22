# TiendaCRUD 🛒 - C# Windows Forms

https://github.com/Manuel2719/TiendaCRUD.git

### Equipo Confirmado
- Miranda López, Manuel Eliseo - 260594
- Magaña Espinoza, Valeria Elisa - 261274
- Navarrete Flores, Debbie Naomi - 260016

  TiendaCRUD es una aplicación de escritorio desarrollada en C# con Windows Forms, utilizando Visual Studio 2022 y .NET 8.
El sistema permite gestionar productos mediante las cuatro operaciones fundamentales de un CRUD: Crear, Leer, Actualizar y Eliminar.
La aplicación utiliza una base de datos local de SQL Server Express LocalDB (TiendaDB.mdf) y Entity Framework Core para realizar las operaciones de almacenamiento y consulta de información.

Características del proyecto
Registro de productos: permite agregar nuevos productos con nombre, precio, cantidad en existencia y categoría.
Consulta de productos: muestra los registros almacenados en un DataGridView.
Actualización de productos: permite seleccionar un registro y modificar sus datos.
Eliminación de productos: permite eliminar registros mediante un mensaje de confirmación.
Gestión de categorías: los productos se relacionan con categorías almacenadas en una tabla independiente.
Validación de datos: comprueba que los campos obligatorios contengan información válida.
Limpieza del formulario: permite borrar los valores ingresados o seleccionados.
Persistencia de información: los registros permanecen almacenados en SQL Server después de cerrar la aplicación.

Script de creación
El repositorio incluye el archivo CrearBaseDatos.sql, que contiene las instrucciones SQL necesarias para crear las tablas, establecer su relación e insertar categorías iniciales.
El script debe ejecutarse sobre una base de datos nueva, ya que no está diseñado para recrear tablas existentes.

Tecnologías y herramientas utilizadas
Lenguaje de programación: C#
Framework: .NET 8
Entorno de desarrollo: Visual Studio 2022
Interfaz gráfica: Windows Forms (WinForms)
Base de datos: SQL Server Express LocalDB
ORM: Entity Framework Core 8
Proveedor de SQL Server: Microsoft.EntityFrameworkCore.SqlServer
Control de versiones: Git
Repositorio remoto: GitHub
  
1. Descargar el repositorio
Clonar el proyecto desde GitHub:
git clone https://github.com/Manuel2719/TiendaCRUD.git

2.Abrir la solucion
También puede descargarse como archivo ZIP desde el repositorio.

3. Abrir la solución
Abrir el archivo TiendaCRUD.sln utilizando Visual Studio 2022.
Esperar a que se restauren los paquetes NuGet necesarios.
3. Preparar la base de datos
Nota: los archivos físicos de la base de datos (.mdf y .ldf) no están incluidos en el repositorio debido a la configuración de .gitignore.
Para preparar una instalación nueva:
En Visual Studio, hacer clic derecho sobre el proyecto TiendaCRUD.
Seleccionar Agregar → Nuevo elemento.
Elegir Base de datos basada en servicios.
Crear el archivo TiendaDB.mdf dentro de la carpeta del proyecto TiendaCRUD.
Abrir la conexión de la nueva base de datos desde las herramientas de SQL Server.
Ejecutar el contenido de CrearBaseDatos.sql sobre esa base de datos.
Verificar que se hayan creado las tablas Categorias y Productos y que existan las categorías iniciales.
El archivo TiendaContext.cs utiliza una ruta relativa para localizar TiendaDB.mdf dentro de la carpeta del proyecto, partiendo del directorio de ejecución de Visual Studio.
Por ello, se debe conservar la estructura de carpetas original al ejecutar la solución.

Una vez abierta la aplicación:
Ingresar el nombre, precio y stock de un producto.
Seleccionar una categoría.
Pulsar Agregar para guardar el registro.
Seleccionar un producto de la tabla para modificarlo mediante Actualizar.
Utilizar Eliminar para borrar un producto, previa confirmación.
Pulsar Limpiar para restablecer los campos del formulario.

El desarrollo del proyecto se organizó mediante Git y GitHub, utilizando ramas para separar las responsabilidades del equipo.
master: rama principal del repositorio.
bd-modelos: desarrollo de modelos y estructura de datos.
interfaz-crud: desarrollo de la interfaz.
integracion-crud: integración de los componentes del sistema.
funcionalidades-crud: implementación de las operaciones restantes del CRUD.
22/10/2026
