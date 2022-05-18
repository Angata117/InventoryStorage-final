USE [InventoryStorage]
GO
/****** Object:  Trigger [dbo].[History_UPDATE]    Script Date: 4.2.2022 г. 21:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[History_UPDATE] ON [dbo].[Items]
	AFTER UPDATE
AS
BEGIN
	SET IDENTITY_INSERT Histories ON;
	SET NOCOUNT ON;
	DECLARE @Id int
	DECLARE @ItemName nvarchar(MAX)
	DECLARE @Description nvarchar(MAX)
	DECLARE @OldLocation int
	DECLARE @Location int
	DECLARE @DateTimeWhenChanged datetime2
	if UPDATE(Location)
	BEGIN
	SELECT @Id = inserted.Id
	FROM inserted
	SELECT @ItemName = inserted.ItemName
	from inserted
	SELECT @Description = inserted.Description
	from inserted
	SELECT @OldLocation = deleted.Location
	from deleted
	SELECT @Location = inserted.Location
	from inserted
	END
	
	INSERT INTO [Histories](
	Id
	,[ItemName]
	,[Description]
	,[OldLocation]
	,[Location]
	,[DateTimeWhenChanged])
	VALUES(@Id,
	@ItemName,
	@Description,
	@OldLocation,
	@Location,
	GETDATE()
	)
END


