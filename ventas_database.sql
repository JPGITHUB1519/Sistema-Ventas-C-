USE [master]
GO
/****** Object:  Database [dbventas2]    Script Date: 05/26/2016 01:43:03 ******/
CREATE DATABASE [dbventas2] ON  PRIMARY 
( NAME = N'dbventas2_mdf', FILENAME = N'C:\Archivos de programa\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\dbventas2.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'dbventas2_log', FILENAME = N'C:\Archivos de programa\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\dbventas2.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [dbventas2] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbventas2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbventas2] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [dbventas2] SET ANSI_NULLS OFF
GO
ALTER DATABASE [dbventas2] SET ANSI_PADDING OFF
GO
ALTER DATABASE [dbventas2] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [dbventas2] SET ARITHABORT OFF
GO
ALTER DATABASE [dbventas2] SET AUTO_CLOSE ON
GO
ALTER DATABASE [dbventas2] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [dbventas2] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [dbventas2] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [dbventas2] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [dbventas2] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [dbventas2] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [dbventas2] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [dbventas2] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [dbventas2] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [dbventas2] SET  ENABLE_BROKER
GO
ALTER DATABASE [dbventas2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [dbventas2] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [dbventas2] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [dbventas2] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [dbventas2] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [dbventas2] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [dbventas2] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [dbventas2] SET  READ_WRITE
GO
ALTER DATABASE [dbventas2] SET RECOVERY SIMPLE
GO
ALTER DATABASE [dbventas2] SET  MULTI_USER
GO
ALTER DATABASE [dbventas2] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [dbventas2] SET DB_CHAINING OFF
GO
USE [dbventas2]
GO
/****** Object:  Table [dbo].[trabajador]    Script Date: 05/26/2016 01:43:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[trabajador](
	[idtrabajador] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[apellidos] [varchar](40) NOT NULL,
	[sexo] [varchar](1) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[num_documento] [varchar](8) NOT NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](10) NULL,
	[email] [varchar](50) NULL,
	[acceso] [varchar](20) NOT NULL,
	[usuario] [varchar](20) NOT NULL,
	[password] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idtrabajador] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 05/26/2016 01:43:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[proveedor](
	[idproveedor] [int] IDENTITY(1,1) NOT NULL,
	[razon_social] [varchar](150) NOT NULL,
	[sector_comercial] [varchar](50) NOT NULL,
	[tipo_documento] [varchar](20) NOT NULL,
	[num_documento] [varchar](11) NOT NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[url] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idproveedor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[presentacion]    Script Date: 05/26/2016 01:43:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[presentacion](
	[idpresentacion] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[idpresentacion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 05/26/2016 01:43:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cliente](
	[idcliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[apellidos] [varchar](40) NULL,
	[sexo] [varchar](1) NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[tipo_documento] [varchar](20) NOT NULL,
	[num_documento] [varchar](8) NOT NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](10) NULL,
	[email] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[categoria]    Script Date: 05/26/2016 01:43:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[categoria](
	[idcategoria] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[idcategoria] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[articulo]    Script Date: 05/26/2016 01:43:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[articulo](
	[idarticulo] [int] IDENTITY(1,1) NOT NULL,
	[codigo] [varchar](50) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[descripcion] [varchar](1024) NULL,
	[imagen] [image] NULL,
	[idcategoria] [int] NOT NULL,
	[idpresentacion] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idarticulo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ingreso]    Script Date: 05/26/2016 01:43:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ingreso](
	[idingreso] [int] IDENTITY(1,1) NOT NULL,
	[idtrabajador] [int] NOT NULL,
	[idproveedor] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo_comprobante] [varchar](20) NOT NULL,
	[serie] [varchar](4) NOT NULL,
	[correlativo] [varchar](7) NOT NULL,
	[igv] [decimal](4, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idingreso] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[spmostrar_presentacion]    Script Date: 05/26/2016 01:43:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spmostrar_presentacion]
as
select top 200 * from presentacion
GO
/****** Object:  StoredProcedure [dbo].[spmostrar_categoria]    Script Date: 05/26/2016 01:43:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--- procedimiento Mostrar---

CREATE PROCEDURE [dbo].[spmostrar_categoria]

as

select top 200 * from categoria
order by idcategoria desc
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_presentacion]    Script Date: 05/26/2016 01:43:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spinsertar_presentacion]

@idpresentacion int output,
@nombre varchar(50),
@descripcion varchar(256)

as

insert into presentacion(nombre, descripcion) values (@nombre, @descripcion)
GO
/****** Object:  StoredProcedure [dbo].[spinsertar_categoria]    Script Date: 05/26/2016 01:43:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spinsertar_categoria]

@idcategoria int output,
@nombre varchar(50),
@descripcion varchar(256)

as

insert into categoria(nombre,descripcion) values (@nombre, @descripcion)
GO
/****** Object:  StoredProcedure [dbo].[speliminar_presentacion]    Script Date: 05/26/2016 01:43:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[speliminar_presentacion]

@idpresentacion int

as 

delete from presentacion where idpresentacion = @idpresentacion
GO
/****** Object:  StoredProcedure [dbo].[speliminar_categoria]    Script Date: 05/26/2016 01:43:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[speliminar_categoria]

@idcategoria int

as

delete from categoria where idcategoria = @idcategoria
GO
/****** Object:  StoredProcedure [dbo].[speditar_presentacion]    Script Date: 05/26/2016 01:43:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[speditar_presentacion]

@idpresentacion int,
@nombre varchar(50),
@descripcion varchar(256)

as 

update presentacion set nombre = @nombre, descripcion = @descripcion where idpresentacion = @idpresentacion;
GO
/****** Object:  StoredProcedure [dbo].[speditar_categoria]    Script Date: 05/26/2016 01:43:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[speditar_categoria]

@idcategoria int,
@nombre varchar(50),
@descripcion varchar(256)

as

update categoria set nombre = @nombre, descripcion = @descripcion where idcategoria = @idcategoria
GO
/****** Object:  StoredProcedure [dbo].[spbuscar_presentacion]    Script Date: 05/26/2016 01:43:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[spbuscar_presentacion]

@textobuscar varchar(256)

as

select * from presentacion where nombre like @textobuscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[spbuscar_categoria]    Script Date: 05/26/2016 01:43:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spbuscar_categoria]

@textobuscar varchar(50)
as

select * from categoria where nombre like @textobuscar + '%'
GO
/****** Object:  Table [dbo].[venta]    Script Date: 05/26/2016 01:43:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[venta](
	[idventa] [int] IDENTITY(1,1) NOT NULL,
	[idcliente] [int] NOT NULL,
	[idtrabajador] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[tipo_comprobante] [varchar](20) NOT NULL,
	[serie] [varchar](4) NOT NULL,
	[correlativo] [varchar](7) NOT NULL,
	[igv] [decimal](4, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idventa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[detalle_ingreso]    Script Date: 05/26/2016 01:43:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_ingreso](
	[iddetalleingreso] [int] IDENTITY(1,1) NOT NULL,
	[idingreso] [int] NOT NULL,
	[idarticulo] [int] NOT NULL,
	[precio_compra] [money] NOT NULL,
	[precio_venta] [money] NOT NULL,
	[stock_inicial] [int] NOT NULL,
	[stock_actual] [int] NOT NULL,
	[fecha_produccion] [date] NOT NULL,
	[fecha_vencimiento] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[iddetalleingreso] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalle_venta]    Script Date: 05/26/2016 01:43:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_venta](
	[iddetalleventa] [int] IDENTITY(1,1) NOT NULL,
	[idventa] [int] NOT NULL,
	[iddetalleingreso] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio_venta] [money] NULL,
	[descuento] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[iddetalleventa] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_articulo_categoria]    Script Date: 05/26/2016 01:43:06 ******/
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD  CONSTRAINT [FK_articulo_categoria] FOREIGN KEY([idcategoria])
REFERENCES [dbo].[categoria] ([idcategoria])
GO
ALTER TABLE [dbo].[articulo] CHECK CONSTRAINT [FK_articulo_categoria]
GO
/****** Object:  ForeignKey [FK_articulo_presentacion]    Script Date: 05/26/2016 01:43:06 ******/
ALTER TABLE [dbo].[articulo]  WITH CHECK ADD  CONSTRAINT [FK_articulo_presentacion] FOREIGN KEY([idpresentacion])
REFERENCES [dbo].[presentacion] ([idpresentacion])
GO
ALTER TABLE [dbo].[articulo] CHECK CONSTRAINT [FK_articulo_presentacion]
GO
/****** Object:  ForeignKey [FK_ingreso_proveedor]    Script Date: 05/26/2016 01:43:06 ******/
ALTER TABLE [dbo].[ingreso]  WITH CHECK ADD  CONSTRAINT [FK_ingreso_proveedor] FOREIGN KEY([idproveedor])
REFERENCES [dbo].[proveedor] ([idproveedor])
GO
ALTER TABLE [dbo].[ingreso] CHECK CONSTRAINT [FK_ingreso_proveedor]
GO
/****** Object:  ForeignKey [FK_ingreso_trabajador]    Script Date: 05/26/2016 01:43:06 ******/
ALTER TABLE [dbo].[ingreso]  WITH CHECK ADD  CONSTRAINT [FK_ingreso_trabajador] FOREIGN KEY([idtrabajador])
REFERENCES [dbo].[trabajador] ([idtrabajador])
GO
ALTER TABLE [dbo].[ingreso] CHECK CONSTRAINT [FK_ingreso_trabajador]
GO
/****** Object:  ForeignKey [FK_venta_cliente]    Script Date: 05/26/2016 01:43:17 ******/
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_cliente] FOREIGN KEY([idcliente])
REFERENCES [dbo].[cliente] ([idcliente])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_cliente]
GO
/****** Object:  ForeignKey [FK_venta_trabajador]    Script Date: 05/26/2016 01:43:17 ******/
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_trabajador] FOREIGN KEY([idtrabajador])
REFERENCES [dbo].[trabajador] ([idtrabajador])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_trabajador]
GO
/****** Object:  ForeignKey [FK_detalle_ingreso_articulo]    Script Date: 05/26/2016 01:43:17 ******/
ALTER TABLE [dbo].[detalle_ingreso]  WITH CHECK ADD  CONSTRAINT [FK_detalle_ingreso_articulo] FOREIGN KEY([idarticulo])
REFERENCES [dbo].[articulo] ([idarticulo])
GO
ALTER TABLE [dbo].[detalle_ingreso] CHECK CONSTRAINT [FK_detalle_ingreso_articulo]
GO
/****** Object:  ForeignKey [FK_detalle_ingreso_ingreso]    Script Date: 05/26/2016 01:43:17 ******/
ALTER TABLE [dbo].[detalle_ingreso]  WITH CHECK ADD  CONSTRAINT [FK_detalle_ingreso_ingreso] FOREIGN KEY([idingreso])
REFERENCES [dbo].[ingreso] ([idingreso])
GO
ALTER TABLE [dbo].[detalle_ingreso] CHECK CONSTRAINT [FK_detalle_ingreso_ingreso]
GO
/****** Object:  ForeignKey [FK_detalle_venta_detalle_ingreso]    Script Date: 05/26/2016 01:43:17 ******/
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_venta_detalle_ingreso] FOREIGN KEY([iddetalleingreso])
REFERENCES [dbo].[detalle_ingreso] ([iddetalleingreso])
GO
ALTER TABLE [dbo].[detalle_venta] CHECK CONSTRAINT [FK_detalle_venta_detalle_ingreso]
GO
/****** Object:  ForeignKey [FK_detalle_venta_venta]    Script Date: 05/26/2016 01:43:17 ******/
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_venta_venta] FOREIGN KEY([idventa])
REFERENCES [dbo].[venta] ([idventa])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_venta] CHECK CONSTRAINT [FK_detalle_venta_venta]
GO
