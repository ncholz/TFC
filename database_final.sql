-- ==========================================================
-- 1. ESTRUCTURA DE LA BASE DE DATOS (SCHEMA)
-- ==========================================================

DROP DATABASE IF EXISTS gestion_basket;
CREATE DATABASE gestion_basket;
USE gestion_basket;

-- TABLA EQUIPOS
CREATE TABLE equipos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    ciudad VARCHAR(50),
    logo_url VARCHAR(255)
);

-- TABLA USUARIOS (Login)
CREATE TABLE usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre_usuario VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    nombre_completo VARCHAR(100),
    rol VARCHAR(20) DEFAULT 'entrenador', -- 'admin' o 'entrenador'
    id_equipo INT,                        -- NULL si es Admin
    FOREIGN KEY (id_equipo) REFERENCES equipos(id)
);

-- TABLA JUGADORES
CREATE TABLE jugadores (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    posicion VARCHAR(20),
    altura_cm INT,
    dorsal INT,
    id_equipo INT,
    foto_url VARCHAR(255),
    FOREIGN KEY (id_equipo) REFERENCES equipos(id)
);

-- TABLA PARTIDOS (Calendario y Resultados)
CREATE TABLE partidos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    jornada INT,
    fecha DATE,
    id_local INT,
    id_visitante INT,
    puntos_local INT DEFAULT 0,
    puntos_visitante INT DEFAULT 0,
    jugado BOOLEAN DEFAULT 0, -- 0 = Pendiente, 1 = Finalizado
    FOREIGN KEY (id_local) REFERENCES equipos(id),
    FOREIGN KEY (id_visitante) REFERENCES equipos(id)
);

-- TABLA STATS_PARTIDOS (Detalle separado Metidos/Intentados)
CREATE TABLE stats_partidos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    fecha DATE NOT NULL,
    id_jugador INT NOT NULL,
    id_partido INT,
    minutos INT,
    puntos INT,
    
    -- Tiros (Clave para tu algoritmo de entrenos)
    t2_metidos INT DEFAULT 0, t2_intentados INT DEFAULT 0,
    t3_metidos INT DEFAULT 0, t3_intentados INT DEFAULT 0,
    tl_metidos INT DEFAULT 0, tl_intentados INT DEFAULT 0,
    
    -- Defensa y Control
    reb_ofensivos INT DEFAULT 0, reb_defensivos INT DEFAULT 0,
    asistencias INT DEFAULT 0, robos INT DEFAULT 0,
    tapones INT DEFAULT 0, perdidas INT DEFAULT 0,
    faltas INT DEFAULT 0, valoracion INT DEFAULT 0,
    
    FOREIGN KEY (id_jugador) REFERENCES jugadores(id),
    FOREIGN KEY (id_partido) REFERENCES partidos(id)
);

-- TABLA STATS_HISTORICAS (Comparativa año anterior)
CREATE TABLE stats_historicas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    id_jugador INT,
    temporada VARCHAR(10),
    puntos_media DECIMAL(4,1),
    rebotes_media DECIMAL(4,1),
    asistencias_media DECIMAL(4,1),
    porcentaje_t3 DECIMAL(4,1),
    FOREIGN KEY (id_jugador) REFERENCES jugadores(id)
);

-- TABLA ENTRENAMIENTOS (Catálogo con Etiquetas)
CREATE TABLE entrenamientos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100),
    tipo VARCHAR(50), -- Etiqueta para el algoritmo (ej: MEJORA_TRIPLES)
    descripcion TEXT
);

-- VISTA CLASIFICACIÓN (Cálculo automático)
CREATE VIEW vista_clasificacion AS
SELECT 
    e.nombre AS Equipo,
    COUNT(p.id) AS PJ,
    SUM(CASE 
        WHEN p.id_local = e.id AND p.puntos_local > p.puntos_visitante THEN 1
        WHEN p.id_visitante = e.id AND p.puntos_visitante > p.puntos_local THEN 1
        ELSE 0 END) AS Victorias,
    SUM(CASE 
        WHEN p.id_local = e.id AND p.puntos_local < p.puntos_visitante THEN 1
        WHEN p.id_visitante = e.id AND p.puntos_visitante < p.puntos_local THEN 1
        ELSE 0 END) AS Derrotas,
    SUM(CASE 
        WHEN p.id_local = e.id THEN p.puntos_local - p.puntos_visitante
        WHEN p.id_visitante = e.id THEN p.puntos_visitante - p.puntos_local
        ELSE 0 END) AS Diferencia_Puntos
FROM equipos e
JOIN partidos p ON (e.id = p.id_local OR e.id = p.id_visitante)
WHERE p.jugado = 1
GROUP BY e.id, e.nombre
ORDER BY Victorias DESC, Diferencia_Puntos DESC;