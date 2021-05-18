CREATE PROCEDURE [dbo].[MessageSelect]
	@ip nchar(15)
AS
    SELECT Date FROM Messages WHERE Ip = @ip AND Date=(SELECT MAX(Date) FROM Messages WHERE Ip = @ip);