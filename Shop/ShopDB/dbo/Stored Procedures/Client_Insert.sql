
CREATE PROCEDURE dbo.Client_Insert 
	-- Add the parameters for the stored procedure here
	@Name nvarchar(MAX),
	@ID int Output
AS
BEGIN
	insert into Client (Name, IsDeleted)
	Values (@Name, 0)

	set @ID = SCOPE_IDENTITY();
	return @ID
END