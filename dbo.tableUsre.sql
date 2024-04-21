CREATE TABLE [dbo].[tableUsre] (
    [id]       INT            NOT NULL,
    [name]     VARCHAR (50)   NOT NULL,
    [address]  VARBINARY (50) NOT NULL,
    [phone]    NCHAR (10)     NOT NULL,
    [role]     NCHAR (10)     NOT NULL,
    [dob]      DATE           NOT NULL,
    [password] VARCHAR (50)   NULL, 
    CONSTRAINT [PK_tableUsre] PRIMARY KEY ([id])
);

