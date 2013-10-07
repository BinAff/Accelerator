USE [AutoTourism]
GO
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'Navigator')
	EXEC('CREATE SCHEMA Navigator AUTHORIZATION dbo');
GO
----------Create Table---------
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[Artifact]') AND type in (N'U'))
	CREATE TABLE [Navigator].[Artifact](
		[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
		[FileName] [varchar](50) NOT NULL,
		[Path] [varchar](max) NOT NULL,
		[Style] [numeric](2, 0) NOT NULL,
		[Version] [numeric](4, 0) NOT NULL,
		[ParentId] [numeric](10, 0) NOT NULL,
		[CreatedByUserId] [numeric](10, 0) NOT NULL,
		[CreatedAt] [datetime] NOT NULL,
		[ModifiedByUserId] [numeric](10, 0) NULL,
		[ModifiedAt] [datetime] NULL,
	 CONSTRAINT [PK_Artifact] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
GO
ALTER TABLE [Navigator].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Account] FOREIGN KEY([CreatedByUserId])
REFERENCES [Gaurdian].[Account] ([Id])
GO
ALTER TABLE [Navigator].[Artifact] CHECK CONSTRAINT [FK_Artifact_Account]
GO
ALTER TABLE [Navigator].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Account1] FOREIGN KEY([ModifiedByUserId])
REFERENCES [Gaurdian].[Account] ([Id])
GO
ALTER TABLE [Navigator].[Artifact] CHECK CONSTRAINT [FK_Artifact_Account1]
GO
ALTER TABLE [Navigator].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Artifact] FOREIGN KEY([ParentId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
ALTER TABLE [Navigator].[Artifact] CHECK CONSTRAINT [FK_Artifact_Artifact]
GO
----------Create----------
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Navigator.ArtifactInsert') AND type in (N'P', N'PC'))
	DROP PROCEDURE Navigator.ArtifactInsert
GO
CREATE PROCEDURE Navigator.ArtifactInsert
(  
	@FileName Varchar(50),
	@Path Varchar(50),
	@Style Numeric(2,0),
	@Version Numeric(4,0),
	@CreatedByUserId  Numeric(10,0),
	@CreatedAt DateTime,
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Navigator.Artifact([FileName], [Path], Style, [Version], CreatedByUserId, CreatedAt)
	VALUES(@FileName, @Path, @Style, @Version, @CreatedByUserId, @CreatedAt)
   
	SET @Id = @@IDENTITY
END
GO
----------Read----------
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Navigator.ArtifactRead') AND type in (N'P', N'PC'))
	DROP PROCEDURE Navigator.ArtifactRead
GO
CREATE PROCEDURE Navigator.ArtifactRead
(  
	@Id  Numeric(10,0)
)
AS
BEGIN	
	SELECT Id, [FileName], [Path], Style, [Version], ParentId,
		CreatedByUserId, CreatedAt, ModifiedByUserId, ModifiedAt
	FROM Navigator.Artifact
	WHERE Id = @Id
END
GO
----------ReadAll----------
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Navigator.ArtifactReadAll') AND type in (N'P', N'PC'))
	DROP PROCEDURE Navigator.ArtifactReadAll
GO
CREATE PROCEDURE Navigator.ArtifactReadAll
AS
BEGIN	
	SELECT Id, [FileName], [Path], Style, [Version], ParentId,
		CreatedByUserId, CreatedAt, ModifiedByUserId, ModifiedAt
	FROM Navigator.Artifact
END
GO
----------Update----------
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Navigator.ArtifactUpdate') AND type in (N'P', N'PC'))
	DROP PROCEDURE Navigator.ArtifactUpdate
GO
CREATE PROCEDURE Navigator.ArtifactUpdate
(  
	@Id  Numeric(10,0),
	@FileName Varchar(50),
	@Path Varchar(50),
	@ModifiedByUserId  Numeric(10,0),
	@ModifiedAt DateTime	
)
AS
BEGIN	
	UPDATE Navigator.Artifact
	SET [FileName] = @FileName,
		[Path] = @Path,
		[Version] = [Version] + 1,
		ModifiedByUserId = @ModifiedByUserId,
		ModifiedAt = @ModifiedAt
	WHERE Id = @Id
END
GO
----------Delete----------
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Navigator.ArtifactDelete') AND type in (N'P', N'PC'))
	DROP PROCEDURE Navigator.ArtifactDelete
GO
CREATE PROCEDURE Navigator.ArtifactDelete
(  
	@Id  Numeric(10,0)
)
AS
BEGIN	
	DELETE FROM Navigator.Artifact
	WHERE Id = @Id
END
GO