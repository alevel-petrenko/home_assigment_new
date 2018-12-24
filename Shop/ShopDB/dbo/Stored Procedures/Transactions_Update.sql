
CREATE PROCEDURE [dbo].Transactions_Update 
	-- Add the parameters for the stored procedure here
	@Id int,
	@Date datetime,
	@Amount float

AS
BEGIN
	Update Transactions
	Set Date=@Date, Amount=@Amount
	where Id=@Id
END