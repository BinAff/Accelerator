

GO

/****** Object:  Table [Lodge].[BuildingType]    Script Date: 03/05/2013 17:20:29 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingType]') AND type in (N'U'))
Begin
	CREATE TABLE [Lodge].[BuildingType](
		[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
		[Name] [varchar](50) NOT NULL,
	 CONSTRAINT [PK_BuildingType] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

End


GO

/****** Object:  Table [Lodge].[BuildingStatus]    Script Date: 03/05/2013 17:20:55 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatus]') AND type in (N'U'))
Begin	

	CREATE TABLE [Lodge].[BuildingStatus](
	[Id] [numeric](10, 0) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	 CONSTRAINT [PK_BuildingStatus] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

End

GO



/****** Object:  Table [Lodge].[Building]    Script Date: 03/05/2013 17:21:53 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[Building]') AND type in (N'U'))
Begin
	CREATE TABLE [Lodge].[Building](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[TypeId] [numeric](10, 0) NOT NULL,
	[StatusId] [numeric](10, 0) NOT NULL,
	[OrganizationId] [numeric](10, 0) NOT NULL,
	 CONSTRAINT [PK_Building] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
	

	SET ANSI_PADDING OFF

	ALTER TABLE [Lodge].[Building]  WITH CHECK ADD  CONSTRAINT [FK_Building_BuildingStatus] FOREIGN KEY([StatusId])
	REFERENCES [Lodge].[BuildingStatus] ([Id])

	ALTER TABLE [Lodge].[Building] CHECK CONSTRAINT [FK_Building_BuildingStatus]

	ALTER TABLE [Lodge].[Building]  WITH CHECK ADD  CONSTRAINT [FK_Building_BuildingType] FOREIGN KEY([TypeId])
	REFERENCES [Lodge].[BuildingType] ([Id])	

	ALTER TABLE [Lodge].[Building] CHECK CONSTRAINT [FK_Building_BuildingType]

	ALTER TABLE [Lodge].[Building]  WITH CHECK ADD  CONSTRAINT [FK_Building_Organization] FOREIGN KEY([OrganizationId])
	REFERENCES [Organization].[Organization] ([Id])


	ALTER TABLE [Lodge].[Building] CHECK CONSTRAINT [FK_Building_Organization]

End

GO



/****** Object:  Table [Lodge].[Building]    Script Date: 03/05/2013 17:21:53 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReason]') AND type in (N'U'))
Begin
	CREATE TABLE [Lodge].[BuildingClosureReason](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Reason] [varchar](250) NOT NULL,
	[BuildingId] [numeric](10, 0) NOT NULL,
	[ClosedDate] [datetime] NOT NULL,
	 CONSTRAINT [PK_BuildingClosureReason] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]


	SET ANSI_PADDING OFF

	ALTER TABLE [Lodge].[BuildingClosureReason]  WITH CHECK ADD  CONSTRAINT [FK_BuildingClosureReason_Building] FOREIGN KEY([BuildingId])
	REFERENCES [Lodge].[Building] ([Id])

	ALTER TABLE [Lodge].[BuildingClosureReason] CHECK CONSTRAINT [FK_BuildingClosureReason_Building]

End

GO



/****** Object:  Table [Lodge].[BuildingFloor]    Script Date: 03/05/2013 17:24:12 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloor]') AND type in (N'U'))
Begin
	CREATE TABLE [Lodge].[BuildingFloor](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Floor] [varchar](50) NOT NULL,
	[BuildingId] [numeric](10, 0) NOT NULL,
	 CONSTRAINT [PK_BuildingFloor] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]


	ALTER TABLE [Lodge].[BuildingFloor]  WITH CHECK ADD  CONSTRAINT [FK_BuildingFloor_Building] FOREIGN KEY([BuildingId])
	REFERENCES [Lodge].[Building] ([Id])

	ALTER TABLE [Lodge].[BuildingFloor] CHECK CONSTRAINT [FK_BuildingFloor_Building]

End

GO
/************      Insert Script ****************************/

insert into [Lodge].[BuildingStatus] values (10001, 'Open')
Go
insert into [Lodge].[BuildingStatus] values (10002, 'Close')



GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeInsert]    Script Date: 03/06/2013 14:43:42 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingTypeInsert]
	(  
		@Name Varchar(50),	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].BuildingType([Name])
		VALUES(@Name)
	   
		SET @Id = @@IDENTITY
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeRead]    Script Date: 03/06/2013 14:52:21 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[BuildingTypeRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[Name]
		FROM [Lodge].BuildingType
		WHERE Id = @Id   
		
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeUpdate]    Script Date: 03/06/2013 14:59:10 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeUpdate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingTypeUpdate]
	(	
		@Id Numeric(10,0),
		@Name Varchar(50)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].BuildingType
		SET	
			[Name] = @Name
		WHERE Id = @Id
	   
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeDelete]    Script Date: 03/06/2013 15:03:24 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE  [Lodge].[BuildingTypeDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].BuildingType
		WHERE Id = @Id      
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[BuildingTypeReadAll]    Script Date: 03/06/2013 15:12:02 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingTypeReadAll]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[BuildingTypeReadAll]
	As
	Begin
		Select Id,Name
		From [Lodge].BuildingType
	End'
End

GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusInsert]    Script Date: 03/06/2013 15:38:42 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingStatusInsert]
	(  
		@Name Varchar(50),	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].BuildingStatus([Name])
		VALUES(@Name)
	   
		SET @Id = @@IDENTITY
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusRead]    Script Date: 03/06/2013 15:39:35 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[BuildingStatusRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[Name]
		FROM [Lodge].BuildingStatus
		WHERE Id = @Id   
		
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusUpdate]    Script Date: 03/06/2013 15:39:04 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusUpdate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingStatusUpdate]
	(	
		@Id Numeric(10,0),
		@Name Varchar(50)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].BuildingStatus
		SET	
			[Name] = @Name
		WHERE Id = @Id
	   
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusDelete]    Script Date: 03/06/2013 15:39:59 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE  [Lodge].[BuildingStatusDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].BuildingStatus
		WHERE Id = @Id      
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[BuildingStatusReadAll]    Script Date: 03/06/2013 15:40:19 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingStatusReadAll]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingStatusReadAll]
	As
	Begin
		Select Id,Name
		From [Lodge].BuildingStatus
	End'
End

GO
/****** Object:  StoredProcedure [Lodge].[BuildingInsert]    Script Date: 03/06/2013 16:10:00 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingInsert]
	(  
		@Name Varchar(50),	
		@TypeId Numeric(10,0),
		@StatusId Numeric(10,0),
		@OrganizationId Numeric(10,0),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].Building([Name],[TypeId],[StatusId],[OrganizationId])
		VALUES(@Name,@TypeId,@StatusId,@OrganizationId)
	   
		SET @Id = @@IDENTITY
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorInsert]    Script Date: 03/06/2013 16:23:40 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingFloorInsert]
	(  
		@Name Varchar(50),	
		@BuildingId Numeric(10,0),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].BuildingFloor([Floor],[BuildingId])
		VALUES(@Name,@BuildingId)
	   
		SET @Id = @@IDENTITY
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[BuildingRead]    Script Date: 03/07/2013 10:06:26 ******/	
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[BuildingRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[Name],
			[TypeId],
			[StatusId],
			[OrganizationId]
		FROM [Lodge].Building
		WHERE Id = @Id   
		
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorReadForParent]    Script Date: 03/07/2013 10:14:53 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorReadForParent]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingFloorReadForParent]
	(
		@ParentId Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[BuildingId],
			[FLOOR]
		FROM [Lodge].BuildingFloor
		WHERE BuildingId = @ParentId   
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorRead]    Script Date: 03/07/2013 10:45:32 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingFloorRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[FLOOR],			
			[BuildingId]
		FROM [Lodge].BuildingFloor
		WHERE Id = @Id   
		
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorDelete]    Script Date: 03/07/2013 10:49:49 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingFloorDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE  [Lodge].[BuildingFloorDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].BuildingFloor
		WHERE Id = @Id      
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonRead]    Script Date: 03/07/2013 10:54:33 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingClosureReasonRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[Reason],			
			[BuildingId],
			[ClosedDate]
		FROM [Lodge].BuildingClosureReason
		WHERE Id = @Id   
		
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonDelete]    Script Date: 03/07/2013 10:58:00 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE  [Lodge].[BuildingClosureReasonDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].BuildingClosureReason
		WHERE Id = @Id      
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonInsert]    Script Date: 03/07/2013 12:08:28 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingClosureReasonInsert]
	(  
		@Reason Varchar(50),	
		@BuildingId Numeric(10,0),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].BuildingClosureReason([Reason],[BuildingId],ClosedDate)
		VALUES(@Reason,@BuildingId,GETDATE())
	   
		SET @Id = @@IDENTITY
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[BuildingClosureReasonReadForParent]    Script Date: 03/07/2013 12:13:40 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingClosureReasonReadForParent]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingClosureReasonReadForParent]
	(
		@ParentId Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[BuildingId],
			[Reason],
			[ClosedDate]
		FROM [Lodge].BuildingClosureReason
		WHERE BuildingId = @ParentId   
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[BuildingDelete]    Script Date: 03/07/2013 12:22:22 ******/ 
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE  [Lodge].[BuildingDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].Building
		WHERE Id = @Id      
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[BuildingReadAll]    Script Date: 03/07/2013 12:36:32 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingReadAll]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[BuildingReadAll]
	AS
	BEGIN
		
		SELECT 
			Id,
			[Name],
			[TypeId],
			[StatusId],
			[OrganizationId]
		FROM [Lodge].Building
	   
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[BuildingModifyStatus]    Script Date: 03/10/2013 15:12:01 ******/	
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[BuildingModifyStatus]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[BuildingModifyStatus]
	(	
		@Id Numeric(10,0),
		@StatusId Numeric(10,0)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].Building
		SET	
			[StatusId] = @StatusId			
		WHERE Id = @Id
	   
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingDeletable]    Script Date: 04/23/2013 17:03:51 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingDeletable]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create Procedure [Lodge].[IsBuildingDeletable]
	(
		@OrganizationId NUMERIC(10,0)
	)
	As
	Begin
		select Name,StatusId from [Lodge].Building
		where OrganizationId = @OrganizationId
	End'
End

GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingTypeDeletable]    Script Date: 04/24/2013 19:06:09 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingTypeDeletable]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [Lodge].[IsBuildingTypeDeletable] 
	(
		@TypeId NUMERIC(10,0)
	)
	As
	Begin
		select Name from [Lodge].Building
		where TypeId = @TypeId
	End'
End