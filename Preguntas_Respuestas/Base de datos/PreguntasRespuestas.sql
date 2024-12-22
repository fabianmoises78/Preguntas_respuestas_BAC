USE [PreguntasRespuestas]
GO
/****** Object:  Table [dbo].[Preguntas]    Script Date: 22/12/2024 10:16:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Preguntas](
	[IdPregunta] [int] IDENTITY(1,1) NOT NULL,
	[Pregunta] [nvarchar](max) NULL,
	[IdUsuario] [int] NULL,
	[FechaCreacion] [datetime] NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPregunta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Respuestas]    Script Date: 22/12/2024 10:16:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Respuestas](
	[IdRespuesta] [int] IDENTITY(1,1) NOT NULL,
	[Respuesta] [nvarchar](max) NULL,
	[IdPregunta] [int] NULL,
	[IdUsuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRespuesta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 22/12/2024 10:16:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Usuario] [nvarchar](max) NULL,
	[Contrasena] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Preguntas] ON 
GO
INSERT [dbo].[Preguntas] ([IdPregunta], [Pregunta], [IdUsuario], [FechaCreacion], [Estado]) VALUES (1, N'¿Cual es el pais mas grande del planeta?', 1, CAST(N'2024-12-21T15:12:13.263' AS DateTime), 1)
GO
INSERT [dbo].[Preguntas] ([IdPregunta], [Pregunta], [IdUsuario], [FechaCreacion], [Estado]) VALUES (2, N'¿Donde vives?', 1, CAST(N'2024-12-21T16:03:08.920' AS DateTime), 0)
GO
INSERT [dbo].[Preguntas] ([IdPregunta], [Pregunta], [IdUsuario], [FechaCreacion], [Estado]) VALUES (3, N'¿Cual es es tu oficio?', 1, CAST(N'2024-12-21T23:06:06.120' AS DateTime), 1)
GO
INSERT [dbo].[Preguntas] ([IdPregunta], [Pregunta], [IdUsuario], [FechaCreacion], [Estado]) VALUES (4, N'¿Cual es el elemento mas caro conocido hasta ahora?', 1, CAST(N'2024-12-22T08:42:37.577' AS DateTime), 1)
GO
INSERT [dbo].[Preguntas] ([IdPregunta], [Pregunta], [IdUsuario], [FechaCreacion], [Estado]) VALUES (5, N'Cual es el precio de un Honda Civic 2009 en El Salvador?', 3, CAST(N'2024-12-22T08:44:28.627' AS DateTime), 1)
GO
INSERT [dbo].[Preguntas] ([IdPregunta], [Pregunta], [IdUsuario], [FechaCreacion], [Estado]) VALUES (6, N'Cual es tu edad con meses y dias', 1, CAST(N'2024-12-22T10:06:13.277' AS DateTime), 1)
GO
SET IDENTITY_INSERT [dbo].[Preguntas] OFF
GO
SET IDENTITY_INSERT [dbo].[Respuestas] ON 
GO
INSERT [dbo].[Respuestas] ([IdRespuesta], [Respuesta], [IdPregunta], [IdUsuario]) VALUES (1, N'Segun datos la Antartida', 1, 1)
GO
INSERT [dbo].[Respuestas] ([IdRespuesta], [Respuesta], [IdPregunta], [IdUsuario]) VALUES (2, N'Soy programador .NET', 3, 1)
GO
INSERT [dbo].[Respuestas] ([IdRespuesta], [Respuesta], [IdPregunta], [IdUsuario]) VALUES (3, N'El Salvador', 2, 3)
GO
INSERT [dbo].[Respuestas] ([IdRespuesta], [Respuesta], [IdPregunta], [IdUsuario]) VALUES (4, N'Segun yo, Rusia', 1, 3)
GO
INSERT [dbo].[Respuestas] ([IdRespuesta], [Respuesta], [IdPregunta], [IdUsuario]) VALUES (5, N'El oro', 4, 3)
GO
INSERT [dbo].[Respuestas] ([IdRespuesta], [Respuesta], [IdPregunta], [IdUsuario]) VALUES (6, N'alrededor de los 4mil dolares helando rico', 5, 1)
GO
SET IDENTITY_INSERT [dbo].[Respuestas] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([IdUsuario], [Nombre], [Usuario], [Contrasena]) VALUES (1, N'Moises', N'Fabianmoises', N'1234')
GO
INSERT [dbo].[Usuario] ([IdUsuario], [Nombre], [Usuario], [Contrasena]) VALUES (2, N'fulano', N'Fabianmoises', N'1233')
GO
INSERT [dbo].[Usuario] ([IdUsuario], [Nombre], [Usuario], [Contrasena]) VALUES (3, N'Eduardo', N'Edro08', N'1234')
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Preguntas]  WITH CHECK ADD  CONSTRAINT [fk_usuario_pregunta] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Preguntas] CHECK CONSTRAINT [fk_usuario_pregunta]
GO
ALTER TABLE [dbo].[Respuestas]  WITH CHECK ADD  CONSTRAINT [fk_pregunta_respuesta] FOREIGN KEY([IdPregunta])
REFERENCES [dbo].[Preguntas] ([IdPregunta])
GO
ALTER TABLE [dbo].[Respuestas] CHECK CONSTRAINT [fk_pregunta_respuesta]
GO
ALTER TABLE [dbo].[Respuestas]  WITH CHECK ADD  CONSTRAINT [fk_usuario_respuesta] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Respuestas] CHECK CONSTRAINT [fk_usuario_respuesta]
GO
/****** Object:  StoredProcedure [dbo].[ActivarDesactivarPregunta]    Script Date: 22/12/2024 10:16:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ActivarDesactivarPregunta]
(
    @IdPregunta INT,
    @Estado BIT
)
AS 
BEGIN
    IF @Estado = 1
    BEGIN
        UPDATE Preguntas SET
        Estado = 0
        WHERE IdPregunta = @IdPregunta

        SELECT @@ROWCOUNT
    END
    ELSE
    BEGIN
        UPDATE Preguntas SET
        Estado = 1
        WHERE IdPregunta = @IdPregunta

        SELECT @@ROWCOUNT
    END
END
GO
/****** Object:  StoredProcedure [dbo].[CrearPregunta]    Script Date: 22/12/2024 10:16:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[CrearPregunta]
(
    @IdUsuario INT,
    @Pregunta NVARCHAR(MAX)
)
AS BEGIN
    INSERT INTO Preguntas(IdUsuario, Pregunta, FechaCreacion, Estado)
    VALUES(@IdUsuario, @Pregunta, GETDATE(), 1)
    
    SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[CrearRespuesta]    Script Date: 22/12/2024 10:16:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[CrearRespuesta]
(
    @Respuesta NVARCHAR(MAX),
    @IdUsuario INT,
    @IdPregunta INT
)
AS
BEGIN
    INSERT INTO Respuestas(Respuesta, IdPregunta, IdUsuario)
    VALUES(@Respuesta, @IdPregunta, @IdUsuario)

    SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[IniciarSesion]    Script Date: 22/12/2024 10:16:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[IniciarSesion]
(
    @Usuario NVARCHAR(MAX),
    @Contrasena NVARCHAR(MAX)
)
AS
BEGIN
    if EXISTS(select * from Usuario where Usuario = @Usuario)		
		IF EXISTS(SELECT * FROM Usuario WHERE Usuario = @Usuario AND Contrasena = @Contrasena)
			SELECT IdUsuario, Usuario, Nombre FROM Usuario WHERE Usuario = @Usuario AND Contrasena = Contrasena
		ELSE
			SELECT 0 as IdUsuario, '' as Usuario, '' as Nombre
	ELSE
			SELECT 0 as IdUsuario, '' as Usuario, '' as Nombre
END
GO
/****** Object:  StoredProcedure [dbo].[ListarProcedure]    Script Date: 22/12/2024 10:16:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ListarProcedure]
AS BEGIN
    SELECT IdPregunta, Pregunta, P.IdUsuario, Estado, U.Usuario FROM Preguntas AS P
    INNER JOIN Usuario AS U ON P.IdUsuario = U.IdUsuario
    WHERE Estado = 1 ORDER BY FechaCreacion DESC
END
GO
/****** Object:  StoredProcedure [dbo].[ListarRespuestasbyPregunta]    Script Date: 22/12/2024 10:16:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ListarRespuestasbyPregunta]
(
    @IdPregunta INT
)
AS
BEGIN
    SELECT IdRespuesta, Respuesta, IdPregunta, R.IdUsuario, U.Usuario
    FROM Respuestas AS R 
    INNER JOIN Usuario AS U ON R.IdUsuario = U.IdUsuario
    WHERE IdPregunta = @IdPregunta
END
GO
/****** Object:  StoredProcedure [dbo].[PreguntasbyUser]    Script Date: 22/12/2024 10:16:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[PreguntasbyUser]
(
    @IdUsuario INT
)
AS
BEGIN
    SELECT IdPregunta, Pregunta, IdUsuario, Estado FROM Preguntas WHERE IdUsuario = @IdUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[PreguntaxId]    Script Date: 22/12/2024 10:16:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[PreguntaxId]
(
    @IdPregunta INT
)
AS
BEGIN
    SELECT IdPregunta, Pregunta, P.IdUsuario, Estado, U.Usuario FROM Preguntas AS P
    INNER JOIN Usuario AS U ON P.IdUsuario = U.IdUsuario
    WHERE IdPregunta = @IdPregunta ORDER BY FechaCreacion DESC
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarUsuario]    Script Date: 22/12/2024 10:16:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[RegistrarUsuario]
(
    @Nombre NVARCHAR(MAX),
    @Usuario NVARCHAR(MAX),
    @Contrasena NVARCHAR(MAX)
)
AS BEGIN
    INSERT INTO Usuario(Nombre, Usuario, Contrasena)
    VALUES(@Nombre, @Usuario, @Contrasena);

    SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[UsuarioExiste]    Script Date: 22/12/2024 10:16:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[UsuarioExiste]
(
    @Usuario NVARCHAR(MAX)
)
AS
BEGIN
    SELECT COUNT(*) FROM Usuario WHERE Usuario = @Usuario
END
GO
