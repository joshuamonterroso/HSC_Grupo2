-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 27-09-2021 a las 00:36:56
-- Versión del servidor: 8.0.26
-- Versión de PHP: 7.4.22

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

create database prototipo_area_compras;
use prototipo_area_compras;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `factura_header`
--

CREATE TABLE `factura_header` (
  `id_factura_header` int NOT NULL,
  `id_proveedor` int DEFAULT NULL,
  `total` float DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `linea`
--

CREATE TABLE `linea` (
  `id_linea` int NOT NULL,
  `nombre` varchar(100) DEFAULT NULL,
  `descripcion` varchar(500) DEFAULT NULL,
  `id_marca` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `linea`
--

INSERT INTO `linea` (`id_linea`, `nombre`, `descripcion`, `id_marca`) VALUES
(1, '1', '1', 1),
(2, '1', '1', 1),
(3, '1', '1', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `marca`
--

CREATE TABLE `marca` (
  `id_marca` int NOT NULL,
  `nombre` varchar(100) DEFAULT NULL,
  `descripcion` varchar(500) DEFAULT NULL,
  `id_proveedor` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `marca`
--

INSERT INTO `marca` (`id_marca`, `nombre`, `descripcion`, `id_proveedor`) VALUES
(1, '1', '1', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `proveedores`
--

CREATE TABLE `proveedores` (
  `id_proveedor` int NOT NULL,
  `nombre` varchar(100) DEFAULT NULL,
  `direccion` varchar(500) DEFAULT NULL,
  `telefono` int DEFAULT NULL,
  `email` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `proveedores`
--

INSERT INTO `proveedores` (`id_proveedor`, `nombre`, `direccion`, `telefono`, `email`) VALUES
(1, 'prueba', 'prueba', 12345678, 'prueba');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `registro_compra`
--

CREATE TABLE `registro_compra` (
  `id_registro` int NOT NULL,
  `id_factura_header` int DEFAULT NULL,
  `Monto` float DEFAULT NULL,
  `fecha` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `registro_consultas`
--

CREATE TABLE `registro_consultas` (
  `id_registro` int NOT NULL,
  `nombre` varchar(200) DEFAULT NULL,
  `consulta` varchar(500) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `registro_consultas`
--

INSERT INTO `registro_consultas` (`id_registro`, `nombre`, `consulta`) VALUES
(3, 'consulta1', 'SELECT  * FROM linea  WHERE id_linea=\"1\"  OR id_linea=\"2\" OR id_linea=\"3\"  order by id_linea desc;'),
(4, 'consulta2', 'SELECT id_factura_header as fh FROM factura_header ;'),
(5, 'aniversario', 'SELECT nombre as nonono FROM proveedores ;'),
(8, 'todosprov', 'SELECT  * FROM proveedores ;'),
(10, 'nuevoprov', 'SELECT  * FROM proveedores '),
(11, 'Demostracion', 'SELECT  * FROM linea    ;'),
(12, 'Todos los campos', 'SELECT  * FROM proveedores '),
(13, 'simple', 'SELECT nombre FROM marca '),
(14, 'pruebasimple', 'SELECT nombre FROM linea     ;'),
(18, 'ejemplox', 'SELECT  * FROM linea  WHERE id_linea=\"1\"    ;'),
(19, 'pruebabiggs', 'SELECT  * FROM linea  WHERE id_linea=\"1\"    ;'),
(20, 'and', 'SELECT  * FROM linea  WHERE id_linea=\"1\"  AND nombre=\"1\"   ;'),
(21, 'orord', 'SELECT  * FROM linea  WHERE id_linea=\"1\"  OR id_linea=\"2\"  order by id_linea desc ;'),
(22, 'error', 'SELECT  * FROM linea  WHERE nombre=\"1\"  AND id_linea=\"1\"  group by id_linea ;'),
(28, 'prueba', 'SELECT  * FROM registro_consultas  WHERE id_registro=\"1\"    ;'),
(29, 'Pruebadef', 'SELECT  * FROM linea  WHERE id_linea=\"1\"  OR id_linea=\"2\"  order by id_linea desc ;'),
(30, 'pruebadef2', 'SELECT  * FROM linea  WHERE id_linea=\"1\"  OR id_linea=\"2\" OR id_linea=\"3\"  order by id_linea desc ;'),
(31, 'pruebadef3', 'SELECT  * FROM linea  WHERE id_linea=\"1\"  OR id_linea=\"2\"  order by id_linea asc ;'),
(36, 'esteban', 'SELECT id_linea as linea , nombre as esteban FROM linea  WHERE id_linea=\"1\"  OR id_linea=\"2\"  order by id_linea asc;'),
(37, 'ejemplo36', 'SELECT  * FROM linea    ;'),
(38, 'pruebafinal', 'SELECT  * FROM linea  WHERE id_linea=\"1\"  OR id_linea=\"2\"  group by id_linea;');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `factura_header`
--
ALTER TABLE `factura_header`
  ADD PRIMARY KEY (`id_factura_header`),
  ADD KEY `id_proveedor` (`id_proveedor`);

--
-- Indices de la tabla `linea`
--
ALTER TABLE `linea`
  ADD PRIMARY KEY (`id_linea`),
  ADD KEY `fklineamarca` (`id_marca`);

--
-- Indices de la tabla `marca`
--
ALTER TABLE `marca`
  ADD PRIMARY KEY (`id_marca`),
  ADD KEY `fkmarcaproveedor` (`id_proveedor`);

--
-- Indices de la tabla `proveedores`
--
ALTER TABLE `proveedores`
  ADD PRIMARY KEY (`id_proveedor`);

--
-- Indices de la tabla `registro_compra`
--
ALTER TABLE `registro_compra`
  ADD PRIMARY KEY (`id_registro`),
  ADD KEY `id_factura_header` (`id_factura_header`);

--
-- Indices de la tabla `registro_consultas`
--
ALTER TABLE `registro_consultas`
  ADD PRIMARY KEY (`id_registro`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `factura_header`
--
ALTER TABLE `factura_header`
  MODIFY `id_factura_header` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `linea`
--
ALTER TABLE `linea`
  MODIFY `id_linea` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `marca`
--
ALTER TABLE `marca`
  MODIFY `id_marca` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `proveedores`
--
ALTER TABLE `proveedores`
  MODIFY `id_proveedor` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `registro_compra`
--
ALTER TABLE `registro_compra`
  MODIFY `id_registro` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de la tabla `registro_consultas`
--
ALTER TABLE `registro_consultas`
  MODIFY `id_registro` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=39;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `factura_header`
--
ALTER TABLE `factura_header`
  ADD CONSTRAINT `factura_header_ibfk_1` FOREIGN KEY (`id_proveedor`) REFERENCES `proveedores` (`id_proveedor`);

--
-- Filtros para la tabla `linea`
--
ALTER TABLE `linea`
  ADD CONSTRAINT `linea_ibfk_1` FOREIGN KEY (`id_marca`) REFERENCES `marca` (`id_marca`);

--
-- Filtros para la tabla `marca`
--
ALTER TABLE `marca`
  ADD CONSTRAINT `marca_ibfk_1` FOREIGN KEY (`id_proveedor`) REFERENCES `proveedores` (`id_proveedor`);

--
-- Filtros para la tabla `registro_compra`
--
ALTER TABLE `registro_compra`
  ADD CONSTRAINT `registro_compra_ibfk_1` FOREIGN KEY (`id_factura_header`) REFERENCES `factura_header` (`id_factura_header`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
