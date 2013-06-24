



GO
/****** Object:  Table [Lodge].[RoomStatus]    Script Date: 03/10/2013 15:19:08 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomStatus]') AND type in (N'U'))
Begin
	CREATE TABLE [Lodge].[RoomStatus](
	[Id] [numeric](10, 0) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	 CONSTRAINT [PK_RoomStatus] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

End

GO
/****** Object:  Table [Lodge].[RoomCategory]    Script Date: 03/10/2013 16:32:20 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategory]') AND type in (N'U'))
Begin
	CREATE TABLE [Lodge].[RoomCategory](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	 CONSTRAINT [PK_RoomCategory] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

End

GO
/****** Object:  Table [Lodge].[RoomType]    Script Date: 03/10/2013 17:00:38 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomType]') AND type in (N'U'))
Begin
	CREATE TABLE [Lodge].[RoomType](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	 CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

End

GO
/****** Object:  Table [Lodge].[Room]    Script Date: 03/12/2013 12:39:38 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[Room]') AND type in (N'U'))
Begin
	CREATE TABLE [Lodge].[Room](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Number] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[CategoryId] [numeric](10, 0) NOT NULL,
	[TypeId] [numeric](10, 0) NOT NULL,
	[BuildingId] [numeric](10, 0) NOT NULL,
	[FloorId] [numeric](10, 0) NOT NULL,
	[IsAirConditioned] [bit] NOT NULL,
	[StatusId] [numeric](10, 0) NOT NULL,
	 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	
	SET ANSI_PADDING OFF
	
	ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Building] FOREIGN KEY([BuildingId])
	REFERENCES [Lodge].[Building] ([Id])
	
	ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_Building]
	
	ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_BuildingFloor] FOREIGN KEY([FloorId])
	REFERENCES [Lodge].[BuildingFloor] ([Id])
	
	ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_BuildingFloor]
	
	ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomCategory] FOREIGN KEY([CategoryId])
	REFERENCES [Lodge].[RoomCategory] ([Id])
	
	ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_RoomCategory]
	
	ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomStatus] FOREIGN KEY([StatusId])
	REFERENCES [Lodge].[RoomStatus] ([Id])
	
	ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_RoomStatus]
	
	ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomType] FOREIGN KEY([TypeId])
	REFERENCES [Lodge].[RoomType] ([Id])
	
	ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_RoomType]
	
End

GO
/****** Object:  Table [Lodge].[RoomClosureReason]    Script Date: 03/12/2013 12:34:18 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReason]') AND type in (N'U'))
Begin
	
	CREATE TABLE [Lodge].[RoomClosureReason](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[ClosedDate] [datetime] NOT NULL,
	[Reason] [varchar](256) NOT NULL,
	[RoomId] [numeric](10, 0) NOT NULL,
	 CONSTRAINT [PK_RoomClosureReason] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]	

	SET ANSI_PADDING OFF

	ALTER TABLE [Lodge].[RoomClosureReason]  WITH CHECK ADD  CONSTRAINT [FK_RoomClosureReason_Room] FOREIGN KEY([RoomId])
	REFERENCES [Lodge].[Room] ([Id])	

	ALTER TABLE [Lodge].[RoomClosureReason] CHECK CONSTRAINT [FK_RoomClosureReason_Room]	

End
GO

GO
/****** Object:  Table [Lodge].[RoomImage]    Script Date: 03/12/2013 12:37:16 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomImage]') AND type in (N'U'))
Begin
	CREATE TABLE [Lodge].[RoomImage](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[RoomId] [numeric](10, 0) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Image] [image] NOT NULL,
	 CONSTRAINT [PK_RoomImage] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	
	SET ANSI_PADDING OFF

	ALTER TABLE [Lodge].[RoomImage]  WITH CHECK ADD  CONSTRAINT [FK_RoomImage_Room] FOREIGN KEY([RoomId])
	REFERENCES [Lodge].[Room] ([Id])

	ALTER TABLE [Lodge].[RoomImage] CHECK CONSTRAINT [FK_RoomImage_Room]

End

GO
/****** Object:  Table [Lodge].[RoomTariff]    Script Date: 03/12/2013 17:11:35 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariff]') AND type in (N'U'))
Begin
	CREATE TABLE [Lodge].[RoomTariff](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Rate] [money] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[RoomId] [numeric](10, 0) NOT NULL,
	 CONSTRAINT [PK_RoomTariff] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
	

	ALTER TABLE [Lodge].[RoomTariff]  WITH CHECK ADD  CONSTRAINT [FK_RoomTariff_Room] FOREIGN KEY([RoomId])
	REFERENCES [Lodge].[Room] ([Id])	

	ALTER TABLE [Lodge].[RoomTariff] CHECK CONSTRAINT [FK_RoomTariff_Room]
	
End

GO
/****** Object:  Table [Lodge].[RoomReservation]    Script Date: 03/24/2013 10:46:29 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservation]') AND type in (N'U'))
Begin
	CREATE TABLE [Lodge].[RoomReservation](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[BookingFrom] [datetime] NOT NULL,
	[NoOfDays] [int] NOT NULL,
	[NoOfPersons] [int] NOT NULL,
	[NoOfRooms] [int] NOT NULL,
	[Description] [varchar](150) NULL,
	[Advance] [money] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[StatusId] [numeric](10, 0) NOT NULL,
	[IsCheckedIn] [bit] NOT NULL,
	 CONSTRAINT [PK_RoomReservation] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	SET ANSI_PADDING OFF

	ALTER TABLE [Lodge].[RoomReservation]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservation_Status] FOREIGN KEY([StatusId])
	REFERENCES [Customer].[ActionStatus] ([Id])

	ALTER TABLE [Lodge].[RoomReservation] CHECK CONSTRAINT [FK_RoomReservation_Status]

	ALTER TABLE [Lodge].[RoomReservation] ADD  CONSTRAINT [DF_RoomReservation_IsCheckedIn]  DEFAULT ((0)) FOR [IsCheckedIn]
		
End

GO
/****** Object:  Table [Lodge].[RoomReservationDetails]    Script Date: 03/26/2013 11:52:31 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetails]') AND type in (N'U'))
Begin
	CREATE TABLE [Lodge].[RoomReservationDetails](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[RoomId] [numeric](10, 0) NOT NULL,
	[ReservationId] [numeric](10, 0) NOT NULL,
	 CONSTRAINT [PK_RoomReservationDetails] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	
	ALTER TABLE [Lodge].[RoomReservationDetails]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationDetails_Room] FOREIGN KEY([RoomId])
	REFERENCES [Lodge].[Room] ([Id])
	
	ALTER TABLE [Lodge].[RoomReservationDetails] CHECK CONSTRAINT [FK_RoomReservationDetails_Room]
	
	ALTER TABLE [Lodge].[RoomReservationDetails]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationDetails_RoomReservation] FOREIGN KEY([ReservationId])
	REFERENCES [Lodge].[RoomReservation] ([Id])
	
	ALTER TABLE [Lodge].[RoomReservationDetails] CHECK CONSTRAINT [FK_RoomReservationDetails_RoomReservation]
	
End

GO
/****** Object:  Table [Lodge].[CheckIn]    Script Date: 04/04/2013 15:21:05 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckIn]') AND type in (N'U'))
Begin
	CREATE TABLE [Lodge].[CheckIn](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[CheckInDate] [datetime] NOT NULL,
	[Advance] [money] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ReservationId] [numeric](10, 0) NULL,
	 CONSTRAINT [PK_CheckIn] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	
	ALTER TABLE [Lodge].[CheckIn]  WITH CHECK ADD  CONSTRAINT [FK_CheckIn_RoomReservation] FOREIGN KEY([ReservationId])
	REFERENCES [Lodge].[RoomReservation] ([Id])
	
	ALTER TABLE [Lodge].[CheckIn] CHECK CONSTRAINT [FK_CheckIn_RoomReservation]
	
End

/************      Insert Script ****************************/
insert into [Lodge].[RoomStatus] values (10001, 'Open')
Go
insert into [Lodge].[RoomStatus] values (10002, 'Close')

GO
/****** Object:  StoredProcedure [Lodge].[RoomStatusRead]    Script Date: 03/10/2013 15:31:24 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomStatusRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[RoomStatusRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[Name]
		FROM [Lodge].RoomStatus
		WHERE Id = @Id   
		
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryInsert]    Script Date: 03/10/2013 15:51:53 ******/	
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[RoomCategoryInsert]
	(  
		@Name Varchar(50),	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].RoomCategory([Name])
		VALUES(@Name)
	   
		SET @Id = @@IDENTITY
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryRead]    Script Date: 03/10/2013 15:57:16 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[RoomCategoryRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[Name]
		FROM [Lodge].RoomCategory
		WHERE Id = @Id   
		
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryReadAll]    Script Date: 03/10/2013 16:02:05 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryReadAll]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[RoomCategoryReadAll]
	As
	Begin
		Select Id,Name
		From [Lodge].RoomCategory
	End'
End

GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryUpdate]    Script Date: 03/10/2013 16:27:53 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryUpdate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomCategoryUpdate]
	(	
		@Id Numeric(10,0),
		@Name Varchar(50)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].RoomCategory
		SET	
			[Name] = @Name
		WHERE Id = @Id
	   
	END'
End



GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryDelete]    Script Date: 03/10/2013 16:31:08 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomCategoryDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE  [Lodge].[RoomCategoryDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].RoomCategory
		WHERE Id = @Id      
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeInsert]    Script Date: 03/10/2013 16:41:50 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTypeInsert]
	(  
		@Name Varchar(50),	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].RoomType([Name])
		VALUES(@Name)
	   
		SET @Id = @@IDENTITY
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeRead]    Script Date: 03/10/2013 16:45:01 ******/	
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTypeRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[Name]
		FROM [Lodge].RoomType
		WHERE Id = @Id   
		
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeReadAll]    Script Date: 03/10/2013 16:49:15 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeReadAll]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTypeReadAll]
	As
	Begin
		Select Id,Name
		From [Lodge].RoomType
	End'
End

GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeUpdate]    Script Date: 03/10/2013 16:56:38 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeUpdate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTypeUpdate]
	(	
		@Id Numeric(10,0),
		@Name Varchar(50)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].RoomType
		SET	
			[Name] = @Name
		WHERE Id = @Id
	   
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeDelete]    Script Date: 03/10/2013 16:59:39 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTypeDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE  [Lodge].[RoomTypeDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].RoomType
		WHERE Id = @Id      
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[RoomInsert]    Script Date: 03/11/2013 17:31:12 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomInsert]
	(  
		@Number Varchar(50),	
		@Name Varchar(50),
		@Description Varchar(50),
		@CategoryId Numeric(10,0),		
		@TypeId Numeric(10,0),
		@BuildingId Numeric(10,0),
		@FloorId Numeric(10,0),
		@IsAirConditioned Bit,		
		@StatusId Numeric(10,0),	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].Room([Number],[Name],[Description],[CategoryId],
		[TypeId],[BuildingId],[FloorId],[IsAirConditioned],[StatusId])
		VALUES(@Number,@Name,@Description,@CategoryId,@TypeId,@BuildingId,@FloorId,
		@IsAirConditioned,@StatusId)
	   
		SET @Id = @@IDENTITY
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[RoomRead]    Script Date: 03/11/2013 17:41:52 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[Number],
			[Name],
			[Description],
			[CategoryId],
			[TypeId],
			[BuildingId],
			[FloorId],
			[IsAirConditioned],
			[StatusId]
		FROM [Lodge].Room
		WHERE Id = @Id   
		
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[RoomImageRead]    Script Date: 03/11/2013 18:05:41 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomImageRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomImageRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN		
		SELECT 
			Id,
			[RoomId],
			[Name],
			[Image]
		FROM [Lodge].RoomImage
		WHERE Id = @Id   
		
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonReadForParent]    Script Date: 03/11/2013 18:10:51 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReasonReadForParent]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomClosureReasonReadForParent]
	(
		@ParentId Numeric(10,0)
	)
	AS
	BEGIN		
		SELECT 
			Id,
			[ClosedDate],
			[Reason],			
			[RoomId]
		FROM [Lodge].RoomClosureReason
		WHERE RoomId = @ParentId   
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[RoomImageReadForParent]    Script Date: 03/12/2013 10:09:32 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomImageReadForParent]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomImageReadForParent]
	(
		@ParentId Numeric(10,0)
	)
	AS
	BEGIN		
		SELECT 
			Id,
			[RoomId],
			[Name],
			[Image]
		FROM [Lodge].RoomImage
		WHERE RoomId = @ParentId   
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[RoomReadAll]    Script Date: 03/12/2013 10:18:23 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReadAll]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomReadAll]
	As
	Begin
		SELECT 
			Id,
			[Number],
			[Name],
			[Description],
			[CategoryId],
			[TypeId],
			[BuildingId],
			[FloorId],
			[IsAirConditioned],
			[StatusId]
		FROM [Lodge].Room
	End'
End


GO
/****** Object:  StoredProcedure [Lodge].[RoomUpdate]    Script Date: 03/12/2013 12:01:44 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomUpdate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomUpdate]
	(	
		@Id Numeric(10,0),
		@Number Varchar(50),	
		@Name Varchar(50),
		@Description Varchar(50),
		@CategoryId Numeric(10,0),		
		@TypeId Numeric(10,0),
		@BuildingId Numeric(10,0),
		@FloorId Numeric(10,0),
		@IsAirConditioned Bit,		
		@StatusId Numeric(10,0)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].Room
		SET	
			[Number] = @Number,
			[Name] = @Name,
			[Description] = @Description,
			[CategoryId] = @CategoryId,
			[TypeId] = @TypeId,
			[BuildingId] = @BuildingId,
			[FloorId] = @FloorId,
			[IsAirConditioned] = @IsAirConditioned,
			[StatusId] = @StatusId
		WHERE Id = @Id
	   
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[RoomDelete]    Script Date: 03/12/2013 12:05:22 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Lodge].Room
	WHERE Id = @Id 
END'
End


GO
/****** Object:  StoredProcedure [Lodge].[RoomModifyStatus]    Script Date: 03/12/2013 12:23:36 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomModifyStatus]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomModifyStatus]
	(	
		@Id Numeric(10,0),
		@StatusId Numeric(10,0)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].Room
		SET	
			[StatusId] = @StatusId			
		WHERE Id = @Id
	   
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonInsert]    Script Date: 03/12/2013 12:24:18 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReasonInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomClosureReasonInsert]
	(  
		@Reason Varchar(50),	
		@RoomId Numeric(10,0),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].RoomClosureReason([Reason],[RoomId],ClosedDate)
		VALUES(@Reason,@RoomId,GETDATE())
	   
		SET @Id = @@IDENTITY
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonRead]    Script Date: 03/12/2013 12:31:56 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomClosureReasonRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomClosureReasonRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[Reason],			
			[RoomId],
			[ClosedDate]
		FROM [Lodge].RoomClosureReason
		WHERE Id = @Id   
		
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffInsert]    Script Date: 03/12/2013 17:23:30 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTariffInsert]
	(  
		@Rate Money,	
		@StartDate DateTime,
		@EndDate DateTime,
		@ItemId Numeric(10,0),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].RoomTariff([Rate],[StartDate],[EndDate],[RoomId])
		VALUES(@Rate,@StartDate,@EndDate,@ItemId)
	   
		SET @Id = @@IDENTITY
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffRead]    Script Date: 03/13/2013 09:49:27 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTariffRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[Rate],
			[StartDate],
			[EndDate],
			[RoomId] As ItemId
		FROM [Lodge].RoomTariff
		WHERE Id = @Id   
		
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffReadAll]    Script Date: 03/13/2013 10:01:57 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffReadAll]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTariffReadAll]
	As
	Begin
		SELECT 
			Id,
			[Rate],
			[StartDate],
			[EndDate],
			[RoomId] As ItemId
		FROM [Lodge].RoomTariff
	End'
End

GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffUpdate]    Script Date: 03/13/2013 10:52:26 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffUpdate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTariffUpdate]
(
	@Id Numeric(10,0),
	@Rate Money,	
	@StartDate DateTime,
	@EndDate DateTime,
	@ItemId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE [Lodge].RoomTariff
	SET	
		[Rate] = @Rate,
		[StartDate] = @StartDate,
		[EndDate] = @EndDate,
		[RoomId] = @ItemId
	WHERE Id = @Id
   
END'
End


GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffDelete]    Script Date: 03/13/2013 10:55:55 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTariffDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].RoomTariff
		WHERE Id = @Id      
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffModifyRate]    Script Date: 03/13/2013 11:34:17 ******/	
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomTariffModifyRate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[RoomTariffModifyRate]
	(	
		@CategoryId Numeric(10,0),
		@TypeId Numeric(10,0),
		@Rate Money
	)
	AS
	BEGIN
		
		Update [Lodge].[RoomTariff]
		Set Rate = @Rate
		Where id in (
		Select id From [Lodge].[Room]
		Where CategoryId = @CategoryId
		And TypeId = @TypeId
		)
	   
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationInsert]    Script Date: 03/24/2013 10:46:57 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[RoomReservationInsert]
	(  
		@ActivityDate DateTime,
		@StatusId Numeric(10,0),
		@NoOfDays Int,
		@NoOfPersons Int,
		@NoOfRooms	Int,
		@Description Varchar(150),
		@Advance Money,
		@Id  Numeric(10,0) OUTPUT	
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].[RoomReservation]([BookingFrom],[StatusId],[NoOfDays],[NoOfPersons],[NoOfRooms],[Description],[Advance],[CreatedDate])
		VALUES(@ActivityDate,@StatusId,@NoOfDays,@NoOfPersons,@NoOfRooms,@Description,@Advance,GETDATE())
	   
		SET @Id = @@IDENTITY
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationRead]    Script Date: 03/20/2013 14:34:46 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[RoomReservationRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN		
		SELECT 
			Id,
			[BookingFrom],
			[StatusId],
			[NoOfDays],
			[NoOfPersons],
			[NoOfRooms],
			[Description],
			[Advance],
			[CreatedDate],
			[IsCheckedIn]
		FROM [Lodge].RoomReservation
		WHERE Id = @Id   
		
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationReadAll]    Script Date: 03/20/2013 14:39:38 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationReadAll]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[RoomReservationReadAll]
	AS
	BEGIN
		
		SELECT 
			Id,
			[BookingFrom],
			[StatusId],
			[NoOfDays],
			[NoOfPersons],
			[NoOfRooms],
			[Description],
			[Advance],
			[CreatedDate]
		FROM [Lodge].RoomReservation
		
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationUpdate]    Script Date: 03/20/2013 14:45:26 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationUpdate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[RoomReservationUpdate]
	(	
		@Id Numeric(10,0),
		@ActivityDate DateTime,
		@StatusId Numeric(10,0),
		@NoOfDays Int,
		@NoOfPersons Int,
		@NoOfRooms	Int,
		@Description Varchar(150),
		@Advance Money
	)
	AS
	BEGIN
		
		UPDATE [Lodge].[RoomReservation]
		SET				
			[BookingFrom] = @ActivityDate,
			[StatusId] = @StatusId,
			[NoOfDays] = @NoOfDays,
			[NoOfPersons] = @NoOfPersons,
			[NoOfRooms] = @NoOfRooms,
			[Description] = @Description,
			[Advance] = @Advance
		WHERE Id = @Id
	   
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDelete]    Script Date: 03/20/2013 14:48:30 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[RoomReservationDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Lodge].RoomReservation
	WHERE Id = @Id 
END'
End

GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationSearch]    Script Date: 03/20/2013 18:44:16 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationSearch]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [Lodge].[RoomReservationSearch] 
	(
		@StartDate DateTime,
		@EndDate DateTime,
		@StatusId Numeric(10,0)
	)
	As
	Begin
		SELECT 
			R.Id,
			[BookingFrom],
			[StatusId],
			[NoOfDays],
			[NoOfPersons],
			[NoOfRooms],
			[Description],
			[Advance],
			[CreatedDate],
			RRD.RoomId AS ProductId
		FROM [Lodge].RoomReservation R
		INNER JOIN Lodge.RoomReservationDetails RRD on R.Id = RRD.ReservationId
		Where R.statusId = @StatusId
		And cast(convert(char(11), R.BookingFrom, 113) as datetime) Between @StartDate And @EndDate
		Or cast(convert(char(11), DATEADD(day,R.NoOfDays,R.BookingFrom), 113) as datetime) Between @StartDate And @EndDate
		Or @StartDate Between cast(convert(char(11), R.BookingFrom, 113) as datetime) And cast(convert(char(11), DATEADD(day,R.NoOfDays,R.BookingFrom), 113) as datetime)
		Or @EndDate Between cast(convert(char(11), R.BookingFrom, 113) as datetime) And cast(convert(char(11), DATEADD(day,R.NoOfDays,R.BookingFrom), 113) as datetime)
		order by R.Id,RRD.ReservationId

	End'
End

GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationUpdateStatus]    Script Date: 03/20/2013 18:45:42 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationUpdateStatus]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[RoomReservationUpdateStatus]
	(	
		@ProductId Numeric(10,0),
		@StatusId Numeric(10,0)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].[RoomReservation]
		SET	
			[StatusId] = @StatusId
		WHERE Id = @ProductId 
	   
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsRead]    Script Date: 03/26/2013 09:52:15 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[RoomReservationDetailsRead]
	(
	   @ReservationId Numeric(10,0)
	)
	AS
	BEGIN
		
	   Select 
			Id,
			RoomId,
			ReservationId
	   From [Lodge].RoomReservationDetails
	   Where ReservationId = @ReservationId   
	   
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsDelete]    Script Date: 03/26/2013 09:53:39 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE  [Lodge].[RoomReservationDetailsDelete]
	(
		@ReservationId  Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].[RoomReservationDetails]
		WHERE ReservationId = @ReservationId      
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsInsert]    Script Date: 03/26/2013 09:55:49 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomReservationDetailsInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[RoomReservationDetailsInsert]
	(  
		@RoomId  Numeric(10,0),
		@ReservationId  Numeric(10,0),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].[RoomReservationDetails]([RoomId],[ReservationId])
		VALUES(@RoomId,@ReservationId)
	   
		SET @Id = @@IDENTITY
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[CheckInInsert]    Script Date: 04/04/2013 16:01:33 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[CheckInInsert]
	(  
		@Advance Money,
		@ReservationId Numeric(10,0),		
		@ActivityDate DateTime,		
		@StatusId Numeric(10,0),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].CheckIn([CheckInDate],[Advance],[CreatedDate],[ReservationId],[StatusId])
		VALUES(@ActivityDate,@Advance,GETDATE(),@ReservationId,@StatusId)
	   
		SET @Id = @@IDENTITY
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[CheckInRead]    Script Date: 04/04/2013 16:09:38 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[CheckInRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN		
		SELECT 
			Id,
			[CheckInDate],
			[Advance],
			[CreatedDate],
			[ReservationId],
			[StatusId]
		FROM [Lodge].CheckIn
		WHERE Id = @Id   
		
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[CheckInUpdate]    Script Date: 04/04/2013 16:15:20 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInUpdate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[CheckInUpdate]
	(	
		@Id Numeric(10,0),		
		@Advance Money,
		@ReservationId Numeric(10,0),		
		@ActivityDate DateTime,		
		@StatusId Numeric(10,0)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].CheckIn
		SET				
			[CheckInDate] = @ActivityDate,
			[Advance] = @Advance,
			[ReservationId] = @ReservationId,
			[StatusId] = @StatusId
		WHERE Id = @Id
	   
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[CheckInDelete]    Script Date: 04/04/2013 16:18:36 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckInDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[CheckInDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].CheckIn
		WHERE Id = @Id      
	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[IsCheckInDeletable]    Script Date: 04/17/2013 18:13:28 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsCheckInDeletable]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[IsCheckInDeletable]
(
	@RoomId NUMERIC(10,0)
)
AS
BEGIN
	Select 
			C.CheckInDate,
			C.Advance,
			C.CreatedDate,
			C.StatusId As ''CheckInStatusId'',
			R.Advance As ''Reservation Advance'',
			R.BookingFrom,
			R.NoOfDays,
			R.NoOfPersons,
			R.NoOfRooms,
			R.Description,
			R.CreatedDate As ''Reservation Date'',
			R.StatusId As ''ReservationStatusId''
	 from [lodge].CheckIn C Inner Join [lodge].RoomReservation R
	 on C.ReservationId = R.Id
	 Where ReservationId In (
		 Select ReservationId From [lodge].RoomReservationDetails
		 Where RoomId = @RoomId	 )

 END'
End

GO
/****** Object:  StoredProcedure [Lodge].[IsTariffDeletable]    Script Date: 04/17/2013 19:02:30 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsTariffDeletable]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[IsTariffDeletable] 
(
	@RoomId NUMERIC(10,0)
)
AS
BEGIN
	Select 
		StartDate,
		EndDate	
	From [lodge].RoomTariff
	Where RoomId = @RoomId

 END'
End


GO
/****** Object:  StoredProcedure [Lodge].[RoomStatusDelete]    Script Date: 04/24/2013 17:09:05 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[RoomStatusDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE  [Lodge].[RoomStatusDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].RoomStatus
		WHERE Id = @Id      
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[IsRoomStatusDeletable]    Script Date: 04/24/2013 17:10:29 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsRoomStatusDeletable]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Lodge].[IsRoomStatusDeletable] 
	(
		@RoomStatusId NUMERIC(10,0)
	)
	AS
	BEGIN
		Select Name,Number 
		from [lodge].Room
		Where StatusId = @RoomStatusId

	 END'
End


GO
/****** Object:  StoredProcedure [Lodge].[IsRoomTypeDeletable]    Script Date: 04/24/2013 19:17:58 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsRoomTypeDeletable]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [Lodge].[IsRoomTypeDeletable]
	(
		@TypeId NUMERIC(10,0)
	)
	As
	Begin
		select Name,Number from [lodge].Room
		where TypeId = @TypeId
	End'
End

GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingFloorDeletable]    Script Date: 04/25/2013 13:51:36 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsBuildingFloorDeletable]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[IsBuildingFloorDeletable] 
	(
		@FloorId NUMERIC(10,0)
	)
	AS
	BEGIN
		Select Name,Number
		from [lodge].Room
		Where FloorId = @FloorId

	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[IsRoomCategoryDeletable]    Script Date: 04/25/2013 14:17:57 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsRoomCategoryDeletable]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[IsRoomCategoryDeletable]
		(
			@RoomCategoryId NUMERIC(10,0)
		)
	AS
	BEGIN
		Select Name,Number
		from [lodge].Room
		Where CategoryId = @RoomCategoryId

	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[IsRoomBuildingDeletable]    Script Date: 04/25/2013 14:34:54 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[IsRoomBuildingDeletable]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[IsRoomBuildingDeletable]
		(
			@BuildingId NUMERIC(10,0)
		)
	AS
	BEGIN
		Select Name,Number
		from [lodge].Room
		Where BuildingId = @BuildingId

	END'
End

GO
/****** Object:  StoredProcedure [Lodge].[TariffReadDuplicate]    Script Date: 05/07/2013 18:00:07 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[TariffReadDuplicate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Lodge].[TariffReadDuplicate]
	(
		@RoomId Numeric(10,0),
		@StartDate DateTime,
		@EndDate DateTime
	)
	AS
	BEGIN

		Select 
			RT.Id,
			RT.Rate,
			RT.StartDate,
			RT.EndDate,
			RT.RoomId
		From [Lodge].RoomTariff RT
		Where RoomId = @RoomId
		And 
		(
		cast(convert(char(11), @StartDate, 113) as datetime)  between cast(convert(char(11), StartDate, 113) as datetime) and cast(convert(char(11), EndDate, 113) as datetime)
		Or cast(convert(char(11), @EndDate, 113) as datetime) between cast(convert(char(11), StartDate, 113) as datetime) and cast(convert(char(11), EndDate, 113) as datetime)
		or cast(convert(char(11), StartDate, 113) as datetime) between cast(convert(char(11), @StartDate, 113) as datetime) and cast(convert(char(11), @EndDate, 113) as datetime)
		or cast(convert(char(11), EndDate, 113) as datetime) between cast(convert(char(11), @StartDate, 113) as datetime) and cast(convert(char(11), @EndDate, 113) as datetime)
		)
	END'
End


GO
/****** Object:  StoredProcedure [Lodge].[UpdateReservationStatusToCheckIn]    Script Date: 05/14/2013 12:41:30 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[UpdateReservationStatusToCheckIn]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE Procedure [Lodge].UpdateReservationStatusToCheckIn
	(
		@ReservationId Numeric(10,0)
	)
	As
	Begin
		Update [Lodge].RoomReservation
		Set IsCheckedIn = 1
		Where [Lodge].RoomReservation.Id = @ReservationId
	End'
End
/*****************************************************************************************************/
/*****************************************************************************************************/

