CREATE PROCEDURE [General].[Person_Crud]
	@Key INT = NULL,
	@TimeStamp TIMESTAMP = NULL,
	@IpLastChange VARCHAR = NULL,
	@UserLastChange INT = NULL,
	@Stp_Action SMALLINT = NULL
AS
	DECLARE @VALIDADOR BIT = 0
	--Set
	IF @Stp_Action = 1
	BEGIN
		SET @VALIDADOR = 1
		INSERT INTO [General].[Person] 
		([IpLastChange], [UserLastChange])
		VALUES 
		(@IpLastChange, @UserLastChange)

		SELECT SCOPE_IDENTITY()
	END
	--Get
	IF @Stp_Action = 2
	BEGIN
		SET @VALIDADOR = 1
		SELECT [Key], [TimeStamp], [IpLastChange], [UserLastChange]
		FROM [General].[Person]
	END
	IF @VALIDADOR = 0	
		RAISERROR (888001,16,1, 'Operation not found.');
	ELSE
		RETURN @@ERROR
RETURN 0