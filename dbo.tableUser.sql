CREATE TABLE [dbo].[tableUser] (
    [id]       INT            NOT NULL,
    [name]     VARCHAR (50)   NOT NULL,
    [address]  VARCHAR (50)  NOT NULL,
    [phone]    NCHAR (10)     NOT NULL,
    [role]     NCHAR (10)     NOT NULL,
    [dob]      DATE           NOT NULL,
    [password] VARCHAR (50)   NULL, 
    CONSTRAINT [PK_tableUser] PRIMARY KEY ([id])
);

