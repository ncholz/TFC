-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 13-04-2026 a las 16:30:00
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12
SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";
/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
--
-- Base de datos: `gestion_basket`
--

-- --------------------------------------------------------
--
-- Estructura de tabla para la tabla `entrenamientos`
--
CREATE TABLE `entrenamientos` (
  `id` int(11) NOT NULL,
  `nombre` varchar(100) DEFAULT NULL,
  `tipo` varchar(50) DEFAULT NULL,
  `descripcion` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `entrenamientos`
--
INSERT INTO `entrenamientos` (`id`, `nombre`, `tipo`, `descripcion`) VALUES
(1, 'Shooting Spree', 'MEJORA_TRIPLES', 'Lanzamiento de 3 puntos en movimiento tras bloqueo.'),
(2, 'Post Moves', 'MEJORA_POSTE', 'Movimientos de pies en la pintura para pivots.'),
(3, 'Pick & Roll Defense', 'TACTICA_DEFENSA', 'Defensa del bloqueo directo (Switch, Drop, Hedge).'),
(4, 'Free Throw Pressure', 'MEJORA_TIRO', 'Tiros libres con ruido simulado y fatiga.'),
(5, 'Fast Break Drills', 'TRANSICION', 'Ejercicios de contraataque 3vs2 y 2vs1.');

-- --------------------------------------------------------
--
-- Estructura de tabla para la tabla `equipos`
--
CREATE TABLE `equipos` (
  `id` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `ciudad` varchar(50) DEFAULT NULL,
  `logo_url` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `equipos`
--
INSERT INTO `equipos` (`id`, `nombre`, `ciudad`, `logo_url`) VALUES
(1, 'Los Angeles Lakers', 'Los Angeles', 'lakers_logo.png'),
(2, 'Golden State Warriors', 'San Francisco', 'warriors_logo.png'),
(3, 'Boston Celtics', 'Boston', 'celtics_logo.png'),
(4, 'Milwaukee Bucks', 'Milwaukee', 'bucks_logo.png'),
(5, 'Denver Nuggets', 'Denver', 'nuggets_logo.png'),
(6, 'Miami Heat', 'Miami', 'heat_logo.png'),
(7, 'Dallas Mavericks', 'Dallas', 'mavs_logo.png'),
(8, 'Phoenix Suns', 'Phoenix', 'suns_logo.png');

-- --------------------------------------------------------
--
-- Estructura de tabla para la tabla `jugadores`
--
CREATE TABLE `jugadores` (
  `id` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `posicion` varchar(20) DEFAULT NULL,
  `altura_cm` int(11) DEFAULT NULL,
  `dorsal` int(11) DEFAULT NULL,
  `id_equipo` int(11) DEFAULT NULL,
  `activo` BOOLEAN NOT NULL DEFAULT TRUE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `jugadores` (8 jugadores por equipo - Temporada 2026-27)
--
INSERT INTO `jugadores` (`id`, `nombre`, `posicion`, `altura_cm`, `dorsal`, `id_equipo`, `activo`) VALUES
(1, 'Luka Dončić', 'Base', 201, 77, 1, TRUE),
(2, 'LeBron James', 'Alero', 206, 23, 1, TRUE),
(3, 'Austin Reaves', 'Escolta', 196, 15, 1, TRUE),
(4, 'Rui Hachimura', 'Ala-Pivot', 203, 28, 1, TRUE),
(5, 'Deandre Ayton', 'Pivot', 211, 5, 1, TRUE),
(6, 'Jaxson Hayes', 'Pivot', 213, 11, 1, TRUE),
(7, 'Max Christie', 'Escolta', 196, 0, 1, TRUE),
(8, 'Cam Reddish', 'Alero', 201, 5, 1, TRUE),
(9, 'Stephen Curry', 'Base', 188, 30, 2, TRUE),
(10, 'Jimmy Butler', 'Alero', 201, 10, 2, TRUE),
(11, 'Draymond Green', 'Ala-Pivot', 198, 23, 2, TRUE),
(12, 'Brandin Podziemski', 'Escolta', 193, 2, 2, TRUE),
(13, 'Gary Payton II', 'Escolta', 188, 0, 2, TRUE),
(14, 'Moses Moody', 'Escolta', 193, 4, 2, TRUE),
(15, 'Andrew Wiggins', 'Alero', 201, 22, 2, TRUE),
(16, 'Kevon Looney', 'Pivot', 206, 5, 2, TRUE),
(17, 'Jayson Tatum', 'Alero', 203, 0, 3, TRUE),
(18, 'Jaylen Brown', 'Escolta', 198, 7, 3, TRUE),
(19, 'Derrick White', 'Base', 193, 9, 3, TRUE),
(20, 'Payton Pritchard', 'Base', 185, 11, 3, TRUE),
(21, 'Sam Hauser', 'Alero', 201, 30, 3, TRUE),
(22, 'Nikola Vučević', 'Pivot', 208, 9, 3, TRUE),
(23, 'Jrue Holiday', 'Base', 191, 4, 3, TRUE),
(24, 'Al Horford', 'Pivot', 206, 42, 3, TRUE),
(25, 'Giannis Antetokounmpo', 'Ala-Pivot', 211, 34, 4, TRUE),
(26, 'Myles Turner', 'Pivot', 211, 33, 4, TRUE),
(27, 'Bobby Portis', 'Ala-Pivot', 208, 9, 4, TRUE),
(28, 'A.J. Green', 'Escolta', 193, 20, 4, TRUE),
(29, 'Thanasis Antetokounmpo', 'Alero', 201, 43, 4, TRUE),
(30, 'Ryan Rollins', 'Base', 188, 13, 4, TRUE),
(31, 'Khris Middleton', 'Alero', 201, 22, 4, TRUE),
(32, 'Brook Lopez', 'Pivot', 216, 11, 4, TRUE),
(33, 'Nikola Jokić', 'Pivot', 211, 15, 5, TRUE),
(34, 'Jamal Murray', 'Base', 193, 27, 5, TRUE),
(35, 'Aaron Gordon', 'Ala-Pivot', 203, 50, 5, TRUE),
(36, 'Christian Braun', 'Escolta', 198, 0, 5, TRUE),
(37, 'Bruce Brown', 'Base', 193, 11, 5, TRUE),
(38, 'Tim Hardaway Jr.', 'Escolta', 196, 10, 5, TRUE),
(39, 'Peyton Watson', 'Alero', 203, 8, 5, TRUE),
(40, 'Russell Westbrook', 'Base', 191, 4, 5, TRUE),
(41, 'Bam Adebayo', 'Pivot', 206, 13, 6, TRUE),
(42, 'Tyler Herro', 'Escolta', 196, 14, 6, TRUE),
(43, 'Andrew Wiggins', 'Alero', 201, 22, 6, TRUE),
(44, 'Terry Rozier', 'Base', 185, 2, 6, TRUE),
(45, 'Jaime Jaquez Jr.', 'Alero', 198, 11, 6, TRUE),
(46, 'Simone Fontecchio', 'Alero', 201, 0, 6, TRUE),
(47, 'Duncan Robinson', 'Alero', 201, 55, 6, TRUE),
(48, 'Kevin Love', 'Ala-Pivot', 203, 42, 6, TRUE),
(49, 'Kyrie Irving', 'Escolta', 188, 11, 7, TRUE),
(50, 'Cooper Flagg', 'Alero', 206, 32, 7, TRUE),
(51, 'Max Christie', 'Escolta', 196, 0, 7, TRUE),
(52, 'Naji Marshall', 'Alero', 201, 13, 7, TRUE),
(53, 'P.J. Washington', 'Ala-Pivot', 201, 25, 7, TRUE),
(54, 'Dereck Lively II', 'Pivot', 216, 2, 7, TRUE),
(55, 'Daniel Gafford', 'Pivot', 208, 21, 7, TRUE),
(56, 'Klay Thompson', 'Escolta', 198, 31, 7, TRUE),
(57, 'Devin Booker', 'Escolta', 196, 1, 8, TRUE),
(58, 'Grayson Allen', 'Escolta', 193, 8, 8, TRUE),
(59, 'Dillon Brooks', 'Alero', 198, 3, 8, TRUE),
(60, 'Royce O\'Neale', 'Alero', 193, 0, 8, TRUE),
(61, 'Oso Ighodaro', 'Ala-Pivot', 211, 11, 8, TRUE),
(62, 'Collin Gillespie', 'Base', 185, 12, 8, TRUE),
(63, 'Bradley Beal', 'Escolta', 193, 3, 8, TRUE),
(64, 'Jusuf Nurkic', 'Pivot', 213, 20, 8, TRUE);

-- --------------------------------------------------------
--
-- Estructura de tabla para la tabla `partidos`
--
CREATE TABLE `partidos` (
  `id` int(11) NOT NULL,
  `jornada` int(11) DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `id_local` int(11) DEFAULT NULL,
  `id_visitante` int(11) DEFAULT NULL,
  `puntos_local` int(11) DEFAULT 0,
  `puntos_visitante` int(11) DEFAULT 0,
  `jugado` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `partidos`
--
INSERT INTO `partidos` (`id`, `jornada`, `fecha`, `id_local`, `id_visitante`, `puntos_local`, `puntos_visitante`, `jugado`) VALUES
(1, 1, '2023-10-24', 5, 1, 119, 107, 1),
(2, 1, '2023-10-24', 2, 8, 104, 108, 1),
(3, 1, '2023-10-25', 3, 6, 110, 106, 1),
(4, 1, '2023-10-25', 4, 7, 120, 118, 1),
(5, 2, '2023-12-25', 1, 3, 115, 126, 1),
(6, 2, '2023-12-25', 5, 2, 120, 114, 1),
(7, 2, '2023-12-25', 8, 7, 114, 128, 1),
(8, 2, '2023-12-25', 6, 4, 102, 110, 1),
(9, 3, '2024-01-01', 1, 2, 121, 118, 1),
(10, 3, '2024-01-01', 3, 4, 115, 119, 1),
(11, 3, '2024-01-01', 7, 5, 125, 120, 1),
(12, 3, '2024-01-01', 6, 8, 108, 112, 1);

-- --------------------------------------------------------
--
-- Estructura de tabla para la tabla `stats_historicas`
--
CREATE TABLE `stats_historicas` (
  `id` int(11) NOT NULL,
  `id_jugador` int(11) DEFAULT NULL,
  `temporada` varchar(10) DEFAULT NULL,
  `puntos_media` decimal(4,1) DEFAULT NULL,
  `rebotes_media` decimal(4,1) DEFAULT NULL,
  `asistencias_media` decimal(4,1) DEFAULT NULL,
  `porcentaje_t3` decimal(4,1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `stats_historicas`
--
INSERT INTO `stats_historicas` (`id`, `id_jugador`, `temporada`, `puntos_media`, `rebotes_media`, `asistencias_media`, `porcentaje_t3`) VALUES
(1, 1, '2025-26', 33.5, 8.0, 8.5, 36.5),
(2, 2, '2025-26', 21.0, 6.5, 7.2, 34.0),
(3, 9, '2025-26', 26.6, 4.8, 5.5, 41.0),
(4, 17, '2025-26', 28.0, 8.5, 5.0, 37.0),
(5, 25, '2025-26', 30.5, 11.5, 6.0, 29.5),
(6, 33, '2025-26', 27.8, 12.9, 10.7, 38.0),
(7, 41, '2025-26', 20.5, 10.2, 4.2, 33.0),
(8, 49, '2025-26', 24.5, 5.8, 6.8, 39.0),
(9, 57, '2025-26', 26.0, 4.5, 6.5, 42.0);

-- --------------------------------------------------------
--
-- Estructura de tabla para la tabla `stats_partidos`
--
CREATE TABLE `stats_partidos` (
  `id` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `id_jugador` int(11) NOT NULL,
  `id_partido` int(11) DEFAULT NULL,
  `minutos` int(11) DEFAULT NULL,
  `puntos` int(11) DEFAULT NULL,
  `t2_metidos` int(11) DEFAULT 0,
  `t2_intentados` int(11) DEFAULT 0,
  `t3_metidos` int(11) DEFAULT 0,
  `t3_intentados` int(11) DEFAULT 0,
  `tl_metidos` int(11) DEFAULT 0,
  `tl_intentados` int(11) DEFAULT 0,
  `reb_ofensivos` int(11) DEFAULT 0,
  `reb_defensivos` int(11) DEFAULT 0,
  `asistencias` int(11) DEFAULT 0,
  `robos` int(11) DEFAULT 0,
  `tapones` int(11) DEFAULT 0,
  `perdidas` int(11) DEFAULT 0,
  `faltas` int(11) DEFAULT 0,
  `valoracion` int(11) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `stats_partidos`
--
INSERT INTO `stats_partidos` (`id`, `fecha`, `id_jugador`, `id_partido`, `minutos`, `puntos`, `t2_metidos`, `t2_intentados`, `t3_metidos`, `t3_intentados`, `tl_metidos`, `tl_intentados`, `reb_ofensivos`, `reb_defensivos`, `asistencias`, `robos`, `tapones`, `perdidas`, `faltas`, `valoracion`) VALUES
(1, '2023-10-24', 33, 1, 36, 31, 10, 15, 2, 4, 5, 6, 4, 13, 12, 1, 2, 2, 3, 45),
(2, '2023-10-24', 34, 1, 34, 24, 7, 12, 3, 6, 1, 2, 1, 6, 8, 2, 0, 3, 2, 28),
(3, '2023-10-24', 35, 1, 32, 19, 6, 10, 1, 3, 4, 5, 3, 7, 4, 1, 1, 1, 3, 26),
(4, '2023-10-24', 36, 1, 28, 16, 5, 8, 2, 4, 0, 0, 2, 5, 3, 1, 1, 2, 2, 21),
(5, '2023-10-24', 1, 1, 37, 29, 9, 14, 3, 7, 2, 3, 1, 8, 9, 2, 0, 4, 3, 34),
(6, '2023-10-24', 2, 1, 35, 24, 8, 13, 2, 5, 2, 3, 2, 6, 7, 1, 1, 3, 2, 29),
(7, '2023-10-24', 3, 1, 30, 18, 5, 9, 2, 5, 2, 2, 0, 4, 4, 1, 0, 2, 3, 20),
(8, '2023-10-24', 4, 1, 26, 16, 6, 10, 1, 3, 1, 2, 1, 5, 2, 0, 1, 1, 2, 18),
(9, '2023-10-24', 9, 2, 35, 26, 5, 9, 5, 11, 1, 1, 0, 4, 6, 2, 0, 3, 2, 27),
(10, '2023-10-24', 10, 2, 33, 21, 7, 12, 1, 4, 4, 5, 2, 5, 5, 1, 0, 2, 3, 25),
(11, '2023-10-24', 11, 2, 30, 15, 5, 9, 1, 3, 2, 2, 3, 6, 5, 2, 1, 2, 4, 22),
(12, '2023-10-24', 57, 2, 36, 28, 8, 14, 3, 7, 3, 3, 1, 5, 4, 1, 0, 3, 2, 30),
(13, '2023-10-24', 58, 2, 32, 19, 5, 9, 3, 6, 0, 0, 0, 3, 3, 1, 0, 1, 2, 20),
(14, '2023-10-24', 59, 2, 28, 14, 4, 8, 2, 5, 0, 0, 1, 4, 2, 1, 0, 2, 3, 16),
(15, '2023-10-25', 17, 3, 38, 30, 8, 13, 4, 8, 2, 2, 2, 8, 5, 2, 1, 2, 3, 36),
(16, '2023-10-25', 18, 3, 36, 25, 7, 12, 3, 7, 2, 2, 1, 6, 4, 1, 0, 3, 2, 28),
(17, '2023-10-25', 41, 3, 34, 20, 7, 12, 0, 1, 6, 7, 4, 7, 3, 1, 2, 2, 3, 27),
(18, '2023-10-25', 42, 3, 30, 18, 5, 9, 2, 5, 2, 2, 1, 4, 4, 1, 0, 2, 2, 21),
(19, '2023-10-25', 25, 4, 37, 35, 12, 18, 1, 3, 8, 10, 4, 12, 6, 2, 3, 4, 3, 47),
(20, '2023-10-25', 1, 4, 36, 30, 9, 15, 3, 7, 3, 4, 2, 8, 10, 1, 1, 3, 2, 38),
(21, '2023-10-25', 49, 4, 34, 28, 8, 13, 4, 9, 0, 0, 1, 5, 8, 2, 0, 4, 3, 32),
(22, '2023-10-25', 50, 4, 32, 25, 7, 12, 3, 6, 2, 2, 2, 6, 5, 1, 1, 2, 2, 29),
(23, '2023-12-25', 1, 5, 38, 32, 10, 16, 3, 7, 3, 4, 2, 9, 10, 1, 1, 3, 2, 40),
(24, '2023-12-25', 2, 5, 36, 26, 8, 13, 2, 5, 4, 5, 1, 7, 7, 2, 0, 2, 3, 33),
(25, '2023-12-25', 17, 5, 39, 34, 9, 14, 5, 10, 1, 1, 3, 8, 6, 1, 1, 2, 2, 41),
(26, '2023-12-25', 18, 5, 37, 27, 7, 12, 4, 8, 1, 2, 2, 6, 4, 2, 0, 3, 3, 32),
(27, '2023-12-25', 33, 6, 38, 30, 10, 15, 2, 4, 4, 5, 4, 12, 11, 2, 2, 2, 3, 44),
(28, '2023-12-25', 34, 6, 35, 25, 7, 12, 3, 6, 2, 2, 1, 6, 8, 1, 0, 3, 2, 29),
(29, '2023-12-25', 9, 6, 36, 28, 6, 10, 5, 11, 1, 1, 0, 4, 6, 2, 0, 3, 2, 29),
(30, '2023-12-25', 10, 6, 34, 22, 7, 12, 1, 4, 5, 6, 2, 5, 5, 1, 0, 2, 3, 26),
(31, '2023-12-25', 57, 7, 37, 26, 7, 13, 3, 7, 3, 3, 1, 4, 5, 1, 0, 3, 2, 27),
(32, '2023-12-25', 1, 7, 39, 35, 10, 16, 4, 9, 3, 4, 2, 7, 11, 2, 1, 4, 3, 42),
(33, '2023-12-25', 49, 7, 36, 32, 9, 14, 4, 8, 2, 2, 1, 6, 7, 3, 0, 3, 2, 38),
(34, '2023-12-25', 50, 7, 35, 28, 8, 13, 3, 7, 3, 3, 2, 5, 6, 1, 1, 2, 3, 33),
(35, '2023-12-25', 41, 8, 36, 24, 8, 14, 1, 3, 5, 6, 4, 8, 4, 1, 2, 2, 3, 30),
(36, '2023-12-25', 25, 8, 34, 31, 11, 16, 1, 3, 6, 8, 3, 10, 5, 2, 2, 3, 3, 39),
(37, '2023-12-25', 26, 8, 32, 22, 7, 11, 2, 4, 2, 2, 2, 6, 4, 1, 1, 2, 2, 27),
(38, '2024-01-01', 1, 9, 38, 33, 10, 16, 4, 8, 3, 4, 2, 9, 10, 2, 1, 3, 2, 41),
(39, '2024-01-01', 2, 9, 36, 27, 9, 14, 2, 5, 3, 4, 1, 7, 8, 1, 0, 2, 3, 34),
(40, '2024-01-01', 9, 9, 37, 30, 6, 10, 6, 12, 0, 0, 0, 5, 7, 2, 0, 4, 2, 33),
(41, '2024-01-01', 17, 10, 39, 31, 8, 13, 5, 10, 0, 0, 3, 8, 5, 1, 1, 2, 2, 38),
(42, '2024-01-01', 25, 10, 37, 34, 12, 18, 1, 3, 7, 9, 4, 11, 6, 2, 3, 4, 3, 45),
(43, '2024-01-01', 1, 11, 40, 36, 11, 17, 4, 9, 5, 6, 2, 8, 12, 2, 1, 4, 3, 44),
(44, '2024-01-01', 33, 11, 38, 32, 10, 15, 3, 5, 3, 4, 5, 11, 10, 1, 2, 3, 2, 43),
(45, '2024-01-01', 41, 12, 37, 27, 9, 15, 1, 3, 6, 7, 3, 7, 5, 2, 1, 2, 3, 33),
(46, '2024-01-01', 57, 12, 36, 29, 8, 14, 4, 8, 1, 1, 1, 5, 6, 1, 0, 3, 2, 31);

-- --------------------------------------------------------
--
-- Estructura de tabla para la tabla `usuarios`
--
CREATE TABLE `usuarios` (
  `id` int(11) NOT NULL,
  `nombre_usuario` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `nombre_completo` varchar(100) DEFAULT NULL,
  `rol` varchar(20) DEFAULT 'entrenador',
  `id_equipo` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuarios`
--
INSERT INTO `usuarios` (`id`, `nombre_usuario`, `password`, `nombre_completo`, `rol`, `id_equipo`) VALUES
(1, 'admin', 'admin123', 'Adam Silver', 'admin', NULL),
(2, 'coach_lakers', 'pass123', 'JJ Redick', 'entrenador', 1),
(3, 'coach_gsw', 'pass123', 'Steve Kerr', 'entrenador', 2),
(4, 'coach_bos', 'pass123', 'Joe Mazzulla', 'entrenador', 3),
(5, 'coach_mil', 'pass123', 'Doc Rivers', 'entrenador', 4),
(6, 'coach_den', 'pass123', 'Michael Malone', 'entrenador', 5),
(7, 'coach_mia', 'pass123', 'Erik Spoelstra', 'entrenador', 6),
(8, 'coach_dal', 'pass123', 'Jason Kidd', 'entrenador', 7),
(9, 'coach_phx', 'pass123', 'Mike Budenholzer', 'entrenador', 8);

-- --------------------------------------------------------
--
-- Vista `vista_clasificacion`
--
DROP TABLE IF EXISTS `vista_clasificacion`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vista_clasificacion` AS 
SELECT 
    `e`.`nombre` AS `Equipo`, 
    COUNT(`p`.`id`) AS `PJ`, 
    SUM(CASE WHEN `p`.`id_local` = `e`.`id` AND `p`.`puntos_local` > `p`.`puntos_visitante` THEN 1 
             WHEN `p`.`id_visitante` = `e`.`id` AND `p`.`puntos_visitante` > `p`.`puntos_local` THEN 1 ELSE 0 END) AS `Victorias`,
    SUM(CASE WHEN `p`.`id_local` = `e`.`id` AND `p`.`puntos_local` < `p`.`puntos_visitante` THEN 1 
             WHEN `p`.`id_visitante` = `e`.`id` AND `p`.`puntos_visitante` < `p`.`puntos_local` THEN 1 ELSE 0 END) AS `Derrotas`,
    SUM(CASE WHEN `p`.`id_local` = `e`.`id` THEN `p`.`puntos_local` - `p`.`puntos_visitante` 
             WHEN `p`.`id_visitante` = `e`.`id` THEN `p`.`puntos_visitante` - `p`.`puntos_local` ELSE 0 END) AS `Diferencia_Puntos`
FROM (`equipos` `e` JOIN `partidos` `p` ON (`e`.`id` = `p`.`id_local` OR `e`.`id` = `p`.`id_visitante`)) 
WHERE `p`.`jugado` = 1 
GROUP BY `e`.`id`, `e`.`nombre` 
ORDER BY `Victorias` DESC, `Diferencia_Puntos` DESC;

--
-- Índices para tablas volcadas
--
ALTER TABLE `entrenamientos` ADD PRIMARY KEY (`id`);
ALTER TABLE `equipos` ADD PRIMARY KEY (`id`);
ALTER TABLE `jugadores` ADD PRIMARY KEY (`id`), ADD KEY `id_equipo` (`id_equipo`);
ALTER TABLE `partidos` ADD PRIMARY KEY (`id`), ADD KEY `id_local` (`id_local`), ADD KEY `id_visitante` (`id_visitante`);
ALTER TABLE `stats_historicas` ADD PRIMARY KEY (`id`), ADD KEY `id_jugador` (`id_jugador`);
ALTER TABLE `stats_partidos` ADD PRIMARY KEY (`id`), ADD KEY `id_jugador` (`id_jugador`), ADD KEY `id_partido` (`id_partido`);
ALTER TABLE `usuarios` ADD PRIMARY KEY (`id`), ADD UNIQUE KEY `nombre_usuario` (`nombre_usuario`), ADD KEY `id_equipo` (`id_equipo`);

--
-- AUTO_INCREMENT de las tablas volcadas
--
ALTER TABLE `entrenamientos` MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
ALTER TABLE `equipos` MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
ALTER TABLE `jugadores` MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=65;
ALTER TABLE `partidos` MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
ALTER TABLE `stats_historicas` MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
ALTER TABLE `stats_partidos` MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=47;
ALTER TABLE `usuarios` MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Restricciones para tablas volcadas
--
ALTER TABLE `jugadores` ADD CONSTRAINT `jugadores_ibfk_1` FOREIGN KEY (`id_equipo`) REFERENCES `equipos` (`id`);
ALTER TABLE `partidos` ADD CONSTRAINT `partidos_ibfk_1` FOREIGN KEY (`id_local`) REFERENCES `equipos` (`id`);
ALTER TABLE `partidos` ADD CONSTRAINT `partidos_ibfk_2` FOREIGN KEY (`id_visitante`) REFERENCES `equipos` (`id`);
ALTER TABLE `stats_historicas` ADD CONSTRAINT `stats_historicas_ibfk_1` FOREIGN KEY (`id_jugador`) REFERENCES `jugadores` (`id`);
ALTER TABLE `stats_partidos` ADD CONSTRAINT `stats_partidos_ibfk_1` FOREIGN KEY (`id_jugador`) REFERENCES `jugadores` (`id`);
ALTER TABLE `stats_partidos` ADD CONSTRAINT `stats_partidos_ibfk_2` FOREIGN KEY (`id_partido`) REFERENCES `partidos` (`id`);
ALTER TABLE `usuarios` ADD CONSTRAINT `usuarios_ibfk_1` FOREIGN KEY (`id_equipo`) REFERENCES `equipos` (`id`);

COMMIT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;