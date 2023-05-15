
--1) correr 


CREATE DATABASE banco;


--2)



USE [banco]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 15/5/2023 10:13:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Clientes]') AND type in (N'U'))
DROP TABLE [dbo].[Clientes]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 15/5/2023 10:13:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[tarjeta] [int] NOT NULL,
	[password] [varchar](100) NULL,
	[dni] [int] NOT NULL,
	[nombre] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [banco]
GO
/****** Object:  Table [dbo].[Ingresos]    Script Date: 15/5/2023 10:14:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingresos](
	[idIngreso] [int] IDENTITY(1,1) NOT NULL,
	[idCliente] [int] NOT NULL,
	[numeroIngreso] [int] NOT NULL,
	[bloqueado] [bit] NOT NULL,
	[FechaRegistro] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[idIngreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


