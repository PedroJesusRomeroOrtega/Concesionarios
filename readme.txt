La soluci�n tiene 6 proyectos:
�	Concesionarios.Core: Contiene las entidades.
�	Concesionarios.DAL: Capa de acceso a datos.
	La inicializaci�n de los valores para la entidad Marca est� hecha sobreescribiendo el m�todo Seed en la clase ConcesionariosDBInitializer
	o	Mapping: Tiene el mapeo de las entidades con Fluent API, aunque para las foreign keys, al final he usado DataAnnotation.
	o	Repository: Todas las clases del repositorio gen�rico y Unit of Work.
�	Concesionarios.Service: Contiene los servicios que luego usar� en Web Api.
�	Concesionarios.WebApi: Aqu� he usado Ninject para inyectar las dependencias.
	He usado CORS para poder llamar luego al webapi desde el proyecto Concesionarios.Web.
	Las entidades con las que interactua el webapi est�n en la carpeta Models.
�	Concesionarios.Web: Contiene la plantilla deASP.NET  MVC, pero solo se usa para albergar Angular2 con TypeScript, cuya estructura se encuentra en la carpeta app.
	La aplicaci�n no est� acabada, de hecho solo funciona el CRUD de concesionario y tampoco he controlado las validaciones ni excepciones.
�	Concesionarios.WebApi.Test: tampoco me ha dado tiempo. La idea era usar Moq.
