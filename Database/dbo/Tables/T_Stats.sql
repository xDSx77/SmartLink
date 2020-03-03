CREATE TABLE [dbo].[T_Stats] (
    [id]    INT      NOT NULL,
    [idUrl] INT      NOT NULL,
    [date]  DATETIME NOT NULL,
    CONSTRAINT [PK_T_Stats] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_T_Stats_T_Shortcuts] FOREIGN KEY ([idUrl]) REFERENCES [dbo].[T_Shortcuts] ([id])
);

