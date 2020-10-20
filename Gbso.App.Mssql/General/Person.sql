CREATE TABLE [General].[Person]
(
	[Key] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    --[State] SMALLINT NOT NULL, 
    [TimeStamp] TIMESTAMP NOT NULL, 
    [IpLastChange] VARCHAR(50) NULL, 
    [UserLastChange] INT NULL, 
    --CONSTRAINT [FK_Person_To_ModelState] FOREIGN KEY ([State]) REFERENCES [General].[ModelState]([Key])
)
