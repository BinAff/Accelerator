USE [AutoTourism]
GO
/****** Object:  ForeignKey [FK_BuildingClosureReason_Building]    Script Date: 05/07/2015 14:24:37 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[FK_BuildingClosureReason_Building]') AND parent_object_id = OBJECT_ID(N'[Organization].[UnitClosureReason]'))
ALTER TABLE [Organization].[UnitClosureReason] DROP CONSTRAINT [FK_BuildingClosureReason_Building]
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonDelete]    Script Date: 05/07/2015 14:24:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitClosureReasonDelete]
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonInsert]    Script Date: 05/07/2015 14:24:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitClosureReasonInsert]
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonRead]    Script Date: 05/07/2015 14:24:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitClosureReasonRead]
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonReadAll]    Script Date: 05/07/2015 14:24:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitClosureReasonReadAll]
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonReadForParent]    Script Date: 05/07/2015 14:24:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonReadForParent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitClosureReasonReadForParent]
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonUpdate]    Script Date: 05/07/2015 14:24:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitClosureReasonUpdate]
GO
/****** Object:  Table [Organization].[UnitClosureReason]    Script Date: 05/07/2015 14:24:37 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[FK_BuildingClosureReason_Building]') AND parent_object_id = OBJECT_ID(N'[Organization].[UnitClosureReason]'))
ALTER TABLE [Organization].[UnitClosureReason] DROP CONSTRAINT [FK_BuildingClosureReason_Building]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReason]') AND type in (N'U'))
DROP TABLE [Organization].[UnitClosureReason]
GO
/****** Object:  Table [Organization].[UnitClosureReason]    Script Date: 05/07/2015 14:24:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReason]') AND type in (N'U'))
BEGIN
CREATE TABLE [Organization].[UnitClosureReason](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Reason] [varchar](50) NOT NULL,
	[UnitId] [numeric](10, 0) NOT NULL,
	[ClosedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_BuildingClosureReason] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonUpdate]    Script Date: 05/07/2015 14:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitClosureReasonUpdate]
(
	@Id Numeric(10,0),
	@Reason Varchar(50),
	@UnitId Numeric(10,0),
	@ClosedDate DateTime
)
AS
BEGIN
	
	UPDATE Organization.UnitClosureReason
	SET
		UnitId = @UnitId,
		Reason = @Reason,
		ClosedDate = @ClosedDate
	FROM Organization.UnitClosureReason WITH (NOLOCK)
	WHERE Id = @Id
	
END' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonReadForParent]    Script Date: 05/07/2015 14:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonReadForParent]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitClosureReasonReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, UnitId, Reason, ClosedDate
	FROM Organization.UnitClosureReason WITH (NOLOCK)
	WHERE UnitId = @ParentId
	
END' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonReadAll]    Script Date: 05/07/2015 14:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitClosureReasonReadAll]
AS
BEGIN
	
	SELECT Id, Reason, UnitId, ClosedDate
	FROM Organization.UnitClosureReason WITH (NOLOCK)
	
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonRead]    Script Date: 05/07/2015 14:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitClosureReasonRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Reason, UnitId, ClosedDate
	FROM Organization.UnitClosureReason WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonInsert]    Script Date: 05/07/2015 14:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitClosureReasonInsert]
(  
	@Reason Varchar(50),
	@UnitId Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Organization.UnitClosureReason(Reason, UnitId, ClosedDate)
	VALUES(@Reason, @UnitId, GETDATE())
   
	SET @Id = @@IDENTITY
	
END' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonDelete]    Script Date: 05/07/2015 14:24:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitClosureReasonDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE  [Organization].[UnitClosureReasonDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Organization.UnitClosureReason
	WHERE Id = @Id      
END' 
END
GO
/****** Object:  ForeignKey [FK_BuildingClosureReason_Building]    Script Date: 05/07/2015 14:24:37 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[FK_BuildingClosureReason_Building]') AND parent_object_id = OBJECT_ID(N'[Organization].[UnitClosureReason]'))
ALTER TABLE [Organization].[UnitClosureReason]  WITH CHECK ADD  CONSTRAINT [FK_BuildingClosureReason_Building] FOREIGN KEY([UnitId])
REFERENCES [Lodge].[Building] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[Organization].[FK_BuildingClosureReason_Building]') AND parent_object_id = OBJECT_ID(N'[Organization].[UnitClosureReason]'))
ALTER TABLE [Organization].[UnitClosureReason] CHECK CONSTRAINT [FK_BuildingClosureReason_Building]
GO
