CREATE PROCEDURE [General].[Person_Crud]
	@Key INT = NULL,
	@IdType SMALLINT = NULL,
	@Identification VARCHAR(50) = NULL,
	@Birthdate DATETIME = NULL,
	@TimeStamp TIMESTAMP = NULL,
	@IpLastChange VARCHAR = NULL,
	@UserLastChange INT = NULL,
	@Stp_Action SMALLINT = NULL
AS
	IF @Stp_Action = 1
		INSERT INTO [General].[Person] 
		([IdType], [Identification], [Birthdate], [IpLastChange], [UserLastChange])
		VALUES 
		(@IdType, @Identification, @Birthdate, @IpLastChange, @UserLastChange)

	IF @Stp_Action = 2
		select [Key], [IdType], [Identification], [Birthdate], [TimeStamp], [IpLastChange], [UserLastChange]
		from [General].[Person]
RETURN 0