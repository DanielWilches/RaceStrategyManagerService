CREATE PROCEDURE GetAllStrategies
AS
BEGIN
	SET
	NOCOUNT ON;
	
	SELECT
	strategy.*,
	pilots.*,
	clients.*
FROM
	Strategies strategy
LEFT JOIN Pilots pilots ON
	strategy.Pilot_Id = pilots.Id_Pilot
LEFT JOIN Clients clients ON
	strategy.Client_Id = clients.Id_Client
END
