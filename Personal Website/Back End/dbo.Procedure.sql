CREATE PROCEDURE [dbo].[Procedure]
	@name nchar(50),
	@message varchar(500),
	@date datetime,
	@ip nchar(15)
AS
	INSERT INTO Messages([Name], [Message], [Date], [Ip]) VALUES(@name, @message, @date, @ip)
RETURN 0