--DROP PROCEDURE IF EXISTS dbo.GetOrderToComplete;
CREATE PROCEDURE GetOrderToComplete

-- parameters for procedure

AS

-- begin try (error checking) 
BEGIN TRY
	
	DECLARE @orderID int;
	DECLARE @complete bit;
	DECLARE @quantity int;
	DECLARE @quantityBuilt int;
	
	-- select an order that needs to be completed
	SELECT TOP 1 @orderID=PK_orderLine_id, @quantity=quantity, @quantityBuilt=quantityBuilt, @complete=complete 
	FROM dbo.OrderLineTable
	WHERE complete = 0;

	-- check if the query returned valid rows
	IF @orderID is NULL
	BEGIN
		RETURN
	END

	-- cursor used to go through available lamps
	DECLARE @loopcursor CURSOR;

	-- variables to store each rows content
	DECLARE @neededLamps int = @quantity-@quantityBuilt;
	DECLARE @lampID int;
	DECLARE @timeBuilt datetime;
	DECLARE @testStatus bit;

	BEGIN

		-- set the cursor to get all the lamps not assigned to an order
		SET @loopcursor = CURSOR FOR
		SELECT PK_fog_lamp_id, timeBuilt, test_pass_status
		FROM dbo.BuiltFogLampsTable
		WHERE PK_fog_lamp_id NOT IN
			(SELECT FK_fogLamp_id
			FROM dbo.OrderTable)
		AND test_pass_status = 1;

		-- get the first row
		OPEN @loopcursor
		FETCH NEXT FROM @loopcursor
		INTO @lampID, @timeBuilt, @testStatus

		-- check if the row is not empty
		IF @lampID is NULL
		BEGIN
			RETURN
		END

		WHILE @@FETCH_STATUS = 0
		BEGIN

			-- attach the fog lamp to the order
			INSERT INTO OrderTable
			VALUES (@orderID, @timeBuilt, @lampID);

			-- increment the number of lamps attached to order
			SET @quantityBuilt = @quantityBuilt + 1
			IF @quantityBuilt > @quantity
			BEGIN
				SET @quantityBuilt = @quantity
				SET @complete = 1;
				BREAK;
			END

			-- get the next lamp
			FETCH NEXT FROM @loopcursor
			INTO @lampID, @timeBuilt, @testStatus

		END;

		-- update the order with the new values
		UPDATE OrderLineTable
		SET quantityBuilt=@quantityBuilt, complete=@complete
		WHERE PK_orderLine_id=@orderID;

		CLOSE @loopcursor;
		DEALLOCATE @loopcursor;

	END;

END TRY

-- catch any errors
BEGIN CATCH
	SELECT ErrorLine= ERROR_LINE(), 
	ErrorMessage= ERROR_MESSAGE(), 
	ErrorNumber= ERROR_NUMBER(), 
	ErrorProcedure= ERROR_PROCEDURE(), 
	ErrorSeverity= ERROR_SEVERITY(), 
	ErrorState= ERROR_STATE()
END CATCH