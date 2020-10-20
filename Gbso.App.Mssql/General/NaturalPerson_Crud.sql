CREATE PROCEDURE [General].[NaturalPerson_Crud]
	@Key INT = NULL,
	@IdType SMALLINT = NULL,
	@Identification VARCHAR(50) = NULL,
	@FirstName VARCHAR(50) = NULL,
	@SecondName VARCHAR(50) = NULL,
	@FirstSurname VARCHAR(50) = NULL,
	@SecondSurname VARCHAR(50) = NULL,
	@Birthdate DATETIME = NULL,
	@TypeBlood SMALLINT = NULL,
	@Rh SMALLINT = NULL,
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

		INSERT INTO [General].[NaturalPerson] 
		([Key], [IdType], [Identification], [FirstName], [SecondName], [FirstSurname], [SecondSurname], [Birthdate], [TypeBlood], [Rh], [IpLastChange], [UserLastChange])
		VALUES
		(@Key, @IdType, @Identification, @FirstName, @SecondName, @FirstSurname, @SecondSurname, @Birthdate, @TypeBlood, @Rh, @IpLastChange, @UserLastChange)
		
		SELECT SCOPE_IDENTITY()
	END
	--Get
	ELSE IF @Stp_Action = 2
	BEGIN
		SET @VALIDADOR = 1

		select [Key], [IdType], [Identification], [FirstName], [SecondName], [FirstSurname], [SecondSurname], [Birthdate], [TypeBlood], [Rh], [IpLastChange], [UserLastChange]
		from [General].[NaturalPerson]
	END
	--Update
	ELSE IF @Stp_Action = 3
	BEGIN
		SET @VALIDADOR = 1

		UPDATE [General].[NaturalPerson] SET
			[IdType] = @IdType,
			[Identification] = @Identification,
			[FirstName] = @FirstName,
			[SecondName] = @SecondName,
			[FirstSurname] = @FirstSurname,
			[SecondSurname] = @SecondSurname,
			[Birthdate] = @Birthdate,
			[TypeBlood] = @TypeBlood,
			[Rh] = @Rh,
			[IpLastChange] = @IpLastChange,
			[UserLastChange] = @UserLastChange
		WHERE [Key] = @Key AND [TimeStamp] = @TimeStamp
	END		
	--Delete
	ELSE IF @Stp_Action = 4
	BEGIN
		SET @VALIDADOR = 1

		DELETE [General].[NaturalPerson]
		WHERE [Key] = @Key
	END
	--RegisterAndReturnModel
	ELSE IF @Stp_Action = 5
	BEGIN
		SET @VALIDADOR = 1

		SELECT 1
	END
	--UpdateAndReturnModel
	ELSE IF @Stp_Action = 6
	BEGIN
		SET @VALIDADOR = 1

		SELECT 1
	END

	IF @VALIDADOR = 0	
		RAISERROR (888001,16,1, 'Operation not found.');
	ELSE
		RETURN @@ERROR

RETURN 0