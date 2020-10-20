CREATE TABLE [General].[NaturalPerson]
(
	[Key] BIGINT NOT NULL PRIMARY KEY,
	[IdType] SMALLINT NOT NULL,
    [Identification] VARCHAR(50) NOT NULL,
    [FirstName] VARCHAR(50) NOT NULL,
    [SecondName] VARCHAR(50) NULL,
    [FirstSurname] VARCHAR(50) NOT NULL,
    [SecondSurname] VARCHAR(50) NULL,
    [Birthdate] DATETIME NOT NULL,
    [TypeBlood] SMALLINT NOT NULL,
    [Rh] SMALLINT NOT NULL,
    [TimeStamp] TIMESTAMP NOT NULL, 
    [IpLastChange] VARCHAR(50) NULL DEFAULT '0.0.0.0', 
    [UserLastChange] INT NULL, 
    CONSTRAINT [FK_NaturalPerson_To_Person] FOREIGN KEY ([Key]) REFERENCES [General].[Person]([Key]),
    CONSTRAINT [FK_NaturalPerson_To_IdType] FOREIGN KEY ([IdType]) REFERENCES [General].[IdTypeNaturalPerson]([Key]),
    CONSTRAINT [UK_IdType_Identification] UNIQUE ([IdType],[Identification])
)
