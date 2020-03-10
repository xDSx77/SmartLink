CREATE TABLE [dbo].[T_Shorcuts] (
    [id]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [url]       NVARCHAR (250) NOT NULL,
    [hash]      NCHAR (10)     NOT NULL,
    [sessionId] NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_T_Urls] PRIMARY KEY CLUSTERED ([id] ASC)
);

