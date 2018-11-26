
CREATE PROCEDURE [dbo].Transactions_Delete 
	-- Add the parameters for the stored procedure here
	@Id int

AS
BEGIN
	Update Transactions
	Set IsDeleted=1
	where Id=@Id
END