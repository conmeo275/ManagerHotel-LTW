USE [QuanLyTestOne-ByConnectionString]
GO
/****** Object:  Trigger [dbo].[trg_Change]    Script Date: 6/28/2020 10:31:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER TRIGGER [dbo].[trg_Change] ON [dbo].[Revervations] AFTER UPDATE AS
IF ((SELECT RoomId FROM inserted) <>0 and (SELECT ServiceID from inserted) = 0)
BEGIN
	UPDATE Rooms
	SET StatusID = 3
	FROM Rooms
	JOIN inserted ON Rooms.RoomId = inserted.RoomId
END
IF ((SELECT RoomId FROM deleted) <>0 and (SELECT ServiceID from deleted) = 0)
BEGIN
	UPDATE Rooms
	SET StatusID = 1
	FROM Rooms
	JOIN deleted ON Rooms.RoomId = deleted.RoomId
END