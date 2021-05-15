CREATE PROCEDURE [dbo].[Procedure]
	@name nchar(50),
	@message nchar(500)
AS
	INSERT INTO Messages(Name, Message) VALUES(@name, @message)
RETURN 0