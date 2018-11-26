
CREATE PROCEDURE dbo.Client_Update 
	-- Add the parameters for the stored procedure here
	@Id int,
	@Name nvarchar(MAX)
AS
BEGIN
	Update Client Set Name=@Name
	where Id=@Id
END