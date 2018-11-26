
CREATE PROCEDURE dbo.Client_Delete 
	-- Add the parameters for the stored procedure here
	@Id int

AS
BEGIN
	Update Client
	Set IsDeleted=1
	where Id=@Id
END