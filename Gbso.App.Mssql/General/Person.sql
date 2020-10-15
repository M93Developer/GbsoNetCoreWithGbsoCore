CREATE TABLE [General].[Person]
(
	[Key] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [IdType] SMALLINT NOT NULL,
    [Identification] VARCHAR(50) NOT NULL,
    [Birthdate] DATETIME NOT NULL,
    --[State] SMALLINT NOT NULL, 
    [TimeStamp] TIMESTAMP NOT NULL, 
    [IpLastChange] VARCHAR(50) NULL, 
    [UserLastChange] INT NULL, 
    CONSTRAINT [FK_Person_To_IdType] FOREIGN KEY ([IdType]) REFERENCES [General].[IdType]([Key])
    --CONSTRAINT [FK_Person_To_ModelState] FOREIGN KEY ([State]) REFERENCES [General].[ModelState]([Key])
)
