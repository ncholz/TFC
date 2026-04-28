-- ==========================================================
-- 2. INSERCIÓN DE DATOS (DATA SEEDING)
-- ==========================================================
USE gestion_basket;

-- 1. EQUIPOS (Top 10 NBA)
INSERT INTO equipos (id, nombre, ciudad, logo_url) VALUES
(1, 'Boston Celtics', 'Boston', 'img/celtics.png'),
(2, 'Denver Nuggets', 'Denver', 'img/nuggets.png'),
(3, 'OKC Thunder', 'Oklahoma', 'img/thunder.png'),
(4, 'Minnesota Wolves', 'Minneapolis', 'img/wolves.png'),
(5, 'Dallas Mavericks', 'Dallas', 'img/mavs.png'),
(6, 'Lakers', 'Los Angeles', 'img/lakers.png'),
(7, 'Warriors', 'San Francisco', 'img/warriors.png'),
(8, 'Knicks', 'New York', 'img/knicks.png'),
(9, '76ers', 'Philadelphia', 'img/76ers.png'),
(10, 'Suns', 'Phoenix', 'img/suns.png');

-- 2. USUARIOS (1 Admin + 10 Entrenadores)
INSERT INTO usuarios (nombre_usuario, password, nombre_completo, rol, id_equipo) VALUES
('admin', 'admin', 'Comisionado', 'admin', NULL),
('mazzulla', '1234', 'Joe Mazzulla', 'entrenador', 1),
('malone', '1234', 'Michael Malone', 'entrenador', 2),
('daigneault', '1234', 'Mark Daigneault', 'entrenador', 3),
('finch', '1234', 'Chris Finch', 'entrenador', 4),
('kidd', '1234', 'Jason Kidd', 'entrenador', 5),
('redick', '1234', 'JJ Redick', 'entrenador', 6),
('kerr', '1234', 'Steve Kerr', 'entrenador', 7),
('thibodeau', '1234', 'Tom Thibodeau', 'entrenador', 8),
('nurse', '1234', 'Nick Nurse', 'entrenador', 9),
('budenholzer', '1234', 'Mike Budenholzer', 'entrenador', 10);

-- 3. ENTRENAMIENTOS (Catálogo de Ejemplo)
INSERT INTO entrenamientos (nombre, tipo, descripcion) VALUES
('Mecánica de Tiro', 'MEJORA_TRIPLES', 'Series de 50 tiros estáticos.'),
('Slalom Conos', 'CONTROL_BALON', 'Bote bajo y cambios de mano.'),
('Cierre Rebote', 'MEJORA_REBOTE', 'Trabajo físico de box-out.'),
('Defensa 1v1', 'MEJORA_DEFENSA', 'Desplazamientos laterales.');

-- 4. JUGADORES (Selección de Estrellas y Rotación)
-- LAKERS (ID 6)
INSERT INTO jugadores (nombre, posicion, altura_cm, dorsal, id_equipo) VALUES
('LeBron James', 'Alero', 206, 23, 6), ('Anthony Davis', 'Pivot', 208, 3, 6), 
('Austin Reaves', 'Escolta', 196, 15, 6), ('D''Angelo Russell', 'Base', 193, 1, 6), 
('Rui Hachimura', 'AP', 203, 28, 6);

-- WARRIORS (ID 7)
INSERT INTO jugadores (nombre, posicion, altura_cm, dorsal, id_equipo) VALUES
('Stephen Curry', 'Base', 188, 30, 7), ('Draymond Green', 'AP', 198, 23, 7), 
('Andrew Wiggins', 'Alero', 201, 22, 7), ('Jonathan Kuminga', 'AP', 201, 0, 7), 
('Buddy Hield', 'Escolta', 193, 7, 7);

-- CELTICS (ID 1)
INSERT INTO jugadores (nombre, posicion, altura_cm, dorsal, id_equipo) VALUES
('Jayson Tatum', 'Alero', 203, 0, 1), ('Jaylen Brown', 'Escolta', 198, 7, 1),
('Kristaps Porzingis', 'Pivot', 218, 8, 1), ('Jrue Holiday', 'Base', 193, 4, 1),
('Derrick White', 'Base', 193, 9, 1);

-- NUGGETS (ID 2)
INSERT INTO jugadores (nombre, posicion, altura_cm, dorsal, id_equipo) VALUES
('Nikola Jokic', 'Pivot', 211, 15, 2), ('Jamal Murray', 'Base', 193, 27, 2),
('Michael Porter Jr.', 'Alero', 208, 1, 2), ('Aaron Gordon', 'AP', 203, 50, 2);

-- MAVERICKS (ID 5)
INSERT INTO jugadores (nombre, posicion, altura_cm, dorsal, id_equipo) VALUES
('Luka Doncic', 'Base', 201, 77, 5), ('Kyrie Irving', 'Base', 188, 11, 5),
('Klay Thompson', 'Escolta', 198, 31, 5), ('Dereck Lively II', 'Pivot', 216, 2, 5);

-- 5. STATS HISTÓRICAS (Reales 23/24)
INSERT INTO stats_historicas (id_jugador, temporada, puntos_media, rebotes_media, asistencias_media, porcentaje_t3)
SELECT id, '23/24', 25.7, 7.3, 8.3, 41.0 FROM jugadores WHERE nombre = 'LeBron James';
INSERT INTO stats_historicas (id_jugador, temporada, puntos_media, rebotes_media, asistencias_media, porcentaje_t3)
SELECT id, '23/24', 26.4, 4.5, 5.1, 40.8 FROM jugadores WHERE nombre = 'Stephen Curry';
INSERT INTO stats_historicas (id_jugador, temporada, puntos_media, rebotes_media, asistencias_media, porcentaje_t3)
SELECT id, '23/24', 33.9, 9.2, 9.8, 38.2 FROM jugadores WHERE nombre = 'Luka Doncic';
INSERT INTO stats_historicas (id_jugador, temporada, puntos_media, rebotes_media, asistencias_media, porcentaje_t3)
SELECT id, '23/24', 26.9, 8.1, 4.9, 37.6 FROM jugadores WHERE nombre = 'Jayson Tatum';
INSERT INTO stats_historicas (id_jugador, temporada, puntos_media, rebotes_media, asistencias_media, porcentaje_t3)
SELECT id, '23/24', 26.4, 12.4, 9.0, 35.9 FROM jugadores WHERE nombre = 'Nikola Jokic';

-- 6. PARTIDOS (Simulación Jornada 1)
INSERT INTO partidos (jornada, fecha, id_local, id_visitante, puntos_local, puntos_visitante, jugado) VALUES
(1, '2024-10-22', 6, 4, 110, 103, 1), -- Lakers vs Wolves (Ganó Lakers)
(1, '2024-10-23', 7, 5, 120, 118, 1); -- Warriors vs Mavs (Ganó Warriors)

-- 7. STATS PARTIDO (Caso de prueba para Entrenamientos)
-- LeBron (Bien) vs D'Angelo Russell (Mal)
INSERT INTO stats_partidos (fecha, id_jugador, id_partido, minutos, puntos, t2_metidos, t2_intentados, t3_metidos, t3_intentados, tl_metidos, tl_intentados, perdidas, valoracion) VALUES
('2024-10-22', (SELECT id FROM jugadores WHERE nombre='LeBron James'), 1, 35, 25, 8, 12, 2, 4, 3, 4, 2, 30),
('2024-10-22', (SELECT id FROM jugadores WHERE nombre='D''Angelo Russell'), 1, 28, 6, 2, 5, 0, 7, 2, 2, 4, 2);