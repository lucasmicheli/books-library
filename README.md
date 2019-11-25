# Proyecto Integrador - Accenture Academy

## Sistema de gestión de libros



### Objetivo general:

Desarrollar un sistema de gestión de libros con el objetivo de administrar una biblioteca de una institución educativa. El proyecto está basado en desarrollar una solución utilizando casos comunes de la vida real para que los alumnos puedan identificar con naturalidad la problemática que tienen que resolver y aún si dejar un espacio de desarrollo individual para cada uno pueda extender el proyecto, añadiendo nuevas soluciones en forma creativa y de esta manera poder medir el compromiso y la capacidad de trabajo autónomo de cada uno de los alumnos.

### Información que almacena el sistema:

El proyecto contará con una base de datos constituida por cuatro tablas. Una ***tabla de libros*** , que contendrá el catálogo completo de todos los libros existentes en la biblioteca. Una ***tabla de géneros***, donde estarán almacenados todos los diferentes géneros de libros con el fin de poder categorizar toda la biblioteca y realizar búsqueda filtrando por género. Una ***tabla de editoriales***, con la información de las compañías que imprimen los libros y, por último para uso de prácticas no obligatoria (ejercicios de extra bonus) ***una tabla de autores***, donde estarán los datos de escritores de cada uno de los libros.

### Características técnicas:

El sistema será desarrollado utilizando arquitectura en capas. Inicialmente se comenzará con el desarrollo de las vistas en la capa de Front-End utilizando HTML, CSS, Javascript y jQuery. Se desarrollarán buenas prácticas de maquetación diseñando páginas responsivas para que puedan adaptarse a diferentes formatos de pantallas. Luego se implementara el desarrollo Back-End utilizando lenguaje C# como code behind y ASP.NET para renderizar los resultados Web. La base de datos estará implementada con tecnología Microsoft SQL Server. Por último y para asimilar los conceptos de la arquitectura en capas, se adaptara el código Back-End utilizando el Framework MVC de Microsoft.

### Módulos del sistema

#### Catálogo de libros:

Desarrollar un reporte del listado completo de la tabla libros. Poder realizar diferentes búsquedas de los libros filtrando por su género, nombre, editorial y/o autor.

#### ABM de libros:

Desarrollar un un formulario web para la carga de nuevos libros. Insertar un registro en la base de datos, en la tabla Libros de acuerdo a la información cargada en el Front. Implementar diferentes objetos HTML de captura de datos para que los alumnos experimenten un desarrollo complejo de un formulario de carga de datos y la vinculación con el código Back-End. Realizar diferentes validaciones para asegurar la integridad de la información, tanto del lado del cliente con Javascript como del lado del servidor con .NET
Desarrollar la edición de libros, pre cargando la información desde la base de datos en un formulario web y permitir la edición de los mismos realizando las mismas validaciones de integridad de datos que se utilizaron para el alta de registros. Desarrollar la acción de borrar libros, desde la vista del catálogo de libros, agregando el icono del tacho de basura y validando desde JS con JQuery la confirmación antes de borrar.

#### Vinculación tabla Género:

En el catálogo de libros, realizar búsquedas anidadas con el género y mostrar la descripción en el reporte. También implementar un objeto HTML para seleccionar un género y filtrar los resultados de la búsqueda de libros. En la sección de ABM de Libros, insertar y modificar el género del libro leyendo la descripción desde la tabla Géneros.

#### Editoriales:

Desarrollar la vista de editoriales pudiendo buscar una editorial y ver todos los libros diferentes que imprime la misma.



