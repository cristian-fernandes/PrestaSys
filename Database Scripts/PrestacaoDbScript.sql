USE [master]
GO
/****** Object:  Database [PrestacaoDb]    Script Date: 2/25/2019 12:44:18 PM ******/
CREATE DATABASE [PrestacaoDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PrestacaoDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PrestacaoDb.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PrestacaoDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PrestacaoDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PrestacaoDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PrestacaoDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PrestacaoDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PrestacaoDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PrestacaoDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PrestacaoDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PrestacaoDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [PrestacaoDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PrestacaoDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PrestacaoDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PrestacaoDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PrestacaoDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PrestacaoDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PrestacaoDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PrestacaoDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PrestacaoDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PrestacaoDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PrestacaoDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PrestacaoDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PrestacaoDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PrestacaoDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PrestacaoDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PrestacaoDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PrestacaoDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PrestacaoDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PrestacaoDb] SET  MULTI_USER 
GO
ALTER DATABASE [PrestacaoDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PrestacaoDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PrestacaoDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PrestacaoDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PrestacaoDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [PrestacaoDb]
GO
/****** Object:  User [PrestacaoAdmin]    Script Date: 2/25/2019 12:44:18 PM ******/
CREATE USER [PrestacaoAdmin] FOR LOGIN [PrestacaoAdmin] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [PrestacaoAdmin]
GO
/****** Object:  Table [dbo].[Prestacao]    Script Date: 2/25/2019 12:44:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prestacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](50) NOT NULL,
	[Justificativa] [nvarchar](max) NOT NULL,
	[Data] [datetime] NOT NULL,
	[ImagemComprovante] [varbinary](max) NULL,
	[Valor] [decimal](18, 0) NOT NULL,
	[StatusId] [int] NOT NULL,
	[TipoId] [int] NOT NULL,
	[EmitenteId] [int] NOT NULL,
	[AprovadorId] [int] NOT NULL,
	[AprovadorFinanceiroId] [int] NOT NULL,
 CONSTRAINT [PK_Prestacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrestacaoStatus]    Script Date: 2/25/2019 12:44:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrestacaoStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PrestacaoStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrestacaoTipo]    Script Date: 2/25/2019 12:44:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrestacaoTipo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PrestacaoTipo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 2/25/2019 12:44:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](50) NOT NULL,
	[Sobrenome] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Senha] [nvarchar](50) NOT NULL,
	[FlagGerente] [bit] NOT NULL,
	[FlagGerenteFinanceiro] [bit] NOT NULL,
	[GerenteId] [int] NULL,
	[GerenteFinanceiroId] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Prestacao] ON 
GO
INSERT [dbo].[Prestacao] ([Id], [Titulo], [Justificativa], [Data], [ImagemComprovante], [Valor], [StatusId], [TipoId], [EmitenteId], [AprovadorId], [AprovadorFinanceiroId]) VALUES (2, N'Teste', N'Testesssssss', CAST(N'2019-02-22T18:31:00.000' AS DateTime), NULL, CAST(50 AS Decimal(18, 0)), 1, 1, 1, 1, 1)
GO
INSERT [dbo].[Prestacao] ([Id], [Titulo], [Justificativa], [Data], [ImagemComprovante], [Valor], [StatusId], [TipoId], [EmitenteId], [AprovadorId], [AprovadorFinanceiroId]) VALUES (3, N'Teste 2', N'AAAAsadiosahdusahdsahdusiahdiad', CAST(N'2019-02-01T00:10:00.000' AS DateTime), NULL, CAST(100 AS Decimal(18, 0)), 1, 3, 1, 1, 1)
GO
INSERT [dbo].[Prestacao] ([Id], [Titulo], [Justificativa], [Data], [ImagemComprovante], [Valor], [StatusId], [TipoId], [EmitenteId], [AprovadorId], [AprovadorFinanceiroId]) VALUES (4, N'Para Excluir', N'ssafsdfsddsfgf', CAST(N'2019-02-27T10:10:00.000' AS DateTime), NULL, CAST(15 AS Decimal(18, 0)), 1, 2, 1, 1, 1)
GO
INSERT [dbo].[Prestacao] ([Id], [Titulo], [Justificativa], [Data], [ImagemComprovante], [Valor], [StatusId], [TipoId], [EmitenteId], [AprovadorId], [AprovadorFinanceiroId]) VALUES (5, N'Teste', N'AAAAA', CAST(N'2019-02-15T12:22:00.000' AS DateTime), NULL, CAST(10 AS Decimal(18, 0)), 1, 1, 1, 1, 1)
GO
INSERT [dbo].[Prestacao] ([Id], [Titulo], [Justificativa], [Data], [ImagemComprovante], [Valor], [StatusId], [TipoId], [EmitenteId], [AprovadorId], [AprovadorFinanceiroId]) VALUES (6, N'ASADSA', N'DFDSF', CAST(N'2019-12-12T22:10:00.000' AS DateTime), NULL, CAST(1 AS Decimal(18, 0)), 1, 1, 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Prestacao] OFF
GO
SET IDENTITY_INSERT [dbo].[PrestacaoStatus] ON 
GO
INSERT [dbo].[PrestacaoStatus] ([Id], [Status]) VALUES (1, N'Iniciada')
GO
INSERT [dbo].[PrestacaoStatus] ([Id], [Status]) VALUES (2, N'Em Aprovação Operacional')
GO
INSERT [dbo].[PrestacaoStatus] ([Id], [Status]) VALUES (3, N'Em Aprovação Financeira')
GO
INSERT [dbo].[PrestacaoStatus] ([Id], [Status]) VALUES (4, N'Finalizada')
GO
SET IDENTITY_INSERT [dbo].[PrestacaoStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[PrestacaoTipo] ON 
GO
INSERT [dbo].[PrestacaoTipo] ([Id], [Tipo]) VALUES (1, N'Viagem')
GO
INSERT [dbo].[PrestacaoTipo] ([Id], [Tipo]) VALUES (2, N'Curso de Idioma')
GO
INSERT [dbo].[PrestacaoTipo] ([Id], [Tipo]) VALUES (3, N'Alimentação')
GO
SET IDENTITY_INSERT [dbo].[PrestacaoTipo] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Sobrenome], [Email], [Senha], [FlagGerente], [FlagGerenteFinanceiro], [GerenteId], [GerenteFinanceiroId]) VALUES (1, N'Cristian', N'Fernandes', N'fernandes.cristian@yahoo.com.br', N'asdf', 1, 1, 1, 1)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Sobrenome], [Email], [Senha], [FlagGerente], [FlagGerenteFinanceiro], [GerenteId], [GerenteFinanceiroId]) VALUES (2, N'Teste', N'Teste', N'teste@teste.com', N'123', 1, 0, 1, 1)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Sobrenome], [Email], [Senha], [FlagGerente], [FlagGerenteFinanceiro], [GerenteId], [GerenteFinanceiroId]) VALUES (4, N'Teste Manager', N'Finance', N'teste@financeiro.com', N'12345', 0, 1, 2, 1)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Sobrenome], [Email], [Senha], [FlagGerente], [FlagGerenteFinanceiro], [GerenteId], [GerenteFinanceiroId]) VALUES (5, N'Ander', N'Teste', N'teste@test.com.br', N'aaaaa', 0, 0, 1, 4)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Sobrenome], [Email], [Senha], [FlagGerente], [FlagGerenteFinanceiro], [GerenteId], [GerenteFinanceiroId]) VALUES (6, N'Lisa', N'Test', N'lisa@test.com', N'456', 0, 1, 1, 1)
GO
INSERT [dbo].[Usuario] ([Id], [Nome], [Sobrenome], [Email], [Senha], [FlagGerente], [FlagGerenteFinanceiro], [GerenteId], [GerenteFinanceiroId]) VALUES (7, N'Colab', N'Loja', N'colab@teste', N'456', 0, 0, 1, 6)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [U_UsuarioEmail]    Script Date: 2/25/2019 12:44:19 PM ******/
ALTER TABLE [dbo].[Usuario] ADD  CONSTRAINT [U_UsuarioEmail] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Prestacao]  WITH CHECK ADD  CONSTRAINT [FK_PrestacaoStatus_Prestacao] FOREIGN KEY([StatusId])
REFERENCES [dbo].[PrestacaoStatus] ([Id])
GO
ALTER TABLE [dbo].[Prestacao] CHECK CONSTRAINT [FK_PrestacaoStatus_Prestacao]
GO
ALTER TABLE [dbo].[Prestacao]  WITH CHECK ADD  CONSTRAINT [FK_PrestacaoTipo_Prestacao] FOREIGN KEY([TipoId])
REFERENCES [dbo].[PrestacaoTipo] ([Id])
GO
ALTER TABLE [dbo].[Prestacao] CHECK CONSTRAINT [FK_PrestacaoTipo_Prestacao]
GO
ALTER TABLE [dbo].[Prestacao]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_PrestacaoAprovadorFinanceiroId] FOREIGN KEY([AprovadorFinanceiroId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Prestacao] CHECK CONSTRAINT [FK_Usuario_PrestacaoAprovadorFinanceiroId]
GO
ALTER TABLE [dbo].[Prestacao]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_PrestacaoAprovadorId] FOREIGN KEY([AprovadorId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Prestacao] CHECK CONSTRAINT [FK_Usuario_PrestacaoAprovadorId]
GO
ALTER TABLE [dbo].[Prestacao]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_PrestacaoEmitenteId] FOREIGN KEY([EmitenteId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Prestacao] CHECK CONSTRAINT [FK_Usuario_PrestacaoEmitenteId]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Id_GerenteFinanceiroId] FOREIGN KEY([GerenteFinanceiroId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Id_GerenteFinanceiroId]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Id_GerenteId] FOREIGN KEY([GerenteId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Id_GerenteId]
GO
USE [master]
GO
ALTER DATABASE [PrestacaoDb] SET  READ_WRITE 
GO
