CREATE TABLE [dbo].[T_Shortcuts] (
    [id]        INT           NOT NULL,
    [url]       VARCHAR (MAX) NOT NULL,
    [hash]      VARCHAR (MAX) NOT NULL,
    [sessionId] INT           NOT NULL,
    CONSTRAINT [PK_T_Shortcuts] PRIMARY KEY CLUSTERED ([id] ASC)
);

