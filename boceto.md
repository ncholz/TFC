# Memoria del Proyecto: HoopManager

## Índice
* Introducción
* Objetivos
  * Objetivos Técnicos
  * Objetivos Específicos de la Aplicación
  * Objetivos de Innovación y Emprendimiento
* Análisis
  * Especificación de requisitos
  * Diagrama de casos de uso
  * Descripción de casos de usos
  * Diagrama de clases
* Fases del proyecto
  * Diseño
    * Base de datos
    * Estándares Técnicos
    * Diccionario de Datos
    * Relaciones de Cardinalidad y Modelo Relacional
    * Diagrama de Componentes
    * Diagrama de Navegabilidad
    * Interfaz (diseño)
  * Implementación y configuración
    * Herramientas utilizadas
    * Configuración del entorno de datos
    * Arquitectura del Software
* Pruebas
  * Pruebas en Entorno de Desarrollo (Local con XAMPP)
  * Pruebas en un proyecto aislado (Sandbox)
  * Control de errores
* Metodología aplicada
* Ampliación y posibles mejoras
* Conclusión
* Bibliografía

---

## Introducción

La idea de hacer HoopManager nace de algo muy sencillo: me apasionan los deportes de equipo y, por encima de todo, el baloncesto. He pasado suficientes horas en una cancha como para saber que este deporte es mucho más que meter el balón en el aro. Es estrategia, es orden y es conocer a tu equipo al detalle.

He decidido crear esta interfaz porque, a día de hoy, veo a muchos entrenadores (desde categorías base hasta equipos más serios) volviéndose locos con libretas emborronadas, grupos de WhatsApp caóticos o excels infinitos que no hay quien entienda nada.

### ¿Qué es HoopManager?
HoopManager es una app de PC diseñada para los entrenadores de cualquier liga. Esta app permite gestionar entrenamientos según estadísticas de partidos, herramientas para ojear a jugadores, vistas para ver las estadísticas de su equipo, una pizarra para diseñar jugadas y enseñarselas a sus jugadores.

Dependiendo del rol con el que inicies sesión, tendrás unas funciones u otras.
Si inicias como “admin” tendrás una interfaz que podrás añadir / modificar / eliminar datos de casi todas las tablas.
En resumen, el rol de “admin” es gestión de la base de datos y el rol de “entrenador” es visualizar las tablas relacionadas entre sí aparte de las funciones como la pizarra.

---

## Objetivos

El objetivo de este proyecto es el diseño y desarrollo de HoopManager, una aplicación de escritorio centrada en la centralización de datos técnicos y estadísticos de equipos de baloncesto. La herramienta permite sustituir los registros manuales por una base de datos MySQL eficiente, facilitando la consulta de perfiles y el rendimiento de los jugadores.

### Objetivos Técnicos
Con este proyecto busco:
* **Integración de Sistemas:** Conectar una interfaz gráfica avanzada (WinForms) con una base de datos relacional para asegurar la persistencia de los datos.
* **Optimización de Consultas:** Implementar lógica de filtrado para mostrar únicamente información relevante, como jugadores activos o estadísticas por partido.
* **Seguridad de Datos:** Aplicar reglas de integridad, como el control de dorsales duplicados y el borrado lógico (desactivación) para no perder el historial estadístico del club.
* **Calidad y tests:** Asegurarme que la app no solo es funcional en mi PC, sino que pase pruebas de rendimiento y usabilidad para que cualquier entrenador la pueda usar sin que haya ningún problema.

### Objetivos Específicos de la Aplicación
Para que HoopManager sea una herramienta operativa, se han implementado los siguientes módulos:
* **Repositorio Digital de Jugadores:** Un panel centralizado para gestionar la información de la plantilla (nombre, posición, dorsal, altura). Permite la actualización constante de los perfiles y la gestión de estados (activo/inactivo).
* **Motor de Estadísticas Históricas:** Un sistema de registro para almacenar las medias de rendimiento (puntos, rebotes, asistencias) de cada jugador a lo largo de diferentes temporadas.
* **Análisis de Rendimiento por Partido:** Módulo dedicado a la visualización detallada de las estadísticas generadas en cada partido, permitiendo identificar los roles y la aportación de cada jugador en pista.
* **Interfaz Intuitiva y Moderna:** Crear una experiencia de navegación fluida basada en un diseño de paneles profesional. La arquitectura de la aplicación está pensada para ser autoexplicativa, minimizando la curva de aprendizaje y permitiendo que el usuario acceda a cualquier sección de forma inmediata.

### Objetivos de Innovación y Emprendimiento
* **Escalabilidad total (Ligas):** Aunque el proyecto empieza con datos de la NBA, la arquitectura de la base de datos está diseñada para ser totalmente adaptable. Con un cambio mínimo en las tablas, el sistema puede gestionar ligas de formación o competiciones locales. Esto hace que el software sea un producto real y comercializable para cualquier club o federación.
* **Digitalización del Deporte:** Fomentar que los clubes abandonen el papel para pasar a un modelo de gestión digital donde la información es inmediata y fácil de buscar.
* **Sostenibilidad (ODS):** Contribuir a la reducción del uso de papel en los clubes deportivos mediante la digitalización completa de actas, fichas y planificaciones.

---

## Análisis

En esta fase defino las necesidades del usuario y la lógica interna de la aplicación, transformando los objetivos generales en especificaciones técnicas detalladas.

### Especificación de requisitos
Es muy importante separar lo que la aplicación hace de lo que aplicación es a nivel técnico.

**Requisitos Funcionales (RF):** Son las acciones que el sistema debe ejecutar.
* **RF1:** El sistema debe permitir el inicio de sesión diferenciado por roles.
* **RF2:** El sistema debe mostrar una interfaz u otra dependiendo del rol del usuario.
* **RF3:** El sistema debe garantizar una capa de validación de datos de entrada.
* **RF4:** Los botones de Cerrar aplicación y Volver atrás deben funcionar correctamente.
* **RF5:** El sistema debe calcular automáticamente la valoración (PIR) de los jugadores.
* **RF6:** El sistema debe mostrar los jugadores del equipo según el equipo del entrenador.
* **RF7:** El sistema debe recordar entrenamientos basados en las estadísticas medias del jugador.
* **RF8:** El entrenador debe poder diseñar jugadas mediante una interfaz gráfica táctica.
* **RF9:** El entrenador debe poder visualizar las estadísticas de la liga de TODOS los jugadores de TODOS los equipo.
* **RF10:** El entrenador debe poder visualizar todos los partidos de su equipo.
* **RF11:** El entrenador debe de poder visualizar la tabla de clasificación de la liga. Esta misma tabla compara los puntos de los partidos jugados, cuenta los partidos ganados y perdidos y saca el ranking.
* **RF12:** El entrenador debe poder ver las estadísticas de los jugadores por temporadas que están ahora mismo en activo.
* **RF13:** El administrador debe poder añadir jugadores, y el sistema debe comprobar que no haya ya un jugador con ese dorsal en ese equipo.
* **RF14:** El administrador podrá “activar” / “desactivar” / “borrar permanentemente” jugadores dependiendo si tiene registros en la tabla de “stats_partidos”. Si no tiene registros le da las opciones de desactivarlo o borrarlo permanentemente. Si tiene registros, solo deja desactivarlo (por tema de integridad de datos). Si el jugador está desactivado, se puede volver a activar.
* **RF15:** El administrador debe poder añadir cualquier entrenador / administrador, pero no podrá borrarse a sí mismo de la base de datos.
* **RF16:** El administrador debe poder añadir / eliminar / modificar una estadística histórica de cualquier jugador que esté en activo.
* **RF17:** El administrador podrá añadir partidos (inicializados a 0 puntos) y gestionar los puntos mediante la suma de los registros de partidos (tabla “stats_partidos”). Al intentar modificar un partido ya jugado, no podrá cambiar el equipo que juega ese encuentro. Al añadir registros del partido, solo podrá anotar puntos los jugadores que juegan en cada equipo del encuentro.
* **RF18:** El sistema debe incluir un buscador dinámico en tiempo real capaz de filtrar registros por texto en las tablas de gran volumen de datos (como la gestión global del administrador o la sección de ojear).

**Requisitos No Funcionales (RNF):** Son las cualidades y límites del sistema.
* **RNF1 (Seguridad):** Casi todos los datos de un equipo solo deben ser visibles para su entrenador asignado.
* **RNF2 (Persistencia):** Los datos deben almacenarse en una base da datos relacional MySQL.
* **RNF3 (Usabilidad):** La interfaz debe ser intuitiva y evitar la apertura de ventanas emergentes innecesarias (Modelo MDI).
* **RNF4 (Compatibilidad):** El programa debe de ser compatible con Windows 10 y Windows 11.

### Diagrama de casos de uso
Este diagrama muestra la interacción entre los usuarios (actores) y las funciones principales de la aplicación.
* **Actores:** Entrenador y Administrador
* **Casos de uso principales:** Gestionar plantilla, dibujar jugadas, consultar clasificación, gestionar credenciales, visualizar clasificación, gestionar partidos y gestionar la base de datos.

![Diagrama de Casos de Uso](ruta-a-la-foto)

### Descripción de casos de usos

**Caso de uso: Gestión de partidos**
* **Actor:** Administrador.
* **Flujo principal:** El administrador selecciona los equipos que juegan, la jornada y la fecha → El sistema crea el partido inicializado 0 - 0 → El administrador le da a “Gestionar resultado” → El sistema abre un nuevo formulario → El administrador añade las estadísticas del partido de cada jugador que anota (tiros anotados, rebotes, faltas, minutos jugados, pérdidas, etc…) → El sistema actualiza el resultado cada vez que se añade un registro de un jugador → El administrador vuelve a atrás → El sistema guarda el partido con el resultado → El sistema guarda en todas las tablas los registros guardados y actualiza en tiempo real dichas tablas.

**Caso de uso: Modificar un jugador.**
* **Actor:** Administrador.
* **Precondición:** El jugador debe existir ya en la base de datos.
* **Flujo principal:** El administrador rellena los campos y le da a guardar → El sistema comprueba que no exista ningún jugador con el mismo dorsal en el equipo seleccionado.
* **Postcondición:** Si el jugador actualizado ya tenía registros con su equipo, esos se guardan con el equipo con id del equipo en el que estaba.

**Caso de uso: Dibujar jugada**
* **Actor:** Entrenador.
* **Flujo principal:** El entrenador abre la pizarra → El entrenador selecciona la opción de “Mover” y posicionar a los jugadores → los mueve a su gusto → selecciona la opción de “Dibujar” para trazar trayectorias → El entrenador cuando quiera limpiar las líneas, le da al botón de “Limpiar”.
* **Postcondición:** Si cambia de formulario y vuelve a entrar, las posiciones y las líneas se habrán restablecido.

**Caso de uso: Log in**
* **Actor:** Cualquiera.
* **Precondición:** Saber una credencial.
* **Flujo 1:** El usuario introduce sus credenciales → El sistema las válida e identifica el rol → El sistema muestra una pantalla de carga → El sistema muestra la interfaz del usuario.
* **Flujo 2:** El usuario introduce sus credenciales → El sistema no valida la credencial → El sistema muestra un mensaje que informa al usuario que las credenciales son incorrectas.
* **Postcondición:** Dependiendo del rol con el que ha iniciado sesión, el sistema te abre una interfaz u otra.

### Diagrama de clases

**Diagrama de clases simplificado:**
![Diagrama de clases simplificado](ruta-a-la-foto)

**Diagrama de clases detallado:**
* **Entrenador:**
![Diagrama detallado entrenador](ruta-a-la-foto)
* **Administrador:**
![Diagrama detallado administrador](ruta-a-la-foto)

---

## Fases del proyecto

### Diseño

#### Base de datos
El sistema HoopManager utiliza una base de datos relacional MySQL diseñada para centralizar la información deportiva y técnica de una liga de baloncesto. He priorizado la integridad referencial y la escalabilidad mediante una arquitectura que separa la gestión (jugadores/equipos) de identidades de los registros transaccionales (estadísticas de juego).

#### Estándares Técnicos
Para garantizar la consistencia en todo el esquema se ha aplicado los siguientes criterios de diseño:
* **Identificación Unívoca (ID):** Todas las tablas utilizan una Clave Primaria (PK) de tipo `INT(11)`. Se ha configurado con la propiedad Auto-increment para que el motor gestione la numeración de los registros de forma automática. Así me aseguro que cada entidad tenga un identificador único e irrepetible, facilitando las relaciones y evitando cualquier duplicidad de datos.
* **Motor de Almacenamiento (InnoDB):** Se ha seleccionado InnoDB por ser el motor que mejor gestiona la integridad referencial. Su uso es imprescindible en este proyecto ya que permite la implementación física de Claves Foráneas (FK). Esto garantiza que las relaciones entre tablas sean consistentes, impidiendo, por ejemplo, la eliminación de un equipo si todavía existen jugadores vinculados a él. Además, ofrece seguridad ante fallos del sistema mediante su soporte para transacciones seguras.
* **Codificación (utf8mb4_general_ci):** Se ha aplicado este estándar de codificación para permitir el soporte completo de caracteres internacionales, tildes y símbolos. En una aplicación de baloncesto profesional, esto es fundamental para asegurar que los apellidos de jugadores extranjeros (ej. Dončić) se almacenen y visualicen correctamente en la interfaz, evitando errores de lectura o caracteres extraños.

#### Diccionario de Datos
*(Nota: El campo id se omite en las tablas siguientes por ser el estándar autoincremental aplicado a todo el esquema).*

* **Tabla de Equipos (`equipos`):** Representa la entidad maestra de la liga. Contiene el nombre oficial del club (campo obligatorio), la ciudad de procedencia para contextualizar la competición y el campo `logo_url`, diseñado para almacenar la ruta de acceso al recurso gráfico que se renderizará dinámicamente en los formularios de la aplicación.
* **Tabla de Jugadores (`jugadores`):** Gestiona la información biográfica y deportiva. Incluye campos técnicos como `posicion`, `altura_cm` y `dorsal`. Su campo más relevante para la lógica de negocio es `activo` (de tipo booleano), que permite realizar un borrado lógico. Esta estrategia es fundamental en gestión deportiva: si un jugador causa baja, no se elimina físicamente su registro para no romper los históricos de puntos, sino que simplemente se desactiva para que el sistema deje de mostrarlo en las plantillas actuales. Se vincula a equipos mediante la Clave Foránea `id_equipo`.
* **Tabla de Estadísticas Históricas (`stats_historicas`):** Almacena el rendimiento consolidado de los jugadores en campañas anteriores para permitir análisis de scouting y comparativas de evolución. Utiliza una relación foránea (`id_jugador`) que vincula cada registro con la ficha maestra del deportista. Los campos destinados a las medias de puntos, rebotes y asistencias están definidos técnicamente como `DECIMAL(4,1)`, lo que garantiza la precisión decimal exigida en el análisis estadístico profesional, mientras que el campo temporada actúa como el descriptor temporal necesario para organizar los datos cronológicamente y generar gráficas de progresión de rendimiento dentro de la interfaz.
* **Tabla de Partidos (`partidos`):** Registra el calendario oficial mediante los campos jornada y fecha. Utiliza una estructura de doble relación foránea (`id_local` e `id_visitante`) para conectar dos registros de la tabla equipos en un mismo evento. Los campos `puntos_local` y `puntos_visitante` almacenan el marcador acumulado, mientras que el campo jugado (`TINYINT`) funciona como un controlador lógico que determina si el resultado es oficial y debe integrarse en los cálculos de la clasificación.
* **Tabla de Estadísticas (`stats_partidos`):** Es la tabla de mayor volumen y complejidad. Almacena 14 campos numéricos (`t2_metidos`, `t3_intentados`, `reb_ofensivos`, etc.) todos con valor predeterminado 0 para asegurar la integridad de las fórmulas. El campo `valoracion` guarda el resultado del algoritmo de eficiencia calculado en C#. Al ser una tabla que vincula a un jugador con un partido, actúa como el registro transaccional de cada acción realizada en la pista.
* **Tabla de Usuarios (`usuarios`):** Gestiona el control de acceso al sistema. El campo `nombre_usuario` cuenta con una restricción Unique para evitar duplicidades de login. El campo rol segmenta los privilegios de uso, mientras que `id_equipo` (FK) actúa como un filtro de seguridad para que los entrenadores solo tengan acceso a los datos de su propia plantilla.
* **Tabla de Entrenamientos (`entrenamientos`):** Funciona como un catálogo de ejercicios técnicos. Almacena el nombre de la rutina, el tipo de entrenamiento (ej. `MEJORA_TIRO` o `TACTICA_DEFENSA`) y una descripción detallada del ejercicio. Esta tabla es independiente a nivel de relaciones físicas, pero se vincula lógicamente a través de la aplicación para ofrecer recomendaciones de entrenamiento basadas en las carencias estadísticas detectadas en los jugadores.
* **Vista de Clasificación (`vista_clasificacion`):** A diferencia de las anteriores, esta es una vista basada en una consulta SQL compleja. No almacena datos físicamente, sino que los genera en tiempo real extrayendo información de las tablas de equipos y partidos. Sus campos son:
  * **Equipo:** Nombre del conjunto extraído de la tabla maestra.
  * **PJ (Partidos Jugados):** Conteo automático de encuentros donde el campo jugado es igual a 1.
  * **Victorias / Derrotas:** Cálculo dinámico comparando los puntos de local y visitante en cada jornada.
  * **Diferencia_Puntos:** Balance neto entre puntos anotados y recibidos, utilizado como criterio de desempate en la tabla.

#### Relaciones de Cardinalidad y Modelo Relacional
El modelo se basa en un esquema de estrella donde la integridad se mantiene a través de las siguientes relaciones de cardinalidad:
* **Relación Equipos - Jugadores (1:N):** Representa la pertenencia de los deportistas a un club. Un equipo actúa como contenedor de múltiples registros de jugadores, vinculados mediante la clave foránea `id_equipo`. Esta estructura asegura que cada ficha de jugador esté asociada unívocamente a una entidad de equipo, permitiendo al sistema filtrar las plantillas de forma automática.
* **Relación Jugadores - Stats_Partidos (1:N):** Define el origen de los datos de rendimiento. Un jugador es el punto de partida de múltiples líneas estadísticas generadas a lo largo de la temporada. Cada vez que el usuario registra una actuación en un encuentro, se crea un registro dependiente en la tabla de estadísticas que hereda el identificador del jugador.
* **Relación Partidos - Stats_Partidos (1:N):** Permite la reconstrucción de las actas digitales. Un único registro de partido aglutina todos los datos individuales de los jugadores que han participado en el mismo. Esta relación es la que permite al software sumar los puntos individuales para calcular, en tiempo real, el marcador global del encuentro.
* **Relación Jugadores - Partidos (N:M):** Es la relación más compleja del sistema y queda resuelta mediante la tabla `stats_partidos`, que actúa como entidad asociativa. Dado que un jugador participa en muchos partidos y un partido cuenta con muchos jugadores, esta tabla intermedia rompe la relación de muchos a muchos para permitir un seguimiento individualizado.
* **Relación Equipos - Partidos (1:N):** Representa la participación de los clubes en el calendario de competición. Cada equipo se vincula a múltiples registros de la tabla partidos a través de una estructura de doble clave foránea (`id_local` e `id_visitante`). Esto permite al sistema identificar quién es el anfitrión y quién el visitante, facilitando el cálculo de la ventaja de campo en los informes.
* **Relación Jugadores - Stats_Historicas (1:N):** Establece la conexión cronológica con la trayectoria previa del deportista. Un jugador puede estar vinculado a varios registros de promedios históricos (uno por cada temporada disputada), lo que permite al sistema generar gráficas de evolución y comparativas de rendimiento año tras año.
* **Relación Equipos - Usuarios (1:N):** Define la jerarquía de seguridad y el control de acceso. Un equipo se asocia a uno o varios usuarios (entrenadores) mediante el campo `id_equipo` en la tabla de usuarios. Esta relación es el pilar de la privacidad del sistema, ya que garantiza que un técnico solo pueda gestionar y visualizar los datos de su propia plantilla tras iniciar sesión.

#### Diagrama de Componentes
![Diagrama de Componentes](ruta-a-la-foto)

La arquitectura de HoopManager se basa en un modelo de tres capas, lo que permite una separación clara de responsabilidades y facilita el mantenimiento del sistema:
* **Capa de presentación:** Gestiona la interacción con el usuario. He integrado tecnologías de WinForms para la gestión de datos y WPF usando un ElementHost para la pizarra táctica, logrando una interfaz híbrida, fuerte y fluida.
* **Capa de lógica de negocio:** Es el núcleo donde reside la inteligencia del software. Aquí se procesan los cálculos para sacar la valoración de cada jugador (PIR), entrenamientos basados en el promedio y las reglas de validación de seguridad para los distintos roles.
* **Capa de acceso a datos:** Esta capa actúa como puente con MySQL. La conexión a la base de datos y la ejecución de las consultas SQL se gestionan a través de variables de conexión (`MySqlConnection`) instanciadas directamente en los bloques de código que lo requieren. Esto permite abrir y cerrar el flujo de datos de manera específica en cada formulario, asegurando que la comunicación con el servidor solo se establezca cuando es estrictamente necesario.

#### Diagrama de Navegabilidad
Este esquema visualiza el recorrido lógico desde el inicio de sesión hasta el cierre de la aplicación, aclarando la navegación dependiendo del rol del usuario.

![Diagrama de Navegabilidad](ruta-a-la-foto)

* **Acceso y carga inicial:** El punto de partida es el Inicio de sesión. Tras validar las credenciales, aparece una pantalla de carga antes de abrir el formulario que corresponde al rol del usuario.
* **Segmentación por roles:** dependiendo del tipo de usuario, el sistema redirige automáticamente a la pantalla de entrenador o a la de administrador. Cada pantalla tiene unos botones únicos.
* **Panel de Entrenador:** Permite el acceso directo a herramientas de análisis y estratégia. Hay navegación jerárquica, permito descender un nivel más hacia los entrenamientos recomendados.
* **Panel de Administrador:** Se centra en la gestión de datos. Incluye el control de credenciales, de jugadores, de estadísticas históricas y la creación de partidos y sus puntos.
* **Ciclos de retorno y Cierre de app:** He programado botones de retorno en todos los niveles para que el usuario pueda regresar a los paneles principales o al Log in sin tener que reiniciar la app. También hay un botón de cierre de aplicación el que puedes accionar en cualquier pantalla del programa.

#### Interfaz (diseño)
Al principio, la interfaz de HoopManager era básicamente una pantalla con botones sueltos colocados en forma de cuadrícula. El problema de hacerlo así era que, cada vez que pinchabas en uno, te saltaba una ventana nueva e independiente.

Al ir haciendo pruebas, vi que esto era un caos al navegar. Además, era una pérdida innecesaria de recursos para el ordenador, porque acababas con un montón de ventanas abiertas a la vez.

Al final, decidí cambiar por completo la estructura y pasarme a un modelo MDI (Multiple Document Interface). De esta forma, conseguí que todos los apartados se abran dentro de una misma ventana principal, lo que hace que todo sea mucho más limpio, ordenado y eficiente.

Este nuevo enfoque permite integrar todas las funcionalidades dentro de un único contenedor principal, aprovechando los formularios desarrollados previamente y mejorando la cohesión visual de la herramienta. La estructura final se divide en dos áreas diferenciadas:
* **Panel de navegación (Izquierdo):** Un área estática que alberga los controles de acceso a las distintas funciones, así como los comandos de gestión de sesión (cerrar sesión y salir).
* **Panel dinámico (Derecho):** Un contenedor encargado de incrustar y mostrar los distintos formularios llamados desde el panel de navegación, manteniendo siempre el contexto de la aplicación principal.

**Interfaz antes de integrar el modelo MDI:**
![Interfaz antes MDI 1](ruta-a-la-foto)
![Interfaz antes MDI 2](ruta-a-la-foto)

A lo largo del desarrollo del proyecto he ido cambiando mucho el color de botones, fondo, tablas para decidirme cuál me gustaba más. Finalmente esta es la interfaz de HoopManager final con el modelo MDI:

**Log in**
El formulario de inicio de sesión es el primer punto de contacto del usuario con HoopManager. Se ha diseñado buscando una estética limpia y temática, dividiendo la interfaz en una zona visual de bienvenida y una zona funcional de introducción de credenciales.

Para lograr una interfaz intuitiva y bonita he utilizado los siguientes elementos:

* **Composición Visual:** Para el montaje de esta interfaz he utilizado 6 recursos gráficos importantes cada uno con un funcionamiento específico.
* **Elementos visuales para identidad:** Incluyo una imagen temática de una cancha de baloncesto y el logo de mi app.
* **Iconos funcionales:** He usado iconos específicos para los campos de usuario y contraseña para que la interfaz sea más intuitiva.
* **Control de Sesión:** He programado un icono para salir de la app que cuenta con un evento Click. Llama a una función que cierra la app sin que queden subprocesos abiertos en segundo plano.
* **Gestión de privacidad:** Un icono de un ojo para conmutar la visibilidad de la contraseña.
* **Componentes de entrada y validación:** El formulario utiliza 2 TextLabel para recoger los datos y un botón para la ejecución de la lógica.
* **Lógica de Acceso:** Al interactuar con el botón el sistema no solo valida que las credenciales existan y coincidan en la base de datos, sino que identifican el rol del usuario. Esto permite al programa decidir que formulario abrir (admin o entrenador).
* **Seguridad y control de ventana:** He decidido ocultar la barra superior estándar de la ventana para evitar que el usuario cierre la aplicación dandole a la X del sistema operativo, ya que al estar realizando pruebas, se me quedaba algún subproceso en ejecución. Al obligar al usuario a cerrar con un botón, me aseguro que la aplicación se cierre totalmente.

![Pantalla de Login](ruta-a-la-foto)

**Pantalla de carga:**
Antes de acceder al formulario de login, he implementado una pantalla de carga. Aunque es un elemento breve, he decidido implementar para mejorar la experiencia del usuario y dar una sensación de profesionalidad.

* **Componentes y estética:** Esta pantalla tiene un estilo minimalista utilizando pocos elementos:
  * **Identidad de Marca:** En el centro de la pantalla aparece el logo de la aplicación.
  * **Barra de progreso:** Control visual añadido debajo del logotipo que informa al usuario cuánto queda para que se inicie la aplicación. Está programado que dure alrededor de 3 segundos.
  * **Label informativo:** Encima de la barra de carga, aparece un campo en el que pone “Preparando la cancha…”.

**Panel del entrenador**
Una vez superado el acceso, el usuario con rol “Entrenador” entra en su panel de gestión. He diseñado esta interfaz bajo una arquitectura de formulario contenedor dividida en 2 grandes bloques para que la navegación sea lo más intuitiva posible y no haya que estar abriendo y cerrando ventanas.

![Panel del entrenador](ruta-a-la-foto)

**Estructura y lógica de navegación**
La pantalla se divide en 2 secciones principales:
* **Panel izquierdo (Control):** Es un área estática que siempre permanece visible. He incluido el logo de HoopManager en la parte inferior y un espacio para el escudo del equipo en la parte superior.
* **Panel derecho (Espacio de trabajo):** Es un panel dinámico donde se van cargando los diferentes formularios según la opción elegida.

Para los botones del menú, decidí crear paneles personalizados en lugar de usar botones estándar. Cada “botón” está formado por un panel que contiene una imagen y un Label. Para que la usabilidad sea perfecta y el usuario no tenga que apuntar con precisión con el ratón, asigné un evento click a los 3 elementos (panel, imagen y texto) que llaman a una función a la que le paso el formulario que quiero mostrar. Esta función se encarga de limpiar el panel derecho y cargar el nuevo formulario. Además, he programado dos eventos `MouseEnter` y `MouseLeave` para que los textos cambien de color al pasar el ratón por encima.

**Detalles técnico del menú**
Para que este menú parezca profesional, he programado dos funciones:
* **Gestión de Formulario Hijos (`AbrirPantallaHija()`):** En lugar de mostrar ventanas, he creado un método que gestiona la memoria y la visualización. Cada vez que el entrenador pulsa un botón:
  * El sistema comprueba si ya hay un formulario abierto, y si está abierto lo limpia para liberar memoria.
  * He configurado los formularios para que, en lugar de abrirse como ventanas externas, se comporten como componentes internos del panel principal (incrustados dentro del panel derecho).
* **Personalización Dinámica del Escudo (`CargarLogoEscudo()`):** Para que el entrenador no tenga dudas que está en el panel de entrenador de su equipo el sistema le muestra el logo de su equipo automáticamente. Lo que hace esta función es:
  * Recibir el ID del equipo del entrenador logueado.
  * Buscar la ruta del logo.
  * Comprueba que la foto está en la carpeta para evitar que se rompa el programa.

**Módulos de gestión**

**Mi Plantilla y Entrenamientos Recomendados (“Mi plantilla”)**
![Módulo Plantilla](ruta-a-la-foto)
Este módulo permite al entrenador gestionar su equipo de forma directa. He diseñado una interfaz que combina la visualización masiva de datos con un sistema de consulta rápida y diagnóstico.
* **Funcionamiento y autocompletado:** El formulario carga automáticamente a los jugadores activos del club gracias a un filtro que utiliza el ID del entrenador en la sesión actual. Para mejorar la experiencia del entrenador, he programado el evento `CellContentClick` en la tabla. Al seleccionar cualquier jugador, sus datos se autocompletan en sus respectivos campos de texto.
* **Permisos y seguridad:** He decidido restringir la edición aquí para asegurar la integridad de la base de datos. El entrenador puede visualizar y analizar a su plantilla, pero no tiene permisos para alterar registros que corresponden al administrador para proteger los datos.
* **Algoritmo de diagnóstico de entrenamiento:** Al pulsar el botón de “Ver entrenamientos recomendados”, la app ejecuta un subproceso de análisis avanzado sobre el jugador seleccionado. En lugar de dar consejos genéricos, el código realiza una consulta a la tabla `stats_partidos` analizando los últimos 4 partidos:
  * **Detección de medias bajas:** El sistema evalúa 3 aspectos: si el % de triple es inferior al 50%, si las pérdidas de balón superan las 3 por partido o si el porcentaje de tiros libres baja del 60%.
  * **Asignación de rutinas:** Dependiendo de los aspectos con baja media detectados, el programa genera una lista dinámica de tipos de entrenamiento. Si el jugador no tiene muchos fallos se notifica con un mensaje.
  * **Carga dinámica de entrenamientos:** Al final, el programa realiza una consulta para extraer de la base de datos exclusivamente las instrucciones y categorías de los ejercicios que corrigen las debilidades detectadas, mostrando una tabla (Grid) personalizada para cada caso.

**Pizarra de Jugadas (Módulo Vectorial) (“Pizarra táctica”)**
Este es el módulo más especial del programa. A diferencia del resto, aquí no trabajo con tablas de la base de datos, sino con vectores y gráficos. He desarrollado un formulario interactivo para que el entrenador pueda diseñar jugadas en tiempo real.
* **Integración de tecnologías (WPF + WinForms):** Para lograr una pizarra fluida y profesional, he usado WPF (Windows Presentation Foundation) dentro de un entorno de Windows Forms. Para ello he tenido que usar un `ElementHost` que permite incrustar controles avanzados de diseño en la aplicación principal, combinando la robustez de la gestión de datos con la potencia gráfica a WPF.
* **Sistemas de Dibujo (InkCanvas):** He implementado un componente `InkCanvas` configurado para que el trazado sea suave y limpio. El sistema permite al entrenador dibujar trayectorias, bloqueos o pases a mano alzada en color blanco con un grosor predefinido (el entrenador no lo puede cambiar), incluyendo una función de borrado total para limpiar las trayectorias con un solo click.
* **Lógica de arrastre de fichas:** He desarrollado unas funciones de movimiento manual para los jugadores y el balón. Mediante los eventos `MouseDown`, `MouseMove` y `MouseUp`, el sistema calcula la diferencia de posición con el ratón y actualiza las coordenadas de las fichas en el formulario. Para que esto funcione he programado un sistema de cambio de modos:
  * En el modo Dibujar, la capa de pintar captura el ratón.
  * En el modo Mover, la capa de dibujo se vuelve transparente a los clicks (`IsHitTestVisible = false`), permitiendo al usuario coger y mover las fichas libremente por el formulario.

**Módulos de Competición**

**Historial de partidos (“Partidos”)**
![Historial Partidos](ruta-a-la-foto)
Es un formulario sencillo donde el entrenador puede consultar los resultados de los partidos ya jugados de su equipo.
* **Funcionamiento:** Muestra una tabla con los partidos finalizados. He programado una consulta con `JOINs` para que en lugar de aparecer los números de ID de los equipos, el entrenador vea directamente los nombres reales.
* **Filtro de sesión:** El código detecta qué entrenador ha entrado y filtra los datos para que solo aparezcan sus propios partidos, protegiendo así la privacidad de los demás equipos.

**Clasificación Dinámica (“Clasificación”)**
![Clasificación](ruta-a-la-foto)
Para la tabla de clasificación, no me limité a mostrar una tabla estática. He creado una consulta de SQL avanzada que procesa todos los partidos jugados. La consulta calcula en tiempo real: victorias, derrotas, puntos totales y la diferencia de puntos. El resultado se muestra en una tabla (Grid) ya ordenado por la posición real que ocupa cada equipo en el ranking de la liga.
* **Lógica SQL:** Para que la clasificación cambie automáticamente, la consulta utiliza operaciones tipo `SUM(Case…)`. El sistema analiza cada partido y decide si el equipo fue local o visitante para sumar correctamente los puntos y los resultados. He configurado el orden oficial de la competición: primero por victorias, luego por diferencia de puntos y, finalmente, por puntos a favor.
* **Ranking Dinámico:** Una vez recibidos los datos de la base de datos, he programado un bucle que genera una columna de posición (Pos) en tiempo real. Esto permite que el ranking aparezca numerado del 1 al final sin necesidad de guardar ese dato fijo en la base de datos, haciendo que la tabla se actualice sola según los resultados de los partidos.

**Módulos de Análisis**

**Estadísticas históricas para ojear (“Ojear”)**
Este formulario permite al entrenador realizar un trabajo del scouting al consultar la trayectoria histórica de los jugadores que participan en la liga.
* **Funcionamiento:** Muestra una tabla con los registros de temporadas pasadas almacenado en la tabla de `stats_historicas`. He programado una consulta con `JOIN` para que el sistema vincule cada registro con el nombre del jugador correspondiente, mostrando sus medias de puntos, asistencias y % triples.
* **Lógica del “scouting” (ojear):** La utilidad de este formulario es que el entrenador pueda comparar el nivel actual de un jugador con su rendimiento en años anteriores. He configurado la consulta para que los datos aparezcan ordenados alfabéticamente por nombre y de la temporada más reciente a la más antigua, facilitando así el análisis de la progresión de cada deportista para posibles estrategias o fichajes.
* **Filtrado rápido:** Para que la herramienta sea realmente ágil en la toma de decisiones, este formulario cuenta con una barra de búsqueda dinámica. Con solo empezar a escribir el nombre de un jugador, el sistema filtra y muestra en la tabla las coincidencias. Esto evita que el entrenador tenga que hacer un barrido visual por todos los registros de todos los jugadores de la liga.

**Estadísticas de liga y sistema de valoración (PIR) (“Estadísticas Liga”)**
En el módulo de análisis, quería que la aplicación fuera lo más profesional posible. Por eso, en lugar de usar criterios subjetivos, implementé el PIR (Performance Index Rating), que es el sistema oficial de la liga ACB y la Euroliga.
* **Fórmula:** `Val = (Puntos + Rebotes + Asistencias + Robos + Tapones) - (T2F + T3F + TLF + Pérdidas + Faltas)`.
* Para obtener los tiros fallados (T2F, T3F Y TLF), el sistema realiza una operación restando los aciertos a los intentos:
  * `T2F = T2I - T2M`
  * `T3F = T3I - T3M`
  * `TLF = TLI - TLM`

He elegido este sistema de valoración porque los números no mienten. Mientras que en otras ligas, como es en la NBA los premios pueden ser subjetivos (votaciones de periodistas), con el PIR el entrenador de mi aplicación tiene un dato matemático real para decidir quien está siendo eficiente y tomar decisiones justas y no subjetivas.

* **Lógica de agregación y cálculo (SQL):** para que este formulario funcione, he programado una consulta avanzada que no solo lee datos, sino que los procesa en tiempo real. Utilizo funciones de agregación como `COUNT` para saber los partidos jugados (PJ) y `AVG` para calcular los promedios de puntos (PPP), asistencias (APP) y valoración (VAL). Y para que la tabla sea bonita y fácil de leer, he usado `ROUND` para mostrar solo un decimal.
* **Ranking de votación:** La consulta está configurada para ordenar la tabla automáticamente de mayor a menor según los puntos por partido. Así, el sistema genera de forma dinámica un ranking de los máximos anotadores de la liga cada vez que se abre el formulario.
* **Filtro dinámico de jugadores:** Ya que esta vista agrupa a todos los jugadores de la liga en un único ranking general, localizar a un jugador concreto requiere tiempo para encontrarlo en la tabla. Para solucionarlo, he implementado un buscador en tiempo real sobre la tabla de resultados. Esto permite al entrenador teclear el nombre de un jugador rival y buscar sus promedios y su valoración PIR.

**Panel del administrador**
Una vez superado el acceso, el usuario con rol “admin” entra en su panel de control central. Al igual que el entorno del entrenador, he diseñado esta interfaz bajo una arquitectura de formulario contenedor dividida en 2 grandes bloques. Esto asegura que la navegación para gestionar toda la base de datos sea lo más ágil e intuitiva posible, manteniendo el área de trabajo limpia y sin tener que estar abriendo y cerrando ventanas continuamente.

![Panel del administrador](ruta-a-la-foto)

**Gestión de jugadores (“Jugadores”)**
Este formulario centraliza la administración de las plantillas. La interfaz permite crear, editar, activar, desactivar, consultar y borrar jugadores desde una misma interfaz.
* **Lógica de guardado dual (Upsert):** He programado el botón de “Guardar” para que sea inteligente. Al pulsarlo, el sistema evalúa si el nombre del jugador ya existe. Si es así, ejecuta un `UPDATE` y actualiza datos, y si no existe, lo registra con un `INSERT` inicializando los campos de las estadísticas con valores por defecto.
* **Control de integridad (Dorsal):** Esta interfaz incluye validaciones que impiden asignar a un jugador un dorsal que ya esté en uso dentro de su mismo equipo.
* **Gestión de estado y borrado:** El botón de eliminación ha sido diseñado para actuar de forma contextual dependiendo del historial del jugador. Si el jugador no tiene ninguna estadística registrada, el sistema permite su borrado permanente (borrado en cascada) o darlo de baja (desactivarlo). Sin embargo, si el jugador tiene al menos una estadística el botón adapta su función para aplicar un borrado lógico (desactivar jugador). Esto oculta al jugador de las plantillas actuales pero preserva la integridad de los datos históricos y los marcadores de los partidos. Desde este mismo botón, el administrador puede revertir la acción y poder activar de vuelta al jugador previamente dado de baja.
* **Filtrado dinámico en tiempo real:** Al gestionar la totalidad de la base de datos, el volumen de registros crece. Por ello, he integrado un buscador dinámico conectado a la vista de datos que filtra los resultados instantáneamente con cada input de cada tecla, siendo una herramienta necesaria para la operatividad del administrador.

**Gestión de partidos y puntos (“Partidos”)**
Esta es la interfaz con la lógica relacional más completa y compleja. Desde aquí se estructura el calendario oficial de la liga y se registran los resultados a través de otra interfaz.
* **Creación de partidos:** el administrador solo debe seleccionar los equipos implicados (local y visitante), la jornada y la fecha.
* **Sincronización de marcadores:** Para garantizar la integridad de los resultados, el partido se genera siempre con el marcador inicial en 0 - 0. El formulario bloquea la edición manual de los puntos totales, ya que la app calcula automáticamente el marcador en función de las estadísticas individuales.
* **Gestión de estadísticas del partido:** A través del botón “Gestionar estadísticas”, el administrador accede a un formulario dedicado a la tabla de `stats_partidos`. Aquí se introducen los registros individuales de cada jugador en ese partido en específico (tiros de 2 o 3 puntos metidos, intentados, rebotes, pérdidas, tapones, etc.). He programado el sistema para que cada vez que se guarda el registro de un jugador, se actualice en tiempo real el marcador global del partido sumando los puntos.

**Gestión de estadísticas de temporadas anteriores (“Estadísticas históricas”)**
Este formulario está hecho para meter datos a la base de datos de la función “Ojear” del entrenador.
![Estadísticas históricas](ruta-a-la-foto)
* **Filtro de visualización:** la interfaz solo permite gestionar estadísticas de jugadores que estén actualmente asignados a un equipo, ocultando a los inactivos para facilitar la búsqueda.
* **Prevención de duplicados:** He programado una validación cruzada que comprueba el ID del jugador y la temporada. El sistema bloquea cualquier intento de guardar dos registros del mismo jugador en un mismo año.
* **Búsqueda dinámica:** Al tratarse de un registro histórico que acumula múltiples temporadas de todos los jugadores de la liga, he implementado un buscador en tiempo real. Este filtro actúa directamente sobre la vista de datos, permitiendo al administrador localizar instantáneamente el registro de cualquier deportista escribiendo su nombre.

**Gestión de las credenciales (“Credenciales”)**
Este formulario actúa como panel de seguridad del sistema. Desde aquí, el administrador tiene el control total sobre quién puede acceder a la aplicación y qué puede ver.
![Credenciales](ruta-a-la-foto)
* **Gestión de roles:** Aquí se permite dar de alta a nuevos administradores y entrenadores.
* **Asignación de privacidad:** Al crear una credencial de tipo “Entrenador”, la interfaz exige vincular ese entrenador a un equipo específico de la lista disponible. Y al crear a un administrador, si se le intenta asignar un equipo, el sistema lo ignora e inicializa como null.
* **Protección de sesión activa:** Para evitar fallos críticos que puedan comprometer al acceso al sistema (la base de datos se quede sin administradores), he implementado una regla de seguridad que se basa en no poder borrar el usuario de administrador con el que has iniciado sesión en ese momento.

---

## Implementación y configuración

### Herramientas utilizadas:
* **Lenguaje de programación:** C# con el framework .NET Core/6.
  * **¿Por qué este lenguaje?:** Porque es el lenguaje que he aprendido en clase.
* **Entorno de Desarrollo Integrado (IDE):** Visual Studio 2026.
  * **¿Por qué he elegido este IDE?:** Porque es el IDE que he usado en clase, es el único que sé que me permite hacer estas interfaces y porque también sé sus límites.
* **Sistema de gestión de base de datos:** MySQL.
  * **¿Por qué MySQL?:** Porque es robusto y relacional.
* **Gestor de base de datos:** DBeaver.
  * **¿Por qué DBeaver?:** Porque me parece muy intuitivo y es el que más he utilizado.
* **Interfaz de usuario:** WPF (Windows Presentation Foundation), XAML.
  * **¿Por qué?:** Necesario para hacer la pizarra.
* **Organización y notas:** Google Keep.
  * **¿Porqué Google Keep y no otra?:** He elegido esta herramienta de Google por dos motivos principales: la uso a diario para cualquier anotación y puedo consultarla desde cualquier dispositivo con solo tener mi cuenta de Google. Me ha sido fundamental para el desarrollo del proyecto porque me permitía apuntar al momento cualquier idea o duda que me surgiera, estuviera o no trabajando en el TFC en ese momento.
* **Paquetes NuGet:**
  * **AltoControls:** Para mejorar el aspecto visual de la interfaz. Este paquete incluye elementos con casi el mismo funcionamiento que los predeterminados pero con un estilo distinto y más atractivo.

### Configuración del entorno de datos
* **Puesta en marcha con XAMPP (El Servidor):** Lo primero fue iniciar XAMPP para tener un servidor local funcionando en mi equipo. Me activé MySQL, que es el motor de base de datos donde vive toda la información del proyecto, y empecé a hacer las primeras pruebas de guardado y lectura.
* **Gestión visual con DBeaver (El Administrador):** Aunque MySQL hace el trabajo "por detrás", utilicé DBeaver para tener un IDE profesional de mi base de datos. Con esta herramienta diseñé las tablas, creé las relaciones entre ellas y revisé que los datos se estuvieran guardando correctamente.
* **Conexión con Visual Studio 2026 y C#:** Finalmente, conecté todo esto con mi código en Visual Studio. Configuré mi proyecto en C# (.NET 6) para que se conectara directamente con mi base de datos MySQL.

### Arquitectura del Software
Para que el código sea limpio y mantenible he seguido estas pautas:
* **Conexión a datos:** la comunicación con MySQL se gestiona instanciando variables de conexión (`MySqlConnection`) directamente en los bloques de código que lo requieren. Para optimizar el rendimiento y evitar fugas de memoria, he programado el sistema para que cada conexión se abra únicamente en el momento de ejecutar la consulta y se cierre de forma segura después de obtener o guardar los datos.
* **Gestión de paneles:** en vez de abrir muchas ventanas (puede llegar a confundir al usuario con tantos botones), he configurado un formulario principal que consta de 2 paneles (Menú y Formularios). El del menú es estático, y el de los formularios, cambia dependiendo de qué botón presionas. Cada botón hace un llamamiento a un formulario y este se muestra en el panel de formularios.
* **Seguridad por roles:** al hacer un inicio de sesión, se consulta en la base de datos aparte de que el usuario y contraseña son correctos, se comprueba el rol del usuario para abrir una interfaz u otra.

---

## Pruebas

Para garantizar que HoopManager sea una herramienta fiable para un cuerpo técnico, diseñé un plan de pruebas centrado en la estabilidad de los datos y la seguridad del código.

### Pruebas en Entorno de Desarrollo (Local con XAMPP)
Las primeras pruebas se realizaron utilizando XAMPP como servidor local. El objetivo era validar la lógica de la aplicación.
* **Pruebas de CRUD:** Verifiqué que desde los formularios de C# se podían insertar, consultar y modificar jugadores en la base de datos local correctamente.
* **Pruebas de Rendimiento Local:** Comprobé que la carga de estadísticas fuera fluida.
* **Resultado:** La app funcionaba perfectamente en mi equipo, pero presentaba la limitación de que los datos no eran accesibles para otros usuarios (entrenadores) desde fuera de mi red.

### Pruebas en un proyecto aislado (Sandbox)
Antes de integrar la pizarra táctica a mi proyecto, decidí crear un proyecto aparte con las mismas versiones y configuraciones de HoopManager.
* **Razón del aislamiento:** Realizar estas pruebas en un proyecto aislado me ha ahorrado riesgos de corrupción y de fallos que a lo mejor no iba a ser capaz de solventar rápidamente.

Tras validar el funcionamiento de la pizarra en el entorno de pruebas (sandbox), procedí a su integración definitiva en el proyecto principal.
* **Implementación y Enlace:** Una vez migrado el código, vinculé la funcionalidad al módulo correspondiente de la interfaz. La conexión fue inmediata y el sistema respondió con total estabilidad desde el primer despliegue.
* **Simulación de Usuario:** Para poner a prueba la experiencia real de un entrenador, realicé sesiones de uso intensivo simulando jugadas reales. Esto incluyó el desplazamiento fluido de las fichas y el trazado de líneas tácticas en tiempo real sobre el campo.
* **Resultado:** La herramienta demostró ser intuitiva y precisa, permitiendo diseñar estrategias de forma ágil, que es exactamente lo que un cuerpo técnico necesita en la alta competición.

### Control de errores

| Prueba ID | Módulo | Input del usuario | Resultado esperado | Estado |
| :--- | :--- | :--- | :--- | :--- |
| **PR-01** | Log in | Intentar iniciar sesión dejando los campos vacíos | El sistema no realiza la consulta y muestra un aviso de “Campos obligatorios” | OK |
| **PR-02** | Log in | Iniciar sesión con una credencial válida con rol “Entrenador” | El sistema abre la interfaz del entrenador cargando solo los datos de su equipo asignado. | OK |
| **PR-03** | Gestionar Jugadores | Intentar registrar un nuevo jugador asignando un dorsal que ya está en uso en su equipo. | Salta un error avisando que ese dorsal está en uso en su equipo y cancela el `INSERT` | OK |
| **PR-04** | Gestiona Jugadores | Pulsar el botón “Eliminar” sobre un jugador que ya tiene puntos registrados en la tabla `stats_partidos` | El sistema detecta la dependencia relacional y aplica automáticamente un borrado lógico (desactivar al jugador) para no corromper las tablas relacionadas con el ID del jugador | OK |
| **PR-05** | Gestión de partidos | Introducir letras o símbolos en las celdas numéricas (puntos, rebotes) del acta digital del partido (`stats_partidos`). | El componente utilizado para la inserción de dichos datos (`numericUpDown`), solo admite valores numéricos, bloqueando la entrada de caracteres y símbolos. | OK |
| **PR-06** | Gestión de credenciales | El administrador intenta borrar su propia cuenta de administrador con la que está iniciado sesión en es momento | El sistema lanza una excepción controlada, evitando la eliminación de la cuenta de la base de datos. | OK |

---

## Metodología aplicada

Para sacar adelante mi proyecto, no me he limitado a una sola metodología de trabajo. He seguido una metodología híbrida, es decir, he ido adaptando mi forma de trabajar según lo que el programa necesitaba en cada momento.

* **Principio: Ordenar ideas (Modelo en Cascada):** Al empezar, fui estricto. Antes de ponerme a "picar" código, dediqué bastante tiempo a definir la estructura de la base de datos y a pensar qué iba a necesitar exactamente un entrenador y un administrador. Tenía claro que si no diseñaba bien los cimientos desde el principio, el proyecto se acabaría convirtiendo en un problema. Tener que cambiar campos o relaciones en mitad del desarrollo me habría obligado a modificar todas las consultas SQL de los formularios en C#, lo que me habría hecho perder mucho tiempo.
* **Desarrollo: mejoras / añadidos en el desarrollo de la app (Enfoque Ágil):** Una vez que tuve los cimientos del proyecto, mi forma de trabajar pasó a ser más libre. No tenía definidas al completo las funciones del proyecto, pero sí una idea clara. Lo que mejor me ha funcionado ha sido:
  * **Anotar e implementar mejoras:** Muchas de las mejores funciones no estaban en mi plan inicial. Mientras probaba la aplicación se me ocurrían ideas. Una de estas es la de la pizarra de jugadas. Estas ideas me las apuntaba en Google Keep, ha sido mi herramienta imprescindible para apuntar las ideas que se me ocurrían en cualquier momento y lugar.
  * **Avanzar y probar:** Mi manera principal de trabajar era “hacer, probar y perfeccionar”. Me gusta probar un botón cuando lo programo, para no dejar errores para el futuro y que no se acumulen. Si algo fallaba lo intentaba arreglar al instante o lo dejaba apuntado para la siguiente sesión de desarrollo.
  * **Cambios por usabilidad:** si veía que algo no era cómodo para el usuario, lo cambiaba. Por ejemplo, al principio se iban a abrir muchas ventanas, pero pensé en un entrenador desorganizado y no muy familiarizado con la tecnología y decidí rediseñar la interfaz para facilitarle la navegación.

Al trabajar así, mezclando un poco de orden al principio y mucha flexibilidad después, he conseguido que el programa a parte de funcionar, sea útil y fácil de usar.

---

## Ampliación y posibles mejoras
* Poder grabar la pizarra de jugadas y recordar jugadas.
* Sustituir algún id autoincremental de las tablas y usar claves primarias compuestas.
* Poner todas las fotos de todos los jugadores y tener la posibilidad de modificar la foto y poder subirla desde el equipo.
* Tener la base de datos en la nube.
* Hacer una app móvil.
* Nuevos roles como por ejemplo “jugador”.
* Posibilidad de poner “jugador lesionado” y unos entrenamientos específicos para la recuperación / rehabilitación.
* Poder poner en la pizarra quien es cada jugador y contra quien es la jugada.
* Posibilidad de crear un entrenamiento siendo entrenador (y admin) y poner los valores límite que debe tener para que los recomiende.
* Alguna otra opción de manejo en la pizarra.

---

## Conclusión

Después de todo el trabajo que me ha llevado hacer HoopManager, la sensación que tengo es que he cumplido el objetivo inicial de sobra. Lo que empezó como una idea para digitalizar la gestión de una liga y de los equipos lo he convertido en una aplicación real, sólida y que hace su función, la de facilitar la vida a un equipo de baloncesto.

Durante el desarrollo me he centrado mucho en que la aplicación sea robusta. He aprendido que la clave de un buen software no es que solo funcione, sino que esté preparado para cualquier situación: desde gestionar bien un borrado en cascada sin errores hasta asegurar la integridad de los datos según el rol que esté usando la app. Resolver estas cosas y darle muchas vueltas a la lógica de las consultas SQL me ha dado una visión mas realista de cómo se construye un proyecto profesional.

Una de las cosas que más orgulloso estoy es la pizarra táctica. Al principio no tenía ni idea de si se podía hacer o no. Pero finalmente, con esfuerzo, la he conseguido hacer y mezclarla con WinForms para poder integrarla con el resto de la aplicación.

En conclusión, este TFC me ha servido para consolidar lo que he visto en el grado y aplicarlo a un proyecto complejo. Me llevo una aplicación de la que estoy muy contento y la experiencia de haber diseñado y programado un proyecto como es HoopManager desde cero.

---

## Bibliografía
* **Crear la interfaz y el lienzo de la pizarra:** https://www.youtube.com/watch?v=m7Ohm52TIhw 
* **Cómo capturar los eventos del ratón para dibujar en la pizarra:** https://www.youtube.com/watch?v=7Rs3TPq6k_s 
* **Pinterest para alguna de las fotografías:** https://es.pinterest.com/ 
* **Gemini para la resolución de dudas y manipulación de fotos:** https://gemini.google.com/?hl=es-ES 
* **Crear los diagramas:** Draw.io 
* **Aclarar dudas sobre C#:** https://www.w3schools.com/cs/index.php 
* **Quitar fondo de imágenes:** https://www.remove.bg/es/upload
