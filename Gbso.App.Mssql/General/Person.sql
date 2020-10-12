CREATE TABLE [General].[Person]
(
	[Key] INT NOT NULL PRIMARY KEY, 
    [State] SMALLINT NOT NULL, 
    [TimeStamp] TIMESTAMP NOT NULL, 
    [IpLastChange] VARCHAR(50) NULL, 
    [UserLastChange] INT NULL, 
    CONSTRAINT [FK_Person_To_ModelState] FOREIGN KEY ([State]) REFERENCES [General].[ModelState]([Key])
)
