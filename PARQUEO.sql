﻿
USE [master]
GO
/****** Object:  Database [PARQUEO]    Script Date: 27/02/2025 08:23:39 p. m. ******/
CREATE DATABASE [PARQUEO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PARQUEO', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PARQUEO.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PARQUEO_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\PARQUEO_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PARQUEO] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PARQUEO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PARQUEO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PARQUEO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PARQUEO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PARQUEO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PARQUEO] SET ARITHABORT OFF 
GO
ALTER DATABASE [PARQUEO] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [PARQUEO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PARQUEO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PARQUEO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PARQUEO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PARQUEO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PARQUEO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PARQUEO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PARQUEO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PARQUEO] SET  ENABLE_BROKER 
GO
ALTER DATABASE [PARQUEO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PARQUEO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PARQUEO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PARQUEO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PARQUEO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PARQUEO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PARQUEO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PARQUEO] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PARQUEO] SET  MULTI_USER 
GO
ALTER DATABASE [PARQUEO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PARQUEO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PARQUEO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PARQUEO] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PARQUEO] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PARQUEO] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PARQUEO] SET QUERY_STORE = ON
GO
ALTER DATABASE [PARQUEO] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PARQUEO]
GO
/****** Object:  Table [dbo].[espacio]    Script Date: 27/02/2025 08:23:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[espacio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ubicacion] [varchar](50) NOT NULL,
	[cph] [int] NOT NULL,
	[estado] [varchar](20) NOT NULL,
	[idsucursal] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[reserva]    Script Date: 27/02/2025 08:23:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reserva](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idespacio] [int] NOT NULL,
	[idsucursal] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[hora] [varchar](10) NOT NULL,
	[cantidad_de_horas] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sucursal]    Script Date: 27/02/2025 08:23:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sucursal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[direccion] [text] NOT NULL,
	[telefono] [varchar](8) NULL,
	[administrador] [varchar](100) NOT NULL,
	[nespacios] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 27/02/2025 08:23:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[correo] [varchar](100) NOT NULL,
	[telefono] [varchar](15) NULL,
	[contrasena] [varchar](255) NOT NULL,
	[rol] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[correo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[espacio]  WITH CHECK ADD FOREIGN KEY([idsucursal])
REFERENCES [dbo].[sucursal] ([id])
GO
ALTER TABLE [dbo].[espacio]  WITH CHECK ADD FOREIGN KEY([idsucursal])
REFERENCES [dbo].[sucursal] ([id])
GO
ALTER TABLE [dbo].[reserva]  WITH CHECK ADD FOREIGN KEY([idespacio])
REFERENCES [dbo].[espacio] ([id])
GO
ALTER TABLE [dbo].[reserva]  WITH CHECK ADD FOREIGN KEY([idsucursal])
REFERENCES [dbo].[sucursal] ([id])
GO
USE [master]
GO
ALTER DATABASE [PARQUEO] SET  READ_WRITE 
GO

use PARQUEO

INSERT INTO usuario (nombre, correo, telefono, contrasena, rol) VALUES
('Carlos Perez', 'carlos.perez@gmail.com', '78945612', 'clave123', 'Administrador'),
('Ana Lopez', 'ana.lopez@hotmail.com', '72568914', 'segura2024', 'Usuario'),
('Jorge Martinez', 'jorge.martinez@yahoo.com', '75641235', 'contrasenaXYZ', 'Usuario'),
('Sofia Ramirez', 'sofia.ramirez@outlook.com', '70123456', 'pass2025', 'Administrador');


INSERT INTO sucursal (nombre, direccion, telefono, administrador, nespacios) VALUES
('Parqueo San Salvador', 'Blvd. del Hipodromo, San Salvador', '22223344', 'Carlos Perez', 50),
('Parqueo Santa Ana', 'Avenida Independencia, Santa Ana', '24446655', 'Ana Lopez', 35),
('Parqueo San Miguel', '6a Calle Poniente, San Miguel', '26667788', 'Jorge Martinez', 40);


INSERT INTO espacio (ubicacion, cph, estado, idsucursal) VALUES
('A1', 2, 'Disponible', 1),
('A2', 2, 'Ocupado', 1),
('B1', 2, 'Disponible', 2),
('B2', 2, 'Ocupado', 2),
('C1', 3, 'Disponible', 3),
('C2', 3, 'Ocupado', 3);


-- 3. Insertar los datos con los nuevos campos
INSERT INTO reserva (idespacio, idsucursal, fecha, hora, cantidad_de_horas) VALUES
(1, 1, '2025-02-28', '8 pm', 2),
(3, 2, '2025-02-28', '10:30 am', 3),
(5, 3, '2025-02-28', '3:45 pm', 1);
GO
