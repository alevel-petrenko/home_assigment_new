
CREATE PROCEDURE [dbo].Transactions_Insert 
	-- Add the parameters for the stored procedure here
	@ClientId int,
	@Date datetime,
	@Amount float,
	@IsDeleted bit

AS
BEGIN
	Insert into Transactions (ClientId, [Date], Amount, IsDeleted)
	Values (@ClientId, @Date, @Amount, 0)

END